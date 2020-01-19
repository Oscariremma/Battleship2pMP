using Battleship2pMP.MDI_Forms;
using LibOscar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using static LibOscar.Methods;

namespace Battleship2pMP
{
    public class GameLogic
    {
        public GameBoardTile[,] HostGameBoard = new GameBoardTile[9, 9];

        public GameBoardTile[,] ClientGameBoard = new GameBoardTile[9, 9];

        public Networking.NetworkSprite[] HostSpriteTable;

        public Networking.NetworkSprite[] ClientSpriteTable;

        public Ships.ShipsLeft HostShipsLeft;

        public Ships.ShipsLeft ClientShipsLeft;

        public bool OpponentDonePlacingShips = false;

        private bool ClientsTurn;
        private bool RematchRequested = false;

        private int PostTurnDelay;

        private double CompleteTurns;

        private int HostShots;
        private int HostHits;

        private int ClientShots;
        private int ClientHits;

        public GameLogic()
        {
            HostShipsLeft = new Ships.ShipsLeft(Properties.Settings.Default.Carriers, Properties.Settings.Default.Battleships, Properties.Settings.Default.Cruisers, Properties.Settings.Default.Destroyers, Properties.Settings.Default.Submarines);
            PostTurnDelay = Properties.Settings.Default.PostTurnDelay;
            ClientShipsLeft = HostShipsLeft;

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
            UpdateScoreboards();

            //Randomly select who starts
            Random random = new Random();
            if (random.Next(100) < 50)
            {
                //Host starts
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DBeginTurn, new object[] { true });
                Networking.NetworkServer.StaticClientInterface.BeginTurn(false);
                ClientsTurn = false;
            }
            else
            {
                //Client Starts
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DBeginTurn, new object[] { false });
                Networking.NetworkServer.StaticClientInterface.BeginTurn(true);
                ClientsTurn = true;
            }
        }

        public void FireShots(System.Drawing.Point[] Targets, Point[] ScreenCordTargets, bool TargetClient)
        {
            ref GameBoardTile[,] TargetGameBoard = ref TargetClient ? ref ClientGameBoard : ref HostGameBoard;

            ref Ships.ShipsLeft TargetShipCounter = ref TargetClient ? ref ClientShipsLeft : ref HostShipsLeft;

            ref int StatisticsShots = ref TargetClient ? ref HostShots : ref ClientShots;

            ref int StatisticsHits = ref TargetClient ? ref HostHits : ref ClientHits;

            foreach (Point target in Targets)
            {
                bool ShipDestroyed = true;

                StatisticsShots++;

                ref GameBoardTile targetTile = ref TargetGameBoard[target.X, target.Y];

                if (targetTile.TileType == TileType.Ship)
                {
                    targetTile.TileType = TileType.Hit;

                    StatisticsHits++;

                    ref Networking.NetworkSprite HitShipSprite = ref TargetClient ? ref ClientSpriteTable[targetTile.SpriteID] : ref HostSpriteTable[targetTile.SpriteID];

                    foreach (Point Coveredtile in HitShipSprite.CoveredTiles)
                    {
                        if (TargetGameBoard[Coveredtile.X, Coveredtile.Y].TileType != TileType.Hit)
                        {
                            ShipDestroyed = false;
                            break;
                        }
                    }

                    if (ShipDestroyed)
                    {
                        HitShipSprite.Enabled = true;
                        HitShipSprite.ShipDestroyed = true;

                        switch (HitShipSprite.ShipType)
                        {
                            case Ships.ShipEnum.Carrier:
                                TargetShipCounter.Carriers--;
                                break;

                            case Ships.ShipEnum.Battleship:
                                TargetShipCounter.Battleships--;
                                break;

                            case Ships.ShipEnum.Cruiser:
                                TargetShipCounter.Cruisers--;
                                break;

                            case Ships.ShipEnum.Destroyer:
                                TargetShipCounter.Destroyers--;
                                break;

                            case Ships.ShipEnum.SubMarine:
                                TargetShipCounter.Submarines--;
                                break;
                        }

                        UpdateScoreboards();
                    }
                }
                else
                {
                    targetTile.TileType = TileType.Miss;
                }
            }

            if (TargetClient)
            {
                Networking.NetworkServer.StaticClientInterface.SetTargetsToDisplay(GetBinaryArray(ScreenCordTargets));
            }
            else
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DSetTargetsToDisplay, new object[] { ScreenCordTargets });
            }

            PushGameBoardUpdates();

            if (TargetShipCounter.Total == 0)
            {
                Victory(TargetClient);
            }
            else
            {
                ExecutionTimer.ExecuteAfterDelay((o, ee) => TurnDone(), PostTurnDelay);
            }

            CompleteTurns += 0.5d;
        }

        private void PushGameBoardUpdates()
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

        private void ReDrawGameBoards()
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DInvalidate);
            Networking.NetworkServer.StaticClientInterface.InvalidateGameBoard();
        }

        private void UpdateScoreboards()
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateScoreboard, new object[] { HostShipsLeft, ClientShipsLeft });
            Networking.NetworkServer.StaticClientInterface.UpdateScoreboard(ClientShipsLeft, HostShipsLeft);
        }

        private void TurnDone()
        {
            if (ClientsTurn)
            {
                //Hosts Turn
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DBeginTurn, new object[] { true });
                Networking.NetworkServer.StaticClientInterface.BeginTurn(false);
                ClientsTurn = false;
            }
            else
            {
                //Clients Turn
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DBeginTurn, new object[] { false });
                Networking.NetworkServer.StaticClientInterface.BeginTurn(true);
                ClientsTurn = true;
            }
        }

        private void Victory(bool HostWon)
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DVictory, new object[] { HostWon, HostShots, HostHits, ClientShots, ClientHits, CompleteTurns, false });
            Networking.NetworkServer.StaticClientInterface.Victory(!HostWon, ClientShots, ClientHits, HostShots, HostHits, CompleteTurns);
        }

        public void Surrender(bool HostSurrenderd)
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DVictory, new object[] { !HostSurrenderd, HostShots, HostHits, ClientShots, ClientHits, CompleteTurns, !HostSurrenderd });
            Networking.NetworkServer.StaticClientInterface.Victory(HostSurrenderd, ClientShots, ClientHits, HostShots, HostHits, CompleteTurns, HostSurrenderd);
        }

        public void Rematch(bool HostWantsRematch)
        {
            if (!RematchRequested)
            {
                RematchRequested = true;
                if (HostWantsRematch)
                {
                    Networking.NetworkServer.StaticClientInterface.OpponentWantsRematch();
                }
                else
                {
                    MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DOpponentWantsRematch);
                }
            }
            else
            {
                Task.Run(Networking.NetworkServer.InitializeGame);
            }
        }

        public void LeaveGame(bool HostLeftGame)
        {
            if (HostLeftGame)
            {
                Networking.NetworkServer.StaticClientInterface.HostLeftGame();
            }
            else
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DOpponentHasLeftGame);
                MDI_Container.OpponentHasLeftGame = true;
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