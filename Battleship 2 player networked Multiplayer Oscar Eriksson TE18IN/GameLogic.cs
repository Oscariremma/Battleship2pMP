using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship2pMP.MDI_Forms;
using LibOscar;
using static LibOscar.Methods;

namespace Battleship2pMP
{
    public class GameLogic
    {
        public GameBoardTile[,] HostGameBoard = new GameBoardTile[9, 9];

        public GameBoardTile[,] ClientGameBoard = new GameBoardTile[9, 9];

        public Networking.NetworkSprite[] HostSpriteTable;

        public Networking.NetworkSprite[] ClientSpriteTable;

        public bool OpponentDonePlacingShips = false;

        public GameLogic()
        {
            int x = 61;
            int rowx = 0;
            int rowy = 0;
            int y = 0;
            for (int i = 0; i <= 80; i++)
            {
                HostGameBoard[rowx, rowy] = new GameBoardTile(new Rectangle(x, y, 61, 61), TileType.Water);
                ClientGameBoard[rowx, rowy] = new GameBoardTile(new Rectangle(x, y, 61, 61), TileType.Water);

                x += 61;
                if (rowx == 8)
                {
                    y += 61;
                    x = 61;
                    rowx = 0;
                    rowy++;
                }
                else
                {
                    rowx++;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        public void BothPlayersDonePlacingShips()
        {

            MDI_Game.staticGame.remoteGameBoardTiles = ClientGameBoard;
            List<MDI_Game.Sprite> clientSpriteTable = new List<MDI_Game.Sprite>();
            foreach (Networking.NetworkSprite networkSprite in ClientSpriteTable)
            {
                clientSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled));
            }
            MDI_Game.staticGame.remoteSpriteTable = clientSpriteTable;

            Networking.NetworkServer.StaticClientInterface.UpdateHostGameBoard(GetBinaryArray(HostGameBoard, true), GetBinaryArray(HostSpriteTable, true));

            //Randomly select who starts
            Random random = new Random();
            if(random.Next(2) == 0)
            {
                //Host starts
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DSwitchGameBoardView, new object[] { true });
            }
            else
            {
                //Client Starts
                Networking.NetworkServer.StaticClientInterface.SwitchGameBoard(true);
            }

        }

        public void FireShots(System.Drawing.Point[] Targets, bool IsClient)
        {
            ref GameBoardTile[,] TargetGameBoard = ref IsClient ? ref ClientGameBoard : ref HostGameBoard;

            bool ShipDestroyed = true;

            List<Point> NewHits = new List<Point>();
            List<Point> NewMisses = new List<Point>();

            foreach(Point target in Targets)
            {
                ref GameBoardTile targetTile = ref TargetGameBoard[target.X, target.Y];

                if (targetTile.TileType == TileType.Ship)
                {
                    targetTile.TileType = TileType.Hit;

                    ref Networking.NetworkSprite HitShipSprite = ref IsClient ? ref ClientSpriteTable[targetTile.SpriteID] : ref HostSpriteTable[targetTile.SpriteID];

                    foreach(Point Coveredtile in HitShipSprite.CoveredTiles)
                    {
                        if(TargetGameBoard[Coveredtile.X,Coveredtile.Y].TileType != TileType.Hit)
                        {
                            ShipDestroyed = false;
                            break;
                        }
                    }

                    HitShipSprite.Enabled = ShipDestroyed;

                }
                else
                {
                    targetTile.TileType = TileType.Miss;
                    NewMisses.Add(target);
                }
            }

        }




        [Serializable]
        public struct GameBoardTile
        {
            public GameBoardTile(Rectangle rectangle, TileType tileType)
            {
                Rectangle = rectangle;
                TileType = tileType;
                SpriteID = 0;
            }

            public Rectangle Rectangle;

            public TileType TileType;

            public int SpriteID;
        }

        public enum TileType
        {
            Water,
            Miss,
            Hit,
            Ship
        }
    }

    public enum ShipOrientation
    {
        Left, Up, Right, Down
    }
}