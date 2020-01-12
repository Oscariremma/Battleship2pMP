using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibOscar;
using static LibOscar.Methods;

namespace Battleship2pMP.MDI_Forms
{
    public partial class MDI_Game : Form
    {
        private readonly Pen BlackPen = new Pen(Color.Black, 3);

        public static MDI_Game staticGame;

        public delegate void DelUpdateGameBoard(GameLogic.GameBoardTile[,] gameBoard);
        public delegate void DelSwitchGameBoardView(bool ShowOpponentsGameBoard);
        public delegate void DelInvalidate();
        public delegate void DelStopUpdateTimer();

        public DelUpdateGameBoard DUpdateGameBoard;
        /// <summary>
        /// Switches the players view to the local game board if false and the opponents if true
        /// </summary>
        public DelSwitchGameBoardView DSwitchGameBoardView;
        public DelInvalidate DInvalidate;
        public DelStopUpdateTimer DStopUpdateTimer;

        private ShipOrientation orientation = ShipOrientation.Down;

        private readonly Rectangle[] coordinateTiles = new Rectangle[] { new Rectangle(0, 0, 61, 61), new Rectangle(0, 61, 61, 61), new Rectangle(0, 122, 61, 61), new Rectangle(0, 183, 61, 61), new Rectangle(0, 244, 61, 61), new Rectangle(0, 305, 61, 61), new Rectangle(0, 366, 61, 61), new Rectangle(0, 427, 61, 61), new Rectangle(0, 488, 61, 61), new Rectangle(0, 549, 61, 61), new Rectangle(61, 549, 61, 61), new Rectangle(122, 549, 61, 61), new Rectangle(183, 549, 61, 61), new Rectangle(244, 549, 61, 61), new Rectangle(305, 549, 61, 61), new Rectangle(366, 549, 61, 61), new Rectangle(427, 549, 61, 61), new Rectangle(488, 549, 61, 61), new Rectangle(549, 549, 61, 61) };
        private readonly Line[] GridLines = new Line[] { new Line(new Point(1, 1), new Point(1, 610)), new Line(new Point(1, 1), new Point(610, 1)), new Line(new Point(609, 1), new Point(609, 610)), new Line(new Point(1, 609), new Point(610, 609)), new Line(new Point(0, 0), new Point(610, 0)), new Line(new Point(61, 0), new Point(61, 610)), new Line(new Point(122, 0), new Point(122, 610)), new Line(new Point(183, 0), new Point(183, 610)), new Line(new Point(244, 0), new Point(244, 610)), new Line(new Point(305, 0), new Point(305, 610)), new Line(new Point(366, 0), new Point(366, 610)), new Line(new Point(427, 0), new Point(427, 610)), new Line(new Point(488, 0), new Point(488, 610)), new Line(new Point(549, 0), new Point(549, 610)), new Line(new Point(0, 61), new Point(610, 61)), new Line(new Point(0, 122), new Point(610, 122)), new Line(new Point(0, 183), new Point(610, 183)), new Line(new Point(0, 244), new Point(610, 244)), new Line(new Point(0, 305), new Point(610, 305)), new Line(new Point(0, 366), new Point(610, 366)), new Line(new Point(0, 427), new Point(610, 427)), new Line(new Point(0, 488), new Point(610, 488)), new Line(new Point(0, 549), new Point(610, 549)) };

        private bool drawLocalGameBoard = true;
        private bool showReticle = false;
        private bool drawTargets = false;

        private List<Point> Targets;
        private bool firstTurn = true;
        private int shotsFirstTurn = 4;

        public GameLogic.GameBoardTile[,] localGameBoardTiles = new GameLogic.GameBoardTile[0, 0];
        public GameLogic.GameBoardTile[,] remoteGameBoardTiles = new GameLogic.GameBoardTile[0, 0];

        public List<Sprite> localSpriteTable = new List<Sprite>();
        public List<Sprite> remoteSpriteTable = new List<Sprite>();

        private Ships.ShipEnum SelectedShipType;

        private bool DeleteMode = false;

        //Ships left to place counters
        private byte CarriersLeft = 1;
        private byte BattleshipsLeft = 1;
        private byte CruisersLeft = 1;
        private byte DestroyersLeft = 2;
        private byte SubmarinesLeft = 3;

        public Timer UpdateTimer;
        EventHandler UpdateEventHandler;

        public MDI_Game()
        {
            InitializeComponent();
            pnlGameBoard.Paint += new PaintEventHandler(Draw);

            Label[] CordLables = new Label[] { lbl_cord1, lbl_cord2, lbl_cord3, lbl_cord4, lbl_cord5, lbl_cord6, lbl_cord7, lbl_cord8, lbl_cord9, lbl_cordA, lbl_cordB, lbl_cordC, lbl_cordD, lbl_cordE, lbl_cordF, lbl_cordG, lbl_cordH, lbl_cordI };

            this.DoubleBuffered = true;

            pnlGameBoard.MouseWheel += new MouseEventHandler(ScrollEvent);
            pnlGameBoard.MouseClick += new MouseEventHandler(MouseClickEvent);
            pbx_Selected_Ship.MouseClick += new MouseEventHandler(MouseClickEvent);
            pbx_Reticle.MouseClick += new MouseEventHandler(MouseClickEvent);

            KeyDown += new KeyEventHandler(GameKeyDownEvent);

            foreach (Label lbl in CordLables)
            {
                lbl.Font = new Font(Program.pfc.Families[0], lbl.Font.Size);
            }
            DUpdateGameBoard = new DelUpdateGameBoard(UpdateGameBoard);
            DSwitchGameBoardView = new DelSwitchGameBoardView(SwitchGameBoard);
            DInvalidate = new DelInvalidate(pnlGameBoard.Invalidate);
            staticGame = this;
            Invalidate();

            UpdateTimer = new Timer();
            UpdateTimer.Interval = 10;
            UpdateEventHandler = new EventHandler(Update);
            UpdateTimer.Tick += UpdateEventHandler;
            UpdateTimer.Start();

            DStopUpdateTimer = new DelStopUpdateTimer(StopUpdateTimer);

            pbx_Selected_Ship.Image = (Image)Ships.Ship.Carrier.ShipSprite.Clone();
            SelectedShipType = Ships.ShipEnum.Carrier;
        }

        private void Update(object sender, EventArgs eventArgs)
        {

            try
            {
                Point pointPnl = pnlGameBoard.PointToClient(Cursor.Position);
                Point point = new Point(pointPnl.X / 61 - 1, pointPnl.Y / 61);


                if (point.X >= 0 && point.X <= 8 && point.Y >= 0 && point.Y <= 8 && !DeleteMode)
                {
                    if (showReticle)
                    {
                        pbx_Reticle.Location = new Point((point.X + 1) * 61, (point.Y) * 61);
                        pbx_Reticle.Invalidate();
                    }
                    else
                    {
                        //Sets pbx_Selected_Ship location to the cursor with a offset depending on ship orientation. Prevents the ship from going of the game board.
                        switch (orientation)
                        {
                            case ShipOrientation.Down:
                                if (point.Y + Ships.Ship.ShipFromShipEnum(SelectedShipType).Length - 1 <= 8)
                                {
                                    pbx_Selected_Ship.Location = new Point((((point.X + 1) * 61) - pbx_Selected_Ship.Width / 2) + 31, (point.Y * 61) + 10);
                                }
                                else
                                {
                                    pbx_Selected_Ship.Location = new Point((((point.X + 1) * 61) - pbx_Selected_Ship.Width / 2) + 31, ((611 - (Ships.Ship.ShipFromShipEnum(SelectedShipType).Length + 1) * 61)) + 10);
                                }
                                break;

                            case ShipOrientation.Left:
                                if (point.X + Ships.Ship.ShipFromShipEnum(SelectedShipType).Length - 1 <= 8)
                                {
                                    pbx_Selected_Ship.Location = new Point(((point.X + 1) * 61) + 10, (point.Y * 61) + 31 - pbx_Selected_Ship.Height / 2);
                                }
                                else
                                {
                                    pbx_Selected_Ship.Location = new Point((611 - (Ships.Ship.ShipFromShipEnum(SelectedShipType).Length) * 61) + 10, (point.Y * 61) + 31 - pbx_Selected_Ship.Height / 2);
                                }
                                break;

                            case ShipOrientation.Right:
                                if (point.X - (Ships.Ship.ShipFromShipEnum(SelectedShipType).Length - 1) >= 0)
                                {
                                    pbx_Selected_Ship.Location = new Point(((point.X + 1) * 61) + 52 - pbx_Selected_Ship.Width, (point.Y * 61) + 31 - pbx_Selected_Ship.Height / 2);
                                }
                                else
                                {
                                    pbx_Selected_Ship.Location = new Point(((Ships.Ship.ShipFromShipEnum(SelectedShipType).Length) * 61) + 52 - pbx_Selected_Ship.Width, (point.Y * 61) + 31 - pbx_Selected_Ship.Height / 2);
                                }
                                break;

                            case ShipOrientation.Up:
                                if (point.Y - (Ships.Ship.ShipFromShipEnum(SelectedShipType).Length - 1) >= 0)
                                {
                                    pbx_Selected_Ship.Location = new Point((((point.X + 1) * 61) - pbx_Selected_Ship.Width / 2) + 31, (point.Y * 61) - pbx_Selected_Ship.Height + 56);
                                }
                                else
                                {
                                    pbx_Selected_Ship.Location = new Point((((point.X + 1) * 61) - pbx_Selected_Ship.Width / 2) + 31, ((Ships.Ship.ShipFromShipEnum(SelectedShipType).Length - 1) * 61) - pbx_Selected_Ship.Height + 56);
                                }
                                break;
                        }

                        pbx_Selected_Ship.Invalidate();
                    }
                }
            }
            catch
            {
                if (!UpdateTimer.Enabled)
                {
                    UpdateTimer.Stop();
                }
            }


        }

        public void UpdateGameBoard(GameLogic.GameBoardTile[,] gameBoard)
        {
            localGameBoardTiles = gameBoard;
            pnlGameBoard.Invalidate();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            ref GameLogic.GameBoardTile[,] gameBoardDrawRef = ref drawLocalGameBoard ? ref localGameBoardTiles : ref remoteGameBoardTiles;
            ref List<Sprite> spriteTableDrawRef = ref drawLocalGameBoard ? ref localSpriteTable : ref remoteSpriteTable;

            List<Rectangle> DestroyedShipsRects = new List<Rectangle>();

            e.Graphics.FillRectangles(Brushes.DarkTurquoise, coordinateTiles);
            foreach (GameLogic.GameBoardTile tile in gameBoardDrawRef)
            {
                switch (tile.TileType)
                {
                    case GameLogic.TileType.Water:
                        e.Graphics.FillRectangle(Brushes.Blue, tile.Rectangle);
                        break;

                    case GameLogic.TileType.Hit:
                        e.Graphics.FillRectangle(Brushes.Red, tile.Rectangle);
                        if (spriteTableDrawRef[tile.SpriteID].ShipDestroyed && spriteTableDrawRef[tile.SpriteID].Enabled)
                        {
                            DestroyedShipsRects.Add(tile.Rectangle);
                        }
                        break;

                    case GameLogic.TileType.Miss:
                        e.Graphics.FillRectangle(Brushes.AntiqueWhite, tile.Rectangle);
                        break;

                    case GameLogic.TileType.Ship:
                        e.Graphics.FillRectangle(Brushes.Blue, tile.Rectangle);
                        break;
                }
            }
            DrawLinesFromArray(e.Graphics, BlackPen, GridLines);

            foreach (Sprite sprite in spriteTableDrawRef)
            {
                if (sprite.Enabled)
                {
                    e.Graphics.DrawImage(sprite.SpriteImage, sprite.Location);
                }
            }

            if (drawTargets)
            {
                foreach (Point TargetPoint in Targets)
                {
                    e.Graphics.DrawImage(Program.Red_Reticle, TargetPoint);
                }
            }

            foreach(Rectangle ShipRect in DestroyedShipsRects)
            {
                e.Graphics.DrawLine(BlackPen, ShipRect.X, ShipRect.Y, ShipRect.X + 61, ShipRect.Y + 61);
                e.Graphics.DrawLine(BlackPen, ShipRect.X + 61, ShipRect.Y, ShipRect.X, ShipRect.Y + 61);
            }

        }

        private void MDI_Game_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Program.GameBackground;
        }

        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!showReticle)
                {
                    if (!DeleteMode)
                    {
                        if (ShipsLeftToBePlaced(SelectedShipType) > 0)
                        {
                            Point MouseCord = new Point((pbx_Selected_Ship.Location.X + 10) / 61 - 1, (pbx_Selected_Ship.Location.Y + 10) / 61);
                            List<GameLogic.GameBoardTile> TilesCovered = new List<GameLogic.GameBoardTile>();
                            List<Point> newShipTiles = new List<Point>();

                            for (int i = 0; i <= Ships.Ship.ShipFromShipEnum(SelectedShipType).Length - 1; i++)
                            {
                                switch (orientation)
                                {
                                    case ShipOrientation.Down:
                                        ref GameLogic.GameBoardTile downTile = ref localGameBoardTiles[MouseCord.X, MouseCord.Y + i];
                                        if (downTile.TileType == GameLogic.TileType.Ship)
                                        {
                                            return;
                                        }
                                        newShipTiles.Add(new Point(MouseCord.X, MouseCord.Y + i));
                                        TilesCovered.Add(downTile);
                                        break;

                                    case ShipOrientation.Left:
                                        ref GameLogic.GameBoardTile leftTile = ref localGameBoardTiles[MouseCord.X + i, MouseCord.Y];
                                        if (leftTile.TileType == GameLogic.TileType.Ship)
                                        {
                                            return;
                                        }
                                        newShipTiles.Add(new Point(MouseCord.X + i, MouseCord.Y));
                                        TilesCovered.Add(leftTile);
                                        break;

                                    case ShipOrientation.Right:
                                        ref GameLogic.GameBoardTile rightTile = ref localGameBoardTiles[MouseCord.X + i, MouseCord.Y];
                                        if (rightTile.TileType == GameLogic.TileType.Ship)
                                        {
                                            return;
                                        }
                                        newShipTiles.Add(new Point(MouseCord.X + i, MouseCord.Y));
                                        TilesCovered.Add(rightTile);
                                        break;

                                    case ShipOrientation.Up:

                                        ref GameLogic.GameBoardTile upTile = ref localGameBoardTiles[MouseCord.X, MouseCord.Y + i];
                                        if (upTile.TileType == GameLogic.TileType.Ship)
                                        {
                                            return;
                                        }
                                        newShipTiles.Add(new Point(MouseCord.X, MouseCord.Y + i));
                                        TilesCovered.Add(upTile);
                                        break;
                                }
                            }

                            foreach (Point tilePoint in newShipTiles)
                            {
                                localGameBoardTiles[tilePoint.X, tilePoint.Y].TileType = GameLogic.TileType.Ship;
                                localGameBoardTiles[tilePoint.X, tilePoint.Y].SpriteID = localSpriteTable.Count;
                            }

                            localSpriteTable.Add(new Sprite(SelectedShipType, orientation, pbx_Selected_Ship.Location, TilesCovered.ToArray()));

                            ref byte ShipsLeft = ref ShipsLeftToBePlaced(SelectedShipType);
                            ShipsLeft--;
                            UpdateRadioButtonText(SelectedShipType);
                            if (ShipsLeft <= 0)
                            {
                                OutOfCurrentShipType();
                            }
                        }
                        else
                        {
                            //Select a ship type with ships left to place;
                            OutOfCurrentShipType();
                        }
                    }
                    else
                    {
                        Point pointPnl = pnlGameBoard.PointToClient(Cursor.Position);
                        Point point = new Point(pointPnl.X / 61 - 1, pointPnl.Y / 61);

                        if (localGameBoardTiles[point.X, point.Y].TileType == GameLogic.TileType.Ship)
                        {
                            foreach (Point coveredtile in localSpriteTable[localGameBoardTiles[point.X, point.Y].SpriteID].CoveredTileCords)
                            {
                                localGameBoardTiles[coveredtile.X, coveredtile.Y].TileType = GameLogic.TileType.Water;
                            }

                            //Update Radio buttons
                            ShipsLeftToBePlaced(localSpriteTable[localGameBoardTiles[point.X, point.Y].SpriteID].ShipType.ShipEnum)++;
                            UpdateRadioButtonText(localSpriteTable[localGameBoardTiles[point.X, point.Y].SpriteID].ShipType.ShipEnum);

                            localSpriteTable.RemoveAt(localGameBoardTiles[point.X, point.Y].SpriteID);
                            pnlGameBoard.Invalidate();

                            //Adjust sprite IDs to match the new sprite table
                            foreach (Sprite sprite in localSpriteTable)
                            {
                                foreach (Point spriteTile in sprite.CoveredTileCords)
                                {
                                    ref GameLogic.GameBoardTile ShipGameBoardTile = ref localGameBoardTiles[spriteTile.X, spriteTile.Y];

                                    if (localGameBoardTiles[point.X, point.Y].SpriteID < ShipGameBoardTile.SpriteID)
                                    {
                                        ShipGameBoardTile.SpriteID--;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {

                    Point Reticle_Cord = new Point(((pbx_Reticle.Location.X +10) / 61) -1 , (pbx_Reticle.Location.Y +10) / 61);

                    if (remoteGameBoardTiles[Reticle_Cord.X,Reticle_Cord.Y].TileType == GameLogic.TileType.Ship || remoteGameBoardTiles[Reticle_Cord.X, Reticle_Cord.Y].TileType == GameLogic.TileType.Water)
                    {

                        if (firstTurn)
                        {
                            Targets.Add(pbx_Reticle.Location);

                            if (Targets.Count >= shotsFirstTurn)
                            {
                                List<Point> CordTargets = new List<Point>();

                                foreach (Point currentTaget in Targets)
                                {
                                    CordTargets.Add(new Point(((currentTaget.X + 10) / 61) - 1, (currentTaget.Y + 10) / 61));
                                }

                                showReticle = false;
                                pbx_Reticle.Visible = false;

                                if (Networking.IsServer)
                                {
                                    Networking.NetworkServer.StaticgameLogic.FireShots(CordTargets.ToArray(), false);
                                }
                                else
                                {
                                    MessageBox.Show(GetBinaryArray(CordTargets.ToArray(), true).Length.ToString());
                                    Networking.NetworkClient.RemoteServerInterface.FireShots(GetBinaryArray(CordTargets.ToArray(), false));
                                }

                            }

                        }
                        else
                        {

                            showReticle = false;
                            pbx_Reticle.Visible = false;

                            if (Networking.IsServer)
                            {
                                Networking.NetworkServer.StaticgameLogic.FireShots(new Point[] { Reticle_Cord }, false);
                            }
                            else
                            {
                                Networking.NetworkClient.RemoteServerInterface.FireShots(GetBinaryArray(new Point[] { Reticle_Cord }, true));
                            }
                        }
                    }

                }



            }
        }

        private void ScrollEvent(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                orientation = orientation.Next();
            }
            else
            {
                orientation = orientation.Previous();
            }

            ShipRotationChanged();
        }

        private void GameKeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    orientation = ShipOrientation.Up;
                    break;

                case Keys.Down:
                    orientation = ShipOrientation.Down;
                    break;

                case Keys.Left:
                    orientation = ShipOrientation.Left;
                    break;

                case Keys.Right:
                    orientation = ShipOrientation.Right;
                    break;

                default:
                    return;
            }
            ShipRotationChanged();
        }

        private void ShipRotationChanged()
        {
            if (pbx_Selected_Ship.Image != null)
            {
                pbx_Selected_Ship.Image.Dispose();
            }
            pbx_Selected_Ship.Image = (Image)Ships.Ship.ShipFromShipEnum(SelectedShipType).ShipSprite.Clone();
            switch (orientation)
            {
                case ShipOrientation.Down:

                    break;

                case ShipOrientation.Left:
                    pbx_Selected_Ship.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;

                case ShipOrientation.Right:
                    pbx_Selected_Ship.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case ShipOrientation.Up:
                    pbx_Selected_Ship.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
            }
            pbx_Selected_Ship.Width = pbx_Selected_Ship.Image.Width;
            pbx_Selected_Ship.Height = pbx_Selected_Ship.Image.Height;
        }

        public class Sprite
        {
            public Ships.Ship ShipType;
            public Image SpriteImage;
            public Point Location;
            public Point[] CoveredTileCords;
            public ShipOrientation ShipOrientation;
            public bool Enabled;
            public bool ShipDestroyed;

            public Sprite(Ships.ShipEnum ship, ShipOrientation Orientation, Point position, GameLogic.GameBoardTile[] TilesCovered, bool SpriteEnabled = true, bool Destroyed = false)
            {
                ShipType = Ships.Ship.ShipFromShipEnum(ship);

                SpriteImage = (Image)ShipType.ShipSprite.Clone();
                switch (Orientation)
                {
                    case ShipOrientation.Down:
                        break;

                    case ShipOrientation.Left:
                        SpriteImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;

                    case ShipOrientation.Right:
                        SpriteImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;

                    case ShipOrientation.Up:
                        SpriteImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                }

                Location = position;

                List<Point> CoveredTileCordsList = new List<Point>();

                foreach(GameLogic.GameBoardTile tile in TilesCovered)
                {
                    CoveredTileCordsList.Add(new Point(tile.Rectangle.X / 61 - 1, tile.Rectangle.Y / 61));
                }

                CoveredTileCords = CoveredTileCordsList.ToArray();
                ShipOrientation = Orientation;
                Enabled = SpriteEnabled;
                ShipDestroyed = Destroyed;


            }

            public Sprite(Ships.ShipEnum ship, ShipOrientation Orientation, Point position, Point[] CoveredTilesCords, bool SpriteEnabled = true, bool Destroyed = false)
            {
                ShipType = Ships.Ship.ShipFromShipEnum(ship);

                SpriteImage = (Image)ShipType.ShipSprite.Clone();
                switch (Orientation)
                {
                    case ShipOrientation.Down:
                        break;

                    case ShipOrientation.Left:
                        SpriteImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;

                    case ShipOrientation.Right:
                        SpriteImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;

                    case ShipOrientation.Up:
                        SpriteImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                }

                Location = position;
                CoveredTileCords = CoveredTilesCords;
                ShipOrientation = Orientation;
                Enabled = SpriteEnabled;
                ShipDestroyed = Destroyed;

            }

            #region Dispose

            private bool Desposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (Desposed) return;

                if (disposing)
                {
                    SpriteImage.Dispose();
                }
            }

            public void Dispose()
            {
                // Dispose of unmanaged resources.
                Dispose(true);
                // Suppress finalization.
                GC.SuppressFinalize(this);
            }

            #endregion Dispose
        }


        private void Rbtn_Carrier_CheckedChanged(object sender, EventArgs e)
        {
            pbx_Selected_Ship.Visible = true;
            DeleteMode = false;
            SelectedShipType = Ships.ShipEnum.Carrier;
            ShipRotationChanged();
        }

        private void Rbtn_Battleship_CheckedChanged(object sender, EventArgs e)
        {
            pbx_Selected_Ship.Visible = true;
            DeleteMode = false;
            SelectedShipType = Ships.ShipEnum.Battleship;
            ShipRotationChanged();
        }

        private void Rbtn_Cruiser_CheckedChanged(object sender, EventArgs e)
        {
            pbx_Selected_Ship.Visible = true;
            DeleteMode = false;
            SelectedShipType = Ships.ShipEnum.Cruiser;
            ShipRotationChanged();
        }

        private void Rbtn_Destroyer_CheckedChanged(object sender, EventArgs e)
        {
            pbx_Selected_Ship.Visible = true;
            DeleteMode = false;
            SelectedShipType = Ships.ShipEnum.Destroyer;
            ShipRotationChanged();
        }

        private void Rbtn_Submarine_CheckedChanged(object sender, EventArgs e)
        {
            pbx_Selected_Ship.Visible = true;
            DeleteMode = false;
            SelectedShipType = Ships.ShipEnum.SubMarine;
            ShipRotationChanged();
        }

        private void Rbtn_Remove_CheckedChanged(object sender, EventArgs e)
        {
            pbx_Selected_Ship.Visible = false;
            DeleteMode = true;
        }

        private ref byte ShipsLeftToBePlaced(Ships.ShipEnum ShipType)
        {
            switch (ShipType)
            {
                case Ships.ShipEnum.Carrier:
                    return ref CarriersLeft;

                case Ships.ShipEnum.Battleship:
                    return ref BattleshipsLeft;

                case Ships.ShipEnum.Cruiser:
                    return ref CruisersLeft;

                case Ships.ShipEnum.Destroyer:
                    return ref DestroyersLeft;

                case Ships.ShipEnum.SubMarine:
                    return ref SubmarinesLeft;

                default:
                    throw new Exception("Invalid Ship type");
            }
        }

        private RadioButton RadioButtonFromShipType(Ships.ShipEnum ShipType)
        {
            switch (ShipType)
            {
                case Ships.ShipEnum.Carrier:
                    return Rbtn_Carrier;

                case Ships.ShipEnum.Battleship:
                    return Rbtn_Battleship;

                case Ships.ShipEnum.Cruiser:
                    return Rbtn_Cruiser;

                case Ships.ShipEnum.Destroyer:
                    return Rbtn_Destroyer;

                case Ships.ShipEnum.SubMarine:
                    return Rbtn_Submarine;

                default:
                    throw new Exception("Invalid Ship type");
            }
        }

        private void OutOfCurrentShipType()
        {
            //Select a ship type width ships left to place;
            foreach (Ships.ShipEnum shipType in (Ships.ShipEnum[])Enum.GetValues(typeof(Ships.ShipEnum)))
            {
                if (ShipsLeftToBePlaced(shipType) > 0)
                {
                    RadioButtonFromShipType(shipType).Checked = true;
                    return;
                }
            }
            Rbtn_Remove.Checked = true;
        }

        private void UpdateRadioButtonText(Ships.ShipEnum ShipType)
        {
            switch (ShipType)
            {
                case Ships.ShipEnum.Carrier:
                    RadioButtonFromShipType(ShipType).Text = "Carrier             " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                case Ships.ShipEnum.Battleship:
                    RadioButtonFromShipType(ShipType).Text = "Battleship          " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                case Ships.ShipEnum.Cruiser:
                    RadioButtonFromShipType(ShipType).Text = "Cruiser             " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                case Ships.ShipEnum.Destroyer:
                    RadioButtonFromShipType(ShipType).Text = "Destroyer           " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                case Ships.ShipEnum.SubMarine:
                    RadioButtonFromShipType(ShipType).Text = "Submarine           " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                default:
                    throw new Exception("Invalid Ship type");
            }

            if (ShipsLeftToBePlaced(ShipType) <= 0)
            {
                RadioButtonFromShipType(ShipType).Enabled = false;
            }
            else
            {
                RadioButtonFromShipType(ShipType).Enabled = true;
            }
        }

        private void btn_Ship_Placement_Done_Click(object sender, EventArgs e)
        {

            if(CarriersLeft+BattleshipsLeft+CruisersLeft+DestroyersLeft+SubmarinesLeft != 0)
            {
                MessageBox.Show("Please place all ships before continuing", "You have ships left to be placed!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            DeleteMode = false;

            Rbtn_Remove.Enabled = false;
            btn_Ship_Placement_Done.Enabled = false;

            if (Networking.IsServer)
            {
                List<Networking.NetworkSprite> networkSprites = new List<Networking.NetworkSprite>();

                foreach (Sprite sprite in localSpriteTable)
                {
                    networkSprites.Add(new Networking.NetworkSprite(sprite, false));
                }

                Networking.NetworkServer.StaticgameLogic.HostGameBoard = localGameBoardTiles;
                Networking.NetworkServer.StaticgameLogic.HostSpriteTable = networkSprites.ToArray();

                if (Networking.NetworkServer.StaticgameLogic.OpponentDonePlacingShips)
                {
                    Task.Run(() => Networking.NetworkServer.StaticgameLogic.BothPlayersDonePlacingShips());
                }
                else
                {
                    Networking.NetworkServer.StaticgameLogic.OpponentDonePlacingShips = true;
                    lbl_Waiting_For_Opponent.Visible = true;
                }

            }
            else
            {
                List<Networking.NetworkSprite> networkSprites = new List<Networking.NetworkSprite>();

                foreach(Sprite sprite in localSpriteTable)
                {
                    networkSprites.Add(new Networking.NetworkSprite(sprite, false));
                }

                Networking.NetworkClient.RemoteServerInterface.DonePlacingShips(GetBinaryArray(networkSprites.ToArray(),true), GetBinaryArray(localGameBoardTiles, true));
                lbl_Waiting_For_Opponent.Visible = true;


            }
        }

        /// <summary>
        /// Switches the players view to the local game board if false and the opponents if true
        /// </summary>
        public void SwitchGameBoard(bool ShowOpponentsGameBoard)
        {
            if (ShowOpponentsGameBoard)
            {
                drawLocalGameBoard = false;
                pnlGameBoard.Invalidate();
                showReticle = true;
                drawTargets = true;
                pbx_Reticle.Visible = true;
                Targets = new List<Point>();
            }
            else
            {
                drawLocalGameBoard = true;
                pnlGameBoard.Invalidate();
                showReticle = false;
                drawTargets = false;
                pbx_Reticle.Visible = false;
            }
        }

        void StopUpdateTimer()
        {
            UpdateTimer.Stop();
            UpdateTimer.Tick -= UpdateEventHandler;
            UpdateTimer.Dispose();
        }


    }
}