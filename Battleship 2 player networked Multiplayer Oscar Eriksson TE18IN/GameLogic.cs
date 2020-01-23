using Battleship2pMP.MDI_Forms;
using LibOscar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using ProtoBuf;
using static LibOscar.Methods;

namespace Battleship2pMP
{
    /// <summary>
    /// Contains the games main overarching logic. Acts as the game master
    /// </summary>
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

        /// <summary>
        /// The delay after a player have finished their round, primarily hear to let the players see what ships where hit
        /// </summary>
        private int PostTurnDelay;

        //Statistics
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

            //Generate the game boards
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

        /// <summary>
        /// Starts the shooting part of the game when both players have placed all of their ships
        /// </summary>
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

        /// <summary>
        /// Check if there are any hits and checks if some one won that turn
        /// </summary>
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

                    //Check if the entire ship is destroyed
                    foreach (Point Coveredtile in HitShipSprite.CoveredTiles)
                    {
                        if (TargetGameBoard[Coveredtile.X, Coveredtile.Y].TileType != TileType.Hit)
                        {
                            ShipDestroyed = false;
                            break;
                        }
                    }

                    //Enable drawing of a destroyed ship and update the ShipCounter
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

            //Show where the other player where the player who shot aimed
            if (TargetClient)
            {
                Networking.NetworkServer.StaticClientInterface.SetTargetsToDisplay(ScreenCordTargets);
            }
            else
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DSetTargetsToDisplay, new object[] { ScreenCordTargets });
            }

            PushGameBoardUpdates();

            //Check if any one won
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

        /// <summary>
        /// Updates both players game boards and sprite tables and then redraws their game boards
        /// </summary>
        private void PushGameBoardUpdates()
        {
            MDI_Game.staticGame.remoteGameBoardTiles = ClientGameBoard;
            List<MDI_Game.Sprite> clientSpriteTable = new List<MDI_Game.Sprite>();
            //Convert the NetworkSprites to normal Sprites
            foreach (Networking.NetworkSprite networkSprite in ClientSpriteTable)
            {
                clientSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled, networkSprite.ShipDestroyed));
            }
            MDI_Game.staticGame.remoteSpriteTable = clientSpriteTable;

            List<MDI_Game.Sprite> hostSpriteTable = new List<MDI_Game.Sprite>();
            MDI_Game.staticGame.localGameBoardTiles = HostGameBoard;
            //Convert the NetworkSprites to normal Sprites
            foreach (Networking.NetworkSprite networkSprite in HostSpriteTable)
            {
                hostSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled, networkSprite.ShipDestroyed));
            }
            MDI_Game.staticGame.localSpriteTable = hostSpriteTable;

            Networking.NetworkServer.StaticClientInterface.UpdateHostGameBoard(GetBinaryArray(HostGameBoard, true), HostSpriteTable);
            Networking.NetworkServer.StaticClientInterface.UpdateClientGameBoard(GetBinaryArray(ClientGameBoard, true), ClientSpriteTable);
            ReDrawGameBoards();
        }

        /// <summary>
        /// Invalidates both players game boards
        /// </summary>
        private void ReDrawGameBoards()
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DInvalidate);
            Networking.NetworkServer.StaticClientInterface.InvalidateGameBoard();
        }

        /// <summary>
        /// Updates both players score counters
        /// </summary>
        private void UpdateScoreboards()
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateScoreboard, new object[] { HostShipsLeft, ClientShipsLeft });
            Networking.NetworkServer.StaticClientInterface.UpdateScoreboard(ClientShipsLeft, HostShipsLeft);
        }

        /// <summary>
        /// Ends the current turn and begins the next
        /// </summary>
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

        /// <summary>
        /// Declares the victor and informs the players of who won
        /// </summary>
        private void Victory(bool HostWon)
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DVictory, new object[] { HostWon, HostShots, HostHits, ClientShots, ClientHits, CompleteTurns, false });
            Networking.NetworkServer.StaticClientInterface.Victory(!HostWon, ClientShots, ClientHits, HostShots, HostHits, CompleteTurns);
        }

        /// <summary>
        /// Called when a player wants to surrender
        /// </summary>
        public void Surrender(bool HostSurrenderd)
        {
            MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DVictory, new object[] { !HostSurrenderd, HostShots, HostHits, ClientShots, ClientHits, CompleteTurns, !HostSurrenderd });
            Networking.NetworkServer.StaticClientInterface.Victory(HostSurrenderd, ClientShots, ClientHits, HostShots, HostHits, CompleteTurns, HostSurrenderd);
        }

        /// <summary>
        /// Requests a rematch and if a rematch already have been requested, starts a new game
        /// </summary>
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

        /// <summary>
        /// Informs the other player that their opponent is leaving the game
        /// </summary>
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
        /// <summary>
        /// Struct representing a tile on the game board
        /// </summary>
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

        /// <summary>
        /// Specifies what type of tile a GameBoardTile is
        /// </summary>
        public enum TileType
        {
            Water,
            Miss,
            Hit,
            Ship
        }
    }
    [ProtoContract]
    /// <summary>
    /// Represents a direction
    /// </summary>
    public enum ShipOrientation
    {
        [ProtoEnum(Name = "Left", Value = 0)]
        Left,
        [ProtoEnum(Name = "Up", Value = 1)]
        Up,
        [ProtoEnum(Name = "Right", Value = 2)]
        Right,
        [ProtoEnum(Name = "Down", Value = 3)]
        Down
    }
}