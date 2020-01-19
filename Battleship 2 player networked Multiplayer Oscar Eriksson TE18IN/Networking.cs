using Battleship2pMP.MDI_Forms;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibOscar.Methods;

namespace Battleship2pMP
{
    public class Networking
    {
        public static bool IsServer;

        [Serializable]
        public class NetworkSprite
        {
            public Ships.ShipEnum ShipType;
            public System.Drawing.Point Location;
            public System.Drawing.Point[] CoveredTiles;
            public ShipOrientation ShipOrientation;
            public bool Enabled;
            public bool ShipDestroyed;

            public NetworkSprite(MDI_Game.Sprite sprite)
            {
                ShipType = sprite.ShipType.ShipEnum;
                Location = sprite.Location;
                CoveredTiles = sprite.CoveredTileCords;
                ShipOrientation = sprite.ShipOrientation;
                Enabled = sprite.Enabled;
                ShipDestroyed = sprite.ShipDestroyed;
            }

            public NetworkSprite(MDI_Game.Sprite sprite, bool EnabelOverride)
            {
                ShipType = sprite.ShipType.ShipEnum;
                Location = sprite.Location;
                CoveredTiles = sprite.CoveredTileCords;
                ShipOrientation = sprite.ShipOrientation;
                Enabled = EnabelOverride;
                ShipDestroyed = sprite.ShipDestroyed;
            }
        }

        // The servers RPC interface with functions called from the client
        public interface IServerInterface
        {
            void StartGame();

            void DonePlacingShips(byte[] ClientNetworkSprites, byte[] ClientGameBoard);

            void FireShots(byte[] TargetsBinaryArray, byte[] ScreenCordTargets);

            void Surrender();

            void Rematch();

            void LeaveGame();
        }

        // The clients RPC interface with functions called from the server
        public interface IClientInterface
        {
            void GameStarting(byte[] ClientGameBoardTilesBinary, byte[] HostGameBoardTilesBinary, Ships.ShipsLeft ShipsToPlace, int ShotsFirstTurn, int ShotsPerTurn);

            /// <summary>
            /// Switches the clients view to their local game board if false and their opponents if true
            /// </summary>
            void BeginTurn(bool ShowClietsGameBoard);

            /// <summary>
            /// Updates the map of the hosts game board including sprite table on the client instance
            /// </summary>
            void UpdateHostGameBoard(byte[] HostGameBoardBinaryArray, byte[] HostNetworkSpriteTableBinaryArray);

            /// <summary>
            /// Updates the map of the clients game board including sprite table on the client instance
            /// </summary>
            void UpdateClientGameBoard(byte[] HostGameBoardBinaryArray, byte[] HostNetworkSpriteTableBinaryArray);

            void InvalidateGameBoard();

            void UpdateScoreboard(Ships.ShipsLeft LocalShipsLeft, Ships.ShipsLeft OpponentShipsLeft);

            void SetTargetsToDisplay(byte[] ScreenCordTargetsBinaryArray);

            void Victory(bool ClientWon, int ClientsShots, int ClientsHits, int HostsShots, int HostsHits, double Turns, bool OpponentSurrenderd = false);

            void HostLeftGame();

            void OpponentWantsRematch();
        }

        // Derived class of the server interface containing the actual functions
        private class ServerInterfaceClass : IServerInterface
        {
            public void StartGame()
            {
                Task.Run(NetworkServer.InitializeGame);
            }

            public void DonePlacingShips(byte[] ClientNetworkSprites, byte[] ClientGameBoardByteAray)
            {
                NetworkServer.StaticgameLogic.ClientSpriteTable = GetObjectFromBinaryArray<NetworkSprite[]>(ClientNetworkSprites, true);

                NetworkServer.StaticgameLogic.ClientGameBoard = GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(ClientGameBoardByteAray, true);

                if (NetworkServer.StaticgameLogic.OpponentDonePlacingShips)
                {
                    Task.Run(() => NetworkServer.StaticgameLogic.BothPlayersDonePlacingShips());
                }
                else
                {
                    NetworkServer.StaticgameLogic.OpponentDonePlacingShips = true;
                }
            }

            public void FireShots(byte[] TargetsBinaryArray, byte[] ScreenCordTargets)
            {
                Console.WriteLine(TargetsBinaryArray.Length);
                NetworkServer.StaticgameLogic.FireShots(GetObjectFromBinaryArray<System.Drawing.Point[]>(TargetsBinaryArray), GetObjectFromBinaryArray<System.Drawing.Point[]>(ScreenCordTargets), false);
            }

            public void Surrender()
            {
                Task.Run(() => NetworkServer.StaticgameLogic.Surrender(false));
            }

            public void Rematch()
            {
                NetworkServer.StaticgameLogic.Rematch(false);
            }

            public void LeaveGame()
            {
                NetworkServer.StaticgameLogic.LeaveGame(false);
            }
        }

        // Derived class of the client interface containing the actual functions
        private class ClientInterfaceClass : IClientInterface
        {
            public void GameStarting(byte[] ClientGameBoardTilesBinary, byte[] HostGameBoardTilesBinary, Ships.ShipsLeft ShipsToPlace, int ShotsFirstTurn, int ShotsPerTurn)
            {
                IsServer = false;
                MDI_Container.GameIsFinished = false;
                MDI_Container.staticMdi_Container.Invoke(MDI_Container.DSwitchMDI, new object[] { MDI_Form_Enum.MDI_Game, true });
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DSetGameSettings, new object[] { ShipsToPlace, ShotsFirstTurn, ShotsPerTurn });
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateGameBoard, new object[] { GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(ClientGameBoardTilesBinary, true), GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(HostGameBoardTilesBinary, true) });
            }

            /// <summary>
            /// Switches the players view to the local game board if false and the opponents if true. Also sets Targeting and reticle visibility
            /// </summary>
            public void BeginTurn(bool ShowClietsGameBoard)
            {
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DBeginTurn, new object[] { ShowClietsGameBoard });
            }

            /// <summary>
            /// Updates the map of the hosts game board including sprite table on the client instance
            /// </summary>
            public void UpdateHostGameBoard(byte[] HostGameBoardBinaryArray, byte[] HostNetworkSpriteTableBinaryArray)
            {
                MDI_Game.staticGame.remoteGameBoardTiles = GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(HostGameBoardBinaryArray, true);
                List<MDI_Game.Sprite> hostSpriteTable = new List<MDI_Game.Sprite>();
                foreach (NetworkSprite networkSprite in GetObjectFromBinaryArray<NetworkSprite[]>(HostNetworkSpriteTableBinaryArray, true))
                {
                    hostSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled, networkSprite.ShipDestroyed));
                }
                MDI_Game.staticGame.remoteSpriteTable = hostSpriteTable;
            }

            /// <summary>
            /// Updates the map of the clients game board including sprite table on the client instance
            /// </summary>
            public void UpdateClientGameBoard(byte[] ClientGameBoardBinaryArray, byte[] ClientNetworkSpriteTableBinaryArray)
            {
                MDI_Game.staticGame.localGameBoardTiles = GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(ClientGameBoardBinaryArray, true);
                List<MDI_Game.Sprite> clientSpriteTable = new List<MDI_Game.Sprite>();
                foreach (NetworkSprite networkSprite in GetObjectFromBinaryArray<NetworkSprite[]>(ClientNetworkSpriteTableBinaryArray, true))
                {
                    clientSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled, networkSprite.ShipDestroyed));
                }
                MDI_Game.staticGame.localSpriteTable = clientSpriteTable;
            }

            public void InvalidateGameBoard()
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DInvalidate);
            }

            public void UpdateScoreboard(Ships.ShipsLeft LocalShipsLeft, Ships.ShipsLeft OpponentShipsLeft)
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateScoreboard, new object[] { LocalShipsLeft, OpponentShipsLeft });
            }

            public void SetTargetsToDisplay(byte[] ScreenCordTargetsBinaryArray)
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DSetTargetsToDisplay, new object[] { GetObjectFromBinaryArray<System.Drawing.Point[]>(ScreenCordTargetsBinaryArray) });
            }

            public void Victory(bool ClientWon, int ClientsShots, int ClientsHits, int HostsShots, int HostsHits, double Turns, bool OpponentSurrenderd = false)
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DVictory, new object[] { ClientWon, ClientsShots, ClientsHits, HostsShots, HostsHits, Turns, OpponentSurrenderd });
            }

            public void HostLeftGame()
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DOpponentHasLeftGame);
                MDI_Container.OpponentHasLeftGame = true;
            }

            public void OpponentWantsRematch()
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DOpponentWantsRematch);
            }
        }

        public static class NetworkServer
        {
            public static IClientInterface StaticClientInterface;

            public static GameLogic StaticgameLogic;

            public static bool ServerListening = false;

            public static string RPCInstanceID;

            public static Task InitializeGame()
            {
                IsServer = true;
                MDI_Container.GameIsFinished = false;
                MDI_Container.staticMdi_Container.Invoke(MDI_Container.DSwitchMDI, new object[] { MDI_Form_Enum.MDI_Game, true });
                NetworkServer.StaticgameLogic = new GameLogic();
                NetworkServer.StaticClientInterface.GameStarting(GetBinaryArray(NetworkServer.StaticgameLogic.ClientGameBoard, true), GetBinaryArray(NetworkServer.StaticgameLogic.HostGameBoard, true), NetworkServer.StaticgameLogic.ClientShipsLeft, Properties.Settings.Default.ShotsFirstTurn, Properties.Settings.Default.ShotsPerTurn);
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateGameBoard, new object[] { NetworkServer.StaticgameLogic.HostGameBoard, NetworkServer.StaticgameLogic.ClientGameBoard });
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DSetGameSettings, new object[] { NetworkServer.StaticgameLogic.HostShipsLeft, Properties.Settings.Default.ShotsFirstTurn, Properties.Settings.Default.ShotsPerTurn });
                return null;
            }

            public static string[] StartServer(int port)
            {
                //Register incoming packet handler for setting up RPC from client
                NetworkComms.AppendGlobalIncomingPacketHandler<string>("Initialize-Connection", GetConnection);

                //Start listening for TCP connections on all interfaces and the port specified in the port var
                Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, port));

                ServerListening = true;

                List<string> IPList = new List<string>();

                foreach (IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
                {
                    IPList.Add(localEndPoint.Address.ToString());
                }

                return IPList.ToArray();
            }

            public static void StopServerListener()
            {
                //Stop listening for connections
                Connection.StopListening();
                //Remove the handler that called this function
                NetworkComms.RemoveGlobalIncomingPacketHandler<string>("Initialize-Connection", GetConnection);

                ServerListening = false;
            }

            //Called when the client sends a "Initialize-Connection" message to the server
            public static void GetConnection(PacketHeader header, Connection connection, string message)
            {
                StopServerListener();

                //Add a event handler to handle a shutdown of the connection
                connection.AppendShutdownHandler(new NetworkComms.ConnectionEstablishShutdownDelegate((c) => MDI_Container.staticMdi_Container.BeginInvoke(MDI_Container.staticMdi_Container.DLostConnection)));

                //Set the RPC server to use the newly established connection with the client
                RemoteProcedureCalls.Server.serverConnection = connection;

                //Register a instance of the server interface and make it available to the client via RPC
                RemoteProcedureCalls.Server.RegisterInstanceForPublicRemoteCall<ServerInterfaceClass, IServerInterface>(new ServerInterfaceClass(), "Server");
                //Get the clients RPC interface
                StaticClientInterface = RemoteProcedureCalls.Client.CreateProxyToPublicNamedInstance<IClientInterface>(connection, "Client", out RPCInstanceID, new SendReceiveOptions<ProtobufSerializer>());
                //Send a command to the client to tell it to connect to the servers RPC
                connection.SendObject<string>("Initialize-Connection", "");
            }
        }

        public static class NetworkClient
        {
            public static IServerInterface RemoteServerInterface;

            public static string RPCInstanceID;

            public static void ConnectToServer(ConnectionInfo connectionInfo, Control mdi_Join)
            {
                Connection connection;

                //Connect to the server using TCP
                try
                {
                    connection = TCPConnection.GetConnection(connectionInfo);
                }
                catch
                {
                    mdi_Join.Invoke(MDI_Forms.MDI_Join.DJoinResult, new object[] { false });
                    return;
                }

                //Add a event handler to handle a shutdown of the connection
                connection.AppendShutdownHandler(new NetworkComms.ConnectionEstablishShutdownDelegate((c) => MDI_Container.staticMdi_Container.BeginInvoke(MDI_Container.staticMdi_Container.DLostConnection)));
                //Register incoming packet handler for setting up RPC from the server
                NetworkComms.AppendGlobalIncomingPacketHandler<string>("Initialize-Connection", InitializeServerRPC);
                //Set the RPC server to use the newly established connection with the server
                RemoteProcedureCalls.Server.serverConnection = connection;
                //Register a instance of the clients interface and make it available to the server via RPC
                RemoteProcedureCalls.Server.RegisterInstanceForPublicRemoteCall<ClientInterfaceClass, IClientInterface>(new ClientInterfaceClass(), "Client");
                //Send a command to the server to tell it to connect to the clients RPC
                connection.SendObject<string>("Initialize-Connection", "");
            }

            public static void InitializeServerRPC(PacketHeader header, Connection connection, string message)
            {
                //Add a event handler to handle a shutdown of the connection
                connection.AppendShutdownHandler(new NetworkComms.ConnectionEstablishShutdownDelegate((c) => MDI_Container.staticMdi_Container.BeginInvoke(MDI_Container.staticMdi_Container.DLostConnection)));
                //Remove the handler that called this function
                NetworkComms.RemoveGlobalIncomingPacketHandler<string>("Initialize-Connection", InitializeServerRPC);
                //Get the servers RPC interface
                RemoteServerInterface = RemoteProcedureCalls.Client.CreateProxyToPublicNamedInstance<IServerInterface>(connection, "Server", out RPCInstanceID, new SendReceiveOptions<ProtobufSerializer>());
                MDI_Container.staticMdi_Container.mdi_Join.Invoke(MDI_Forms.MDI_Join.DJoinResult, new object[] { true });
            }
        }

        public static void ShutdownAllNetworking()
        {
            RemoteProcedureCalls.Server.ShutdownAllRPC();
            if (IsServer && NetworkServer.StaticClientInterface != null)
            {
                RemoteProcedureCalls.Client.DestroyRPCClient(NetworkServer.StaticClientInterface as RemoteProcedureCalls.IRPCProxy);
            }
            else if (NetworkClient.RemoteServerInterface != null)
            {
                RemoteProcedureCalls.Client.DestroyRPCClient(NetworkClient.RemoteServerInterface as RemoteProcedureCalls.IRPCProxy);
            }
            NetworkComms.Shutdown();
            RemoteProcedureCalls.Server.serverConnection = null;
        }
    }
}