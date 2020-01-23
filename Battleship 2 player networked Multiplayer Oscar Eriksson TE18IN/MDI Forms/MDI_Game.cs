using LibOscar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibOscar.Methods;

namespace Battleship2pMP.MDI_Forms
{
    public partial class MDI_Game : Form
    {
        //Pen used to draw the grid
        private readonly Pen BlackPen = new Pen(Color.Black, 3);

        /// <summary>
        /// Static reference to the current <see cref="MDI_Game"/>
        /// </summary>
        public static MDI_Game staticGame;


        #region Declare Delegate voids

        /// <summary>
        /// Updates the local version of both the local and remote game board. Redraws the game board
        /// </summary>
        /// <param name="localgameBoard">The local player's game board</param>
        /// <param name="remotegameBoard">The remote player's game board</param>
        public delegate void DelUpdateGameBoard(GameLogic.GameBoardTile[,] localgameBoard, GameLogic.GameBoardTile[,] remotegameBoard);

        /// <summary>
        /// Begins the next turn and draws the correct GemeBoard depending on <paramref name="ShowOpponentsGameBoard"/>. Also sets Targeting and reticle visibility
        /// </summary>
        /// <param name="ShowOpponentsGameBoard">Switches the players view to the local game board if false and the opponents if true</param>
        public delegate void DelBeginTurn(bool ShowOpponentsGameBoard);

        /// <summary>
        /// Invalidates the GameBoard panel casing it to be redrawn
        /// </summary>
        public delegate void DelInvalidate();

        /// <summary>
        /// Stops and disposes of the update timer
        /// </summary>
        public delegate void DelStopUpdateTimer();

        /// <summary>
        /// Updates the local score board
        /// </summary>
        public delegate void DelUpdateScoreboard(Ships.ShipsLeft LocalShipsLeft, Ships.ShipsLeft OpponentShipsLeft);

        /// <summary>
        /// Applies all of the game settings to the current game
        /// </summary>
        /// <param name="ShipsToPlace">The different amounts of ships to place</param>
        /// <param name="FirstTurnShots">How many shots should be fired on the first turn</param>
        /// <param name="ShotsPerGameTurn">How many shots should be fired on a normal turn</param>
        public delegate void DelSetGameSettings(Ships.ShipsLeft ShipsToPlace, int FirstTurnShots, int ShotsPerGameTurn);

        /// <summary>
        /// Shows the local player which tiles their opponent shot at
        /// </summary>
        /// <param name="ScreenCordTargets">The screen coordinates of the targets</param>
        public delegate void DelSetTargetsToDisplay(Point[] ScreenCordTargets);

        /// <summary>
        /// Informs the client who won the game and transfers some statistics from the game
        /// </summary>
        /// <param name="YouWon">True if the local player Won and false if their opponent won</param>
        /// <param name="YourShots">How many shots the local player fired</param>
        /// <param name="YourHits">How many shots the local player hit</param>
        /// <param name="OpponentsShots">How many shots their opponent fired</param>
        /// <param name="OpponentsHits">How many shots their opponent hit</param>
        /// <param name="Turns">How many full turns have been played</param>
        /// <param name="OpponentSurrenderd">Did the opponent surrender</param>
        public delegate void DelVictory(bool YouWon, int YourShots, int YourHits, int OpponentsShots, int OpponentsHits, double Turns, bool OpponentSurrenderd = false);

        /// <summary>
        /// Informs the local player that their opponent wants a rematch
        /// </summary>
        public delegate void DelOpponentWantsRematch();

        /// <summary>
        /// Informs the local player that their opponent has left the game
        /// </summary>
        public delegate void DelOpponentHasLeftGame();

        #endregion

        #region Declare local delegate variables

        /// <summary>
        /// Updates the local version of both the local and remote game board. Redraws the game board
        /// </summary>
        public DelUpdateGameBoard DUpdateGameBoard;

        /// <summary>
        /// Switches the players view to the local game board if false and the opponents if true. Also sets Targeting and reticle visibility
        /// </summary>
        public DelBeginTurn DBeginTurn;

        /// <summary>
        /// Invalidates the GameBoard panel casing it to be redrawn
        /// </summary>
        public DelInvalidate DInvalidate;

        /// <summary>
        /// Stops and disposes of the update timer
        /// </summary>
        public DelStopUpdateTimer DStopUpdateTimer;

        /// <summary>
        /// Updates the local score board
        /// </summary>
        public DelUpdateScoreboard DUpdateScoreboard;

        /// <summary>
        /// Applies all of the game settings to the current game
        /// </summary>
        public DelSetGameSettings DSetGameSettings;

        /// <summary>
        /// Shows the local player which tiles their opponent shot at
        /// </summary>
        public DelSetTargetsToDisplay DSetTargetsToDisplay;

        /// <summary>
        /// Informs the client who won the game and transfers some statistics from the game
        /// </summary>
        public DelVictory DVictory;

        /// <summary>
        /// Informs the local player that their opponent wants a rematch
        /// </summary>
        public DelOpponentWantsRematch DOpponentWantsRematch;

        /// <summary>
        /// Informs the local player that their opponent has left the game
        /// </summary>
        public DelOpponentHasLeftGame DOpponentHasLeftGame;

        #endregion

        private ShipOrientation orientation = ShipOrientation.Down;

        //Code generated previously in code and saved
        private readonly Rectangle[] coordinateTiles = new Rectangle[] { new Rectangle(0, 0, 61, 61), new Rectangle(0, 61, 61, 61), new Rectangle(0, 122, 61, 61), new Rectangle(0, 183, 61, 61), new Rectangle(0, 244, 61, 61), new Rectangle(0, 305, 61, 61), new Rectangle(0, 366, 61, 61), new Rectangle(0, 427, 61, 61), new Rectangle(0, 488, 61, 61), new Rectangle(0, 549, 61, 61), new Rectangle(61, 549, 61, 61), new Rectangle(122, 549, 61, 61), new Rectangle(183, 549, 61, 61), new Rectangle(244, 549, 61, 61), new Rectangle(305, 549, 61, 61), new Rectangle(366, 549, 61, 61), new Rectangle(427, 549, 61, 61), new Rectangle(488, 549, 61, 61), new Rectangle(549, 549, 61, 61) };
        private readonly Line[] GridLines = new Line[] { new Line(new Point(1, 1), new Point(1, 610)), new Line(new Point(1, 1), new Point(610, 1)), new Line(new Point(609, 1), new Point(609, 610)), new Line(new Point(1, 609), new Point(610, 609)), new Line(new Point(0, 0), new Point(610, 0)), new Line(new Point(61, 0), new Point(61, 610)), new Line(new Point(122, 0), new Point(122, 610)), new Line(new Point(183, 0), new Point(183, 610)), new Line(new Point(244, 0), new Point(244, 610)), new Line(new Point(305, 0), new Point(305, 610)), new Line(new Point(366, 0), new Point(366, 610)), new Line(new Point(427, 0), new Point(427, 610)), new Line(new Point(488, 0), new Point(488, 610)), new Line(new Point(549, 0), new Point(549, 610)), new Line(new Point(0, 61), new Point(610, 61)), new Line(new Point(0, 122), new Point(610, 122)), new Line(new Point(0, 183), new Point(610, 183)), new Line(new Point(0, 244), new Point(610, 244)), new Line(new Point(0, 305), new Point(610, 305)), new Line(new Point(0, 366), new Point(610, 366)), new Line(new Point(0, 427), new Point(610, 427)), new Line(new Point(0, 488), new Point(610, 488)), new Line(new Point(0, 549), new Point(610, 549)) };

        private bool drawLocalGameBoard = true;
        private bool showReticle = false;
        private bool drawTargets = false;

        //List of the current targets
        private List<Point> Targets;

        private bool FirstTurn = true;
        private int ShotsFirstTurn;
        private int ShotsPerTurn;

        public GameLogic.GameBoardTile[,] localGameBoardTiles = new GameLogic.GameBoardTile[0, 0];
        public GameLogic.GameBoardTile[,] remoteGameBoardTiles = new GameLogic.GameBoardTile[0, 0];

        public List<Sprite> localSpriteTable = new List<Sprite>();
        public List<Sprite> remoteSpriteTable = new List<Sprite>();

        private Ships.ShipEnum SelectedShipType;

        private bool DeleteMode = false;
        private bool OpponentHasSurrenderd = false;
        private bool HasSurrenderd = false;
        private bool Won = false;
        private bool DrawAllShipsOveride = false;

        //Ships left to place counters
        private Ships.ShipsLeft ShipsLeftToPlace;

        public Timer UpdateTimer;

        /// <summary>
        /// Class representing a ship on the game board
        /// </summary>
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

                foreach (GameLogic.GameBoardTile tile in TilesCovered)
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
                    Desposed = true;
                }
            }

            public void Dispose()
            {
                // Dispose of unmanaged resources.
                Dispose(true);
                SpriteImage.Dispose();
                // Suppress finalization.
                GC.SuppressFinalize(this);
            }

            #endregion Dispose
        }

        public MDI_Game()
        {
            InitializeComponent();
            DoubleBuffered = true;
            staticGame = this;
            this.BackgroundImage = Program.GameBackground;

            //Register delegates
            DUpdateGameBoard = new DelUpdateGameBoard(UpdateGameBoard);
            DBeginTurn = new DelBeginTurn(BeginTurn);
            DInvalidate = new DelInvalidate(pnlGameBoard.Invalidate);
            DStopUpdateTimer = new DelStopUpdateTimer(StopUpdateTimer);
            DUpdateScoreboard = new DelUpdateScoreboard(UpdateScoreboard);
            DSetGameSettings = new DelSetGameSettings(SetGameSettings);
            DVictory = new DelVictory(Victory);
            DSetTargetsToDisplay = new DelSetTargetsToDisplay(SetTargetsToDisplay);
            DOpponentWantsRematch = new DelOpponentWantsRematch(OpponentWantsRematch);
            DOpponentHasLeftGame = new DelOpponentHasLeftGame(OpponentHasLeftGame);

            //Register draw event
            pnlGameBoard.Paint += new PaintEventHandler(Draw);

            //Register various events
            pnlGameBoard.MouseWheel += new MouseEventHandler(ScrollEvent);
            pnlGameBoard.MouseClick += new MouseEventHandler(MouseClickEvent);
            pbx_Selected_Ship.MouseClick += new MouseEventHandler(MouseClickEvent);
            pbx_Reticle.MouseClick += new MouseEventHandler(MouseClickEvent);
            KeyDown += new KeyEventHandler(GameKeyDownEvent);

            //Set fonts to MilitaryFont
            Label[] CordLables = new Label[] { lbl_cord1, lbl_cord2, lbl_cord3, lbl_cord4, lbl_cord5, lbl_cord6, lbl_cord7, lbl_cord8, lbl_cord9, lbl_cordA, lbl_cordB, lbl_cordC, lbl_cordD, lbl_cordE, lbl_cordF, lbl_cordG, lbl_cordH, lbl_cordI };
            foreach (Label lbl in CordLables)
            {
                lbl.SetMilitaryFont();
            }
            Btn_Surrender.SetMilitaryFont();
            Btn_Ship_Placement_Done.SetMilitaryFont();
            Btn_SwitchGameBoard.SetMilitaryFont();
            Btn_Surrender.SetMilitaryFont();
            Btn_Rematch.SetMilitaryFont();
            Btn_LeaveGame.SetMilitaryFont();
            lbl_Victory.SetMilitaryFont();
            lbl_Defeat.SetMilitaryFont();
            lbl_OpponentsTurn.SetMilitaryFont();
            lbl_YourTurn.SetMilitaryFont();

            //Set up game "tick" Update timer
            UpdateTimer = new Timer();
            UpdateTimer.Interval = 10;
            UpdateTimer.Tick += new EventHandler(Update);
            UpdateTimer.Start();

            pbx_Selected_Ship.Image = (Image)Ships.Ship.Carrier.ShipSprite.Clone();
            SelectedShipType = Ships.ShipEnum.Carrier;

            Invalidate();


        }

        /// <summary>
        /// The main game "tick" and update function
        /// </summary>
        private void Update(object sender, EventArgs eventArgs)
        {
            try
            {
                //Mouse coordinates relative to the game Pnl
                Point pointPnl = pnlGameBoard.PointToClient(Cursor.Position);
                //Mouse coordinates in the 9*9 coordinate system
                Point point = new Point(pointPnl.X / 61 - 1, pointPnl.Y / 61);

                //Check if the cursor is within the game board
                if (point.X >= 0 && point.X <= 8 && point.Y >= 0 && point.Y <= 8 && !DeleteMode)
                {
                    if (showReticle)
                    {   //Update the location of the Reticle
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


        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !DrawAllShipsOveride)
            {
                if (!showReticle)
                {
                    if (!DeleteMode)
                    {
                        if (ShipsLeftToBePlaced(SelectedShipType) > 0)
                        {
                            //Check if it is OK to place a ship at the cursors current position and rotation

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

                            //Set the ShipType to Ship and set the SpriteID of all covered tiles
                            foreach (Point tilePoint in newShipTiles)
                            {
                                localGameBoardTiles[tilePoint.X, tilePoint.Y].TileType = GameLogic.TileType.Ship;
                                localGameBoardTiles[tilePoint.X, tilePoint.Y].SpriteID = localSpriteTable.Count;
                            }

                            //Add the new sprite to the Sprite table
                            localSpriteTable.Add(new Sprite(SelectedShipType, orientation, pbx_Selected_Ship.Location, TilesCovered.ToArray()));

                            //Update ship counters
                            ref int ShipsLeft = ref ShipsLeftToBePlaced(SelectedShipType);
                            ShipsLeft--;
                            UpdateRadioButtonText(SelectedShipType);
                            if (ShipsLeft <= 0)
                            {
                                OutOfCurrentShipType();
                            }
                        }
                        else
                        {
                            //Select a ship type with ships left to place
                            OutOfCurrentShipType();
                        }
                    }
                    else
                    {

                        //Delete the ship under the cursor

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

                    //Add ship to targets

                    Point Reticle_Cord = new Point(((pbx_Reticle.Location.X + 10) / 61) - 1, (pbx_Reticle.Location.Y + 10) / 61);

                    //Check that the tile the Player is firring on is a Ship or Water tile
                    if (remoteGameBoardTiles[Reticle_Cord.X, Reticle_Cord.Y].TileType == GameLogic.TileType.Ship || remoteGameBoardTiles[Reticle_Cord.X, Reticle_Cord.Y].TileType == GameLogic.TileType.Water)
                    {
                        ref int ShotsThisTurn = ref FirstTurn ? ref ShotsFirstTurn : ref ShotsPerTurn;

                        Targets.Add(pbx_Reticle.Location);

                        //Check if it is time to actually fire and send the targets to the host/GameLogic
                        if (Targets.Count >= ShotsThisTurn)
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
                                Networking.NetworkServer.StaticgameLogic.FireShots(CordTargets.ToArray(), Targets.ToArray(), true);
                            }
                            else
                            {
                                Networking.NetworkClient.RemoteServerInterface.FireShots(CordTargets.ToArray(), Targets.ToArray());
                            }

                            FirstTurn = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Triggered by the mouse scroll event. Rotates ships
        /// </summary>
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

        //Triggered when a key is pressed. Enables rotation of ships using the arrow keys
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

        /// <summary>
        /// The main draw function of the game board
        /// </summary>
        private void Draw(object sender, PaintEventArgs e)
        {
            //Reference the correct GameBoad and SpriteTable depending on what game board to draw
            ref GameLogic.GameBoardTile[,] gameBoardDrawRef = ref drawLocalGameBoard ? ref localGameBoardTiles : ref remoteGameBoardTiles;
            ref List<Sprite> spriteTableDrawRef = ref drawLocalGameBoard ? ref localSpriteTable : ref remoteSpriteTable;

            List<Rectangle> DestroyedShipsRects = new List<Rectangle>();

            e.Graphics.FillRectangles(Brushes.DarkTurquoise, coordinateTiles);
            //Draw the game board tiles
            foreach (GameLogic.GameBoardTile tile in gameBoardDrawRef)
            {
                switch (tile.TileType)
                {
                    case GameLogic.TileType.Water:
                        e.Graphics.DrawImage(Program.Water, tile.Rectangle.Location);
                        break;

                    case GameLogic.TileType.Hit:
                        e.Graphics.DrawImage(Program.HitFire, tile.Rectangle.Location);
                        //Register all destroyed and enabled ships
                        if (spriteTableDrawRef[tile.SpriteID].ShipDestroyed && spriteTableDrawRef[tile.SpriteID].Enabled)
                        {
                            DestroyedShipsRects.Add(tile.Rectangle);
                        }
                        break;

                    case GameLogic.TileType.Miss:
                        e.Graphics.DrawImage(Program.MissWaterFoam, tile.Rectangle.Location);
                        break;

                    case GameLogic.TileType.Ship:
                        e.Graphics.DrawImage(Program.Water, tile.Rectangle.Location);
                        break;
                }
            }
            //Draw the grid lines on the game board
            DrawLinesFromArray(e.Graphics, BlackPen, GridLines);

            //Draw all enabled ships
            foreach (Sprite sprite in spriteTableDrawRef)
            {
                if (sprite.Enabled || DrawAllShipsOveride)
                {
                    e.Graphics.DrawImage(sprite.SpriteImage, sprite.Location);
                }
            }

            //Draws the targets markers
            if (drawTargets)
            {
                foreach (Point TargetPoint in Targets)
                {
                    e.Graphics.DrawImage(Program.Red_Reticle, TargetPoint);
                }
            }

            //Draw an X over all destroyed ship tiles
            foreach (Rectangle ShipRect in DestroyedShipsRects)
            {
                e.Graphics.DrawLine(BlackPen, ShipRect.X, ShipRect.Y, ShipRect.X + 61, ShipRect.Y + 61);
                e.Graphics.DrawLine(BlackPen, ShipRect.X + 61, ShipRect.Y, ShipRect.X, ShipRect.Y + 61);
            }
        }


        #region Buttons

            //Radio buttons for switching ship type
            #region Radio Buttons
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
            #endregion

        //Indicate that the player is done with placing all of their ships
        private void Btn_Ship_Placement_Done_Click(object sender, EventArgs e)
        {
            //Make sure that the player has placed all of their ships
            if (ShipsLeftToPlace.Total != 0)
            {
                MessageBox.Show("Please place all ships before continuing", "You have ships left to be placed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DeleteMode = false;

            Rbtn_Remove.Enabled = false;
            Btn_Ship_Placement_Done.Enabled = false;

            //Send the new GameBoard and sprite table to the Host/GameLogic
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

                foreach (Sprite sprite in localSpriteTable)
                {
                    networkSprites.Add(new Networking.NetworkSprite(sprite, false));
                }

                Networking.NetworkClient.RemoteServerInterface.DonePlacingShips(networkSprites.ToArray(), GetBinaryArray(localGameBoardTiles, true));
                lbl_Waiting_For_Opponent.Visible = true;
            }
        }

        //Surrenders
        private void Btn_Surrender_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to surrender?", "Surrender?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            HasSurrenderd = true;
            if (Networking.IsServer)
            {
                Networking.NetworkServer.StaticgameLogic.Surrender(true);
            }
            else
            {
                Networking.NetworkClient.RemoteServerInterface.Surrender();
            }
        }

        //Leaves the game
        private void Btn_LeaveGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to leave the game?", "Leave Game?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (!MDI_Container.OpponentHasLeftGame)
            {
                if (Networking.IsServer)
                {
                    Networking.NetworkServer.StaticgameLogic.LeaveGame(true);
                }
                else
                {
                    Networking.NetworkClient.RemoteServerInterface.LeaveGame();
                }
            }

            MDI_Container.staticMdi_Container.BeginInvoke(MDI_Container.staticMdi_Container.DLeaveGame);
        }

        //Requests a rematch
        private void Btn_Rematch_Click(object sender, EventArgs e)
        {
            lbl_WaitingForRematch.Visible = true;

            if (Networking.IsServer)
            {
                Networking.NetworkServer.StaticgameLogic.Rematch(true);
            }
            else
            {
                Networking.NetworkClient.RemoteServerInterface.Rematch();
            }
        }

        //Switch game board
        private void Btn_SwitchGameBoard_Click(object sender, EventArgs e)
        {
            if (drawLocalGameBoard)
            {
                SwitchGameBoardView(true, !(OpponentHasSurrenderd || HasSurrenderd) && Won);
                Btn_SwitchGameBoard.Text = "View Your Game Board";
            }
            else
            {
                SwitchGameBoardView(false, !(OpponentHasSurrenderd || HasSurrenderd) && !Won);
                Btn_SwitchGameBoard.Text = "View Opponents Game Board";
            }
        }

        #endregion

        /// <summary>
        /// Applies all of the game settings to the current game
        /// </summary>
        /// <param name="ShipsToPlace">The different amounts of ships to place</param>
        /// <param name="FirstTurnShots">How many shots should be fired on the first turn</param>
        /// <param name="ShotsPerGameTurn">How many shots should be fired on a normal turn</param>
        public void SetGameSettings(Ships.ShipsLeft ShipsToPlace, int FirstTurnShots, int ShotsPerGameTurn)
        {
            ShipsLeftToPlace = ShipsToPlace;
            //Update all of the radio buttons
            foreach (Ships.ShipEnum ShipType in (Ships.ShipEnum[])Enum.GetValues(typeof(Ships.ShipEnum)))
            {
                UpdateRadioButtonText(ShipType);
            }
            OutOfCurrentShipType();

            ShotsFirstTurn = FirstTurnShots;
            ShotsPerTurn = ShotsPerGameTurn;
        }

        /// <summary>
        /// Updates the local version of both the local and remote game board. Redraws the game board
        /// </summary>
        /// <param name="localgameBoard">The local player's game board</param>
        /// <param name="remotegameBoard">The remote player's game board</param>
        public void UpdateGameBoard(GameLogic.GameBoardTile[,] localgameBoard, GameLogic.GameBoardTile[,] remotegameBoard)
        {
            localGameBoardTiles = localgameBoard;
            remoteGameBoardTiles = remotegameBoard;
            pnlGameBoard.Invalidate();
        }




        /// <summary>
        /// Rotates the currently selected ship in the pbx_Selected_Ship
        /// </summary>
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




        /// <summary>
        /// Get a referenced int of how many ships are left to be placed of <paramref name="ShipType"/>
        /// </summary>
        /// <param name="ShipType">The ship type</param>
        /// <returns></returns>
        private ref int ShipsLeftToBePlaced(Ships.ShipEnum ShipType)
        {
            switch (ShipType)
            {
                case Ships.ShipEnum.Carrier:
                    return ref ShipsLeftToPlace.Carriers;

                case Ships.ShipEnum.Battleship:
                    return ref ShipsLeftToPlace.Battleships;

                case Ships.ShipEnum.Cruiser:
                    return ref ShipsLeftToPlace.Cruisers;

                case Ships.ShipEnum.Destroyer:
                    return ref ShipsLeftToPlace.Destroyers;

                case Ships.ShipEnum.SubMarine:
                    return ref ShipsLeftToPlace.Submarines;

                default:
                    throw new Exception("Invalid Ship type");
            }
        }

        /// <summary>
        /// Get the radio button corresponding to the given <paramref name="ShipType"/>
        /// </summary>
        /// <param name="ShipType">The ship type</param>
        /// <returns></returns>
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

        /// <summary>
        /// Select a ship type with ships left to place
        /// </summary>
        private void OutOfCurrentShipType()
        {
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

        /// <summary>
        /// Updates the text on the radio button corresponding to the provided <paramref name="ShipType"/>
        /// </summary>
        /// <param name="ShipType">The Ship Type</param>
        private void UpdateRadioButtonText(Ships.ShipEnum ShipType)
        {
            switch (ShipType)
            {
                case Ships.ShipEnum.Carrier:
                    RadioButtonFromShipType(ShipType).Text = "Carrier             " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                case Ships.ShipEnum.Battleship:
                    RadioButtonFromShipType(ShipType).Text = "Battleship        " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                case Ships.ShipEnum.Cruiser:
                    RadioButtonFromShipType(ShipType).Text = "Cruiser             " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                case Ships.ShipEnum.Destroyer:
                    RadioButtonFromShipType(ShipType).Text = "Destroyer         " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                case Ships.ShipEnum.SubMarine:
                    RadioButtonFromShipType(ShipType).Text = "Submarine       " + ShipsLeftToBePlaced(ShipType).ToString() + " Left";
                    break;

                default:
                    throw new Exception("Invalid Ship type");
            }

            //Disable the button if their are no more of the provided ShipType to place
            if (ShipsLeftToBePlaced(ShipType) <= 0)
            {
                RadioButtonFromShipType(ShipType).Enabled = false;
            }
            else
            {
                RadioButtonFromShipType(ShipType).Enabled = true;
            }
        }



        /// <summary>
        /// Begins the next turn and draws the correct GemeBoard depending on <paramref name="ShowOpponentsGameBoard"/>. Also sets Targeting and reticle visibility
        /// </summary>
        /// <param name="ShowOpponentsGameBoard">Switches the players view to the local game board if false and the opponents if true</param>
        public void BeginTurn(bool ShowOpponentsGameBoard)
        {
            if (MDI_Container.GameIsFinished) return;

            if (ShowOpponentsGameBoard)
            {
                drawLocalGameBoard = false;
                lbl_WhosGameBoard.Text = "Opponents Game Board";
                pnlGameBoard.Invalidate();
                showReticle = true;
                drawTargets = true;
                pbx_Reticle.Visible = true;
                Targets = new List<Point>();
                lbl_YourTurn.Visible = true;
                lbl_OpponentsTurn.Visible = false;
            }
            else
            {
                drawLocalGameBoard = true;
                lbl_WhosGameBoard.Text = "Your Game Board";
                pnlGameBoard.Invalidate();
                showReticle = false;
                drawTargets = false;
                pbx_Reticle.Visible = false;
                lbl_YourTurn.Visible = false;
                lbl_OpponentsTurn.Visible = true;
            }
        }

        /// <summary>
        /// Switches the players view depending on <paramref name="ShowOpponentsGameBoard"/>. Only draw targets if <paramref name="ShowTargets"/> is true
        /// </summary>
        /// <param name="ShowOpponentsGameBoard">Switches the players view to the local game board if false and the opponents if true.</param>
        /// <param name="ShowTargets">Draw targets if true</param>
        public void SwitchGameBoardView(bool ShowOpponentsGameBoard, bool ShowTargets)
        {
            if (ShowOpponentsGameBoard)
            {
                drawLocalGameBoard = false;
                lbl_WhosGameBoard.Text = "Opponents Game Board";
                pnlGameBoard.Invalidate();
                drawTargets = ShowTargets;
            }
            else
            {
                drawLocalGameBoard = true;
                lbl_WhosGameBoard.Text = "Your Game Board";
                pnlGameBoard.Invalidate();
                drawTargets = ShowTargets;
            }
        }

        /// <summary>
        /// Stops and disposes of the update timer
        /// </summary>
        private void StopUpdateTimer()
        {
            UpdateTimer.Stop();
            UpdateTimer.Dispose();
        }


        /// <summary>
        /// Updates the local score board
        /// </summary>
        private void UpdateScoreboard(Ships.ShipsLeft LocalShipsLeft, Ships.ShipsLeft OpponentShipsLeft)
        {
            if (pnl_PlaceShips.Visible == true)
            {
                pnl_PlaceShips.Visible = false;
                pnl_PlaceShips.Enabled = false;
                pnl_ScoreBoard.Visible = true;
                pnl_ScoreBoard.Enabled = true;
            }

            lbl_Carrier_You.Text = LocalShipsLeft.Carriers.ToString();
            lbl_Carrier_Op.Text = OpponentShipsLeft.Carriers.ToString();

            lbl_Battleship_You.Text = LocalShipsLeft.Battleships.ToString();
            lbl_Battleship_Op.Text = OpponentShipsLeft.Battleships.ToString();

            lbl_Cruiser_You.Text = LocalShipsLeft.Cruisers.ToString();
            lbl_Cruiser_Op.Text = OpponentShipsLeft.Cruisers.ToString();

            lbl_Destroyer_You.Text = LocalShipsLeft.Destroyers.ToString();
            lbl_Destroyer_Op.Text = OpponentShipsLeft.Destroyers.ToString();

            lbl_Submarine_You.Text = LocalShipsLeft.Submarines.ToString();
            lbl_Submarine_Op.Text = OpponentShipsLeft.Submarines.ToString();

            lbl_Total_You.Text = LocalShipsLeft.Total.ToString();
            lbl_Total_Op.Text = OpponentShipsLeft.Total.ToString();
        }

        /// <summary>
        /// Shows the local player which tiles their opponent shot at
        /// </summary>
        /// <param name="ScreenCordTargets">The screen coordinates of the targets</param>
        public void SetTargetsToDisplay(Point[] ScreenCordTargets)
        {
            Targets = new List<Point>();
            Targets.AddRange(ScreenCordTargets);
            drawTargets = true;
        }

        /// <summary>
        /// Informs the client who won the game and transfers some statistics from the game
        /// </summary>
        /// <param name="YouWon">True if the local player Won and false if their opponent won</param>
        /// <param name="YourShots">How many shots the local player fired</param>
        /// <param name="YourHits">How many shots the local player hit</param>
        /// <param name="OpponentsShots">How many shots their opponent fired</param>
        /// <param name="OpponentsHits">How many shots their opponent hit</param>
        /// <param name="Turns">How many full turns have been played</param>
        /// <param name="OpponentSurrenderd">Did the opponent surrender</param>
        public void Victory(bool YouWon, int YourShots, int YourHits, int OpponentsShots, int OpponentsHits, double Turns, bool OpponentSurrenderd = false)
        {
            Won = YouWon;
            OpponentHasSurrenderd = OpponentSurrenderd;
            DrawAllShipsOveride = true;
            pbx_Selected_Ship.Visible = false;
            showReticle = false;
            pbx_Reticle.Visible = false;
            MDI_Container.GameIsFinished = true;

            if (YouWon)
            {
                lbl_Victory.Visible = true;
            }
            else
            {
                lbl_Defeat.Visible = true;
            }

            if (OpponentSurrenderd || HasSurrenderd) drawTargets = false;

            lbl_OpSurrenderd.Visible = OpponentSurrenderd;
            lbl_YouSurrenderd.Visible = HasSurrenderd;

            lbl_You_ShotsFired.Text = YourShots.ToString();
            lbl_You_Hits.Text = YourHits.ToString();
            lbl_You_Accuracy.Text = YourShots == 0 ? "N/A" : Math.Round((double)(YourHits * 100) / YourShots).ToString() + "%";

            lbl_Opponent_ShotsFired.Text = OpponentsShots.ToString();
            lbl_Opponent_Hits.Text = OpponentsHits.ToString();
            lbl_Opponent_Accuracy.Text = OpponentsShots == 0 ? "N/A" : Math.Round((double)(OpponentsHits * 100) / OpponentsShots).ToString() + "%";

            lbl_Turns.Text = Turns.ToString("N1") + " turns played";

            Btn_Surrender.Visible = false;

            pnl_ScoreBoard.Visible = false;
            pnl_GameOver.Visible = true;

            pnlGameBoard.Invalidate();
        }

        /// <summary>
        /// Informs the local player that their opponent has left the game
        /// </summary>
        public void OpponentHasLeftGame()
        {
            lbl_OpLeftGame.Visible = true;
            Btn_Rematch.Enabled = false;
            lbl_OpWantsRematch.Visible = false;
        }

        /// <summary>
        /// Informs the local player that their opponent wants a rematch
        /// </summary>
        public void OpponentWantsRematch()
        {
            lbl_OpWantsRematch.Visible = true;
        }
    }
}