﻿using System;
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

        bool ClientsTurn;

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

            PushGameBoardUpdates();

            //Randomly select who starts
            Random random = new Random();
            if(random.Next(100) < 50)
            {
                //Host starts
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DSwitchGameBoardView, new object[] { true });
                Networking.NetworkServer.StaticClientInterface.SwitchGameBoard(false);
                ClientsTurn = false;
            }
            else
            {
                //Client Starts
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DSwitchGameBoardView, new object[] { false });
                Networking.NetworkServer.StaticClientInterface.SwitchGameBoard(true);
                ClientsTurn = true;
            }

        }

        public void FireShots(System.Drawing.Point[] Targets, bool TargetClient)
        {
            ref GameBoardTile[,] TargetGameBoard = ref TargetClient ? ref ClientGameBoard : ref HostGameBoard;


            foreach(Point target in Targets)
            {
                bool ShipDestroyed = true;

                ref GameBoardTile targetTile = ref TargetGameBoard[target.X, target.Y];

                if (targetTile.TileType == TileType.Ship)
                {
                    targetTile.TileType = TileType.Hit;

                    ref Networking.NetworkSprite HitShipSprite = ref TargetClient ? ref ClientSpriteTable[targetTile.SpriteID] : ref HostSpriteTable[targetTile.SpriteID];

                    foreach(Point Coveredtile in HitShipSprite.CoveredTiles)
                    {
                        if(TargetGameBoard[Coveredtile.X,Coveredtile.Y].TileType != TileType.Hit)
                        {
                            ShipDestroyed = false;
                            break;
                        }
                    }



                    if (ShipDestroyed)
                    {
                        HitShipSprite.Enabled = true;
                        HitShipSprite.ShipDestroyed = true;
                    }


                }
                else
                {
                    targetTile.TileType = TileType.Miss;
                }


            }

            PushGameBoardUpdates();

            ExecutionTimer.ExecuteAfterDelay((o, ee) => TurnDone(), 3000);

        }

        void PushGameBoardUpdates()
        {
            MDI_Game.staticGame.remoteGameBoardTiles = ClientGameBoard;
            List<MDI_Game.Sprite> clientSpriteTable = new List<MDI_Game.Sprite>();
            foreach (Networking.NetworkSprite networkSprite in ClientSpriteTable)
            {
                clientSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled, networkSprite.ShipDestroyed));
            }
            MDI_Game.staticGame.remoteSpriteTable = clientSpriteTable;

            List<MDI_Game.Sprite> hostSpriteTable = new List<MDI_Game.Sprite>();
            MDI_Game.staticGame.localGameBoardTiles = HostGameBoard;
            foreach (Networking.NetworkSprite networkSprite in HostSpriteTable)
            {
                hostSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled, networkSprite.ShipDestroyed));
            }
            MDI_Game.staticGame.localSpriteTable = hostSpriteTable;

            Networking.NetworkServer.StaticClientInterface.UpdateHostGameBoard(GetBinaryArray(HostGameBoard, true), GetBinaryArray(HostSpriteTable, true));
            Networking.NetworkServer.StaticClientInterface.UpdateClientGameBoard(GetBinaryArray(ClientGameBoard, true), GetBinaryArray(ClientSpriteTable, true));
            ReDrawGameBoards();
        }

        void ReDrawGameBoards()
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DInvalidate);
            Networking.NetworkServer.StaticClientInterface.InvalidateGameBoard();
        }

        void TurnDone()
        {
            if (ClientsTurn)
            {
                //Hosts Turn
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DSwitchGameBoardView, new object[] { true });
                Networking.NetworkServer.StaticClientInterface.SwitchGameBoard(false);
                ClientsTurn = false;
            }
            else
            {
                //Clients Turn
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DSwitchGameBoardView, new object[] { false });
                Networking.NetworkServer.StaticClientInterface.SwitchGameBoard(true);
                ClientsTurn = true;
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