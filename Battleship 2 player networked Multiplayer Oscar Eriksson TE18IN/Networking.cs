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
using ProtoBuf;
using static LibOscar.Methods;
using LibOscar;
namespace Battleship2pMP
{
    public class Networking
    {
        public static bool IsServer;

        /// <summary>
        /// Networked version of the MDI_Form.Sprite class
        /// </summary>
        [ProtoContract(SkipConstructor = true, ImplicitFields = ImplicitFields.AllFields)]
        public class NetworkSprite
        {
            [ProtoMember(1)]
            public Ships.ShipEnum ShipType;
            [ProtoMember(2)]
            public System.Drawing.Point Location;
            [ProtoMember(3)]
            public System.Drawing.Point[] CoveredTiles;
            [ProtoMember(4)]
            public ShipOrientation ShipOrientation;
            [ProtoMember(5)]
            public bool Enabled;
            [ProtoMember(6)]
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
            /// <summary>
            /// Start the game
            /// </summary>
            void StartGame();

            /// <summary>
            /// Called when the client is done placing their ships
            /// </summary>
            /// <param name="ClientNetworkSprites">Array containing all of the Clients sprites</param>
            /// <param name="ClientGameBoard">Byte array of the Clients game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            void DonePlacingShips(NetworkSprite[] ClientNetworkSprites, byte[] ClientGameBoard);

            /// <summary>
            /// Fire on the host
            /// </summary>
            /// <param name="Targets">The <see cref="System.Drawing.Point"/>'s to fire on</param>
            /// <param name="ScreenCordTargets">The screen coordinates of targets <see cref="System.Drawing.Point"/>'s to show to the opponent</param>
            void FireShots(System.Drawing.Point[] Targets, System.Drawing.Point[] ScreenCordTargets);

            /// <summary>
            /// Surrender causes the host to win instantly
            /// </summary>
            void Surrender();

            /// <summary>
            /// Requests a rematch
            /// </summary>
            void Rematch();

            /// <summary>
            /// Informs the host that the client is leaving the game
            /// </summary>
            void LeaveGame();

        }

        // The clients RPC interface with functions called from the server
        public interface IClientInterface
        {
            /// <summary>
            /// Initializes the clients game
            /// </summary>
            /// <param name="ClientGameBoardTilesBinary">Byte array of the Clients game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            /// <param name="HostGameBoardTilesBinary">Byte array of the Host's game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            /// <param name="ShipsToPlace">How many ships to place</param>
            /// <param name="ShotsFirstTurn">How many shots should be fired on the first turn</param>
            /// <param name="ShotsPerTurn">How many shots should be fired each normal turn</param>
            void GameStarting(byte[] ClientGameBoardTilesBinary, byte[] HostGameBoardTilesBinary, Ships.ShipsLeft ShipsToPlace, int ShotsFirstTurn, int ShotsPerTurn);

            /// <summary>
            /// Begins the next turn
            /// </summary>
            /// <param name="ShowClietsGameBoard">Switches the clients view to their local game board if false and their opponents if true</param>
            void BeginTurn(bool ShowClietsGameBoard);

            /// <summary>
            /// Updates the map of the hosts game board including sprite table on the client instance
            /// </summary>
            /// <param name="HostGameBoardBinaryArray">Byte array of the Host's game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            /// <param name="HostNetworkSpriteTable">The host's sprite table in <see cref="NetworkSprite"/> form</param>
            void UpdateHostGameBoard(byte[] HostGameBoardBinaryArray, NetworkSprite[] HostNetworkSpriteTable);

            /// <summary>
            /// Updates the map of the clients game board including sprite table on the client instance
            /// </summary>
            /// <param name="HostGameBoardBinaryArray">Byte array of the Client's game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            /// <param name="HostNetworkSpriteTable">The Client's sprite table in <see cref="NetworkSprite"/> form</param>
            void UpdateClientGameBoard(byte[] HostGameBoardBinaryArray, NetworkSprite[] HostNetworkSpriteTable);

            /// <summary>
            /// Redraw the clients game board
            /// </summary>
            void InvalidateGameBoard();

            /// <summary>
            /// Update the clients scoreboard
            /// </summary>
            void UpdateScoreboard(Ships.ShipsLeft LocalShipsLeft, Ships.ShipsLeft OpponentShipsLeft);

            /// <summary>
            /// Shows the client which tiles the host shot at
            /// </summary>
            /// <param name="ScreenCordTargets">The screen coordinates of the targets</param>
            void SetTargetsToDisplay(System.Drawing.Point[] ScreenCordTargets);

            /// <summary>
            /// Informs the client who won the game and transfers some statistics from the game
            /// </summary>
            /// <param name="ClientWon">True if the Client Won and false if the Host won</param>
            /// <param name="ClientsShots">How many shots the client fired</param>
            /// <param name="ClientsHits">How many shots the client hit</param>
            /// <param name="HostsShots">How many shots the host fired</param>
            /// <param name="HostsHits">How many shots the host hit</param>
            /// <param name="Turns">How many full turns have been played</param>
            /// <param name="OpponentSurrenderd">Did the opponent surrender</param>
            void Victory(bool ClientWon, int ClientsShots, int ClientsHits, int HostsShots, int HostsHits, double Turns, bool OpponentSurrenderd = false);

            /// <summary>
            /// Informs the client that the host is leaving the game
            /// </summary>
            void HostLeftGame();

            /// <summary>
            /// Informs the client that the host wants a rematch
            /// </summary>
            void OpponentWantsRematch();

        }

        // Derived class of the server interface containing the actual functions
        private class ServerInterfaceClass : IServerInterface
        {
            /// <summary>
            /// Start the game
            /// </summary>
            public void StartGame()
            {
                Task.Run(NetworkServer.InitializeGame);
            }

            /// <summary>
            /// Called when the client is done placing their ships
            /// </summary>
            /// <param name="ClientNetworkSprites">Array containing all of the Clients sprites</param>
            /// <param name="ClientGameBoard">Byte array of the Clients game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            public void DonePlacingShips(NetworkSprite[] ClientNetworkSprites, byte[] ClientGameBoardByteAray)
            {
                NetworkServer.StaticgameLogic.ClientSpriteTable = ClientNetworkSprites;

                NetworkServer.StaticgameLogic.ClientGameBoard = GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(ClientGameBoardByteAray);

                if (NetworkServer.StaticgameLogic.OpponentDonePlacingShips)
                {
                    Task.Run(() => NetworkServer.StaticgameLogic.BothPlayersDonePlacingShips());
                }
                else
                {
                    NetworkServer.StaticgameLogic.OpponentDonePlacingShips = true;
                }
            }

            /// <summary>
            /// Fire on the host
            /// </summary>
            /// <param name="Targets">The <see cref="System.Drawing.Point"/>'s to fire on</param>
            /// <param name="ScreenCordTargets">The screen coordinates of targets <see cref="System.Drawing.Point"/>'s to show to the opponent</param>
            public void FireShots(System.Drawing.Point[] Targets, System.Drawing.Point[] ScreenCordTargets)
            {
                NetworkServer.StaticgameLogic.FireShots(Targets, ScreenCordTargets, false);
            }

            /// <summary>
            /// Surrender causes the host to win instantly
            /// </summary>
            public void Surrender()
            {
                NetworkServer.StaticgameLogic.Surrender(false);
            }

            /// <summary>
            /// Requests a rematch
            /// </summary>
            public void Rematch()
            {
                NetworkServer.StaticgameLogic.Rematch(false);
            }

            /// <summary>
            /// Informs the host that the client is leaving the game
            /// </summary>
            public void LeaveGame()
            {
                NetworkServer.StaticgameLogic.LeaveGame(false);
            }
        }

        // Derived class of the client interface containing the actual functions
        private class ClientInterfaceClass : IClientInterface
        {
            /// <summary>
            /// Initializes the clients game
            /// </summary>
            /// <param name="ClientGameBoardTilesBinary">Byte array of the Clients game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            /// <param name="HostGameBoardTilesBinary">Byte array of the Host's game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            /// <param name="ShipsToPlace">How many ships to place</param>
            /// <param name="ShotsFirstTurn">How many shots should be fired on the first turn</param>
            /// <param name="ShotsPerTurn">How many shots should be fired each normal turn</param>
            public void GameStarting(byte[] ClientGameBoardTilesBinary, byte[] HostGameBoardTilesBinary, Ships.ShipsLeft ShipsToPlace, int ShotsFirstTurn, int ShotsPerTurn)
            {
                IsServer = false;
                MDI_Container.GameIsFinished = false;
                MDI_Container.staticMdi_Container.Invoke(MDI_Container.DSwitchMDI, new object[] { MDI_Form_Enum.MDI_Game, true });
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DSetGameSettings, new object[] { ShipsToPlace, ShotsFirstTurn, ShotsPerTurn });
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateGameBoard, new object[] { GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(ClientGameBoardTilesBinary), GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(HostGameBoardTilesBinary) });
            }

            /// <summary>
            /// Begins the next turn
            /// </summary>
            /// <param name="ShowClietsGameBoard">Switches the clients view to their local game board if false and their opponents if true</param>
            public void BeginTurn(bool ShowClietsGameBoard)
            {
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DBeginTurn, new object[] { ShowClietsGameBoard });
            }

            /// <summary>
            /// Updates the map of the hosts game board including sprite table on the client instance
            /// </summary>
            /// <param name="HostGameBoardBinaryArray">Byte array of the Host's game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            /// <param name="HostNetworkSpriteTable">The host's sprite table in <see cref="NetworkSprite"/> form</param>
            public void UpdateHostGameBoard(byte[] HostGameBoardBinaryArray, NetworkSprite[] HostNetworkSpriteTable)
            {
                MDI_Game.staticGame.remoteGameBoardTiles = GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(HostGameBoardBinaryArray);
                List<MDI_Game.Sprite> hostSpriteTable = new List<MDI_Game.Sprite>();
                foreach (NetworkSprite networkSprite in HostNetworkSpriteTable)
                {
                    hostSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled, networkSprite.ShipDestroyed));
                }
                MDI_Game.staticGame.remoteSpriteTable = hostSpriteTable;
            }

            /// <summary>
            /// Updates the map of the clients game board including sprite table on the client instance
            /// </summary>
            /// <param name="HostGameBoardBinaryArray">Byte array of the Client's game board converted using <see cref="LibOscar.Methods.GetBinaryArray{T}(T, bool)"/></param>
            /// <param name="HostNetworkSpriteTable">The Client's sprite table in <see cref="NetworkSprite"/> form</param>
            public void UpdateClientGameBoard(byte[] ClientGameBoardBinaryArray, NetworkSprite[] ClientNetworkSpriteTable)
            {
                MDI_Game.staticGame.localGameBoardTiles = GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(ClientGameBoardBinaryArray);
                List<MDI_Game.Sprite> clientSpriteTable = new List<MDI_Game.Sprite>();
                foreach (NetworkSprite networkSprite in ClientNetworkSpriteTable)
                {
                    clientSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled, networkSprite.ShipDestroyed));
                }
                MDI_Game.staticGame.localSpriteTable = clientSpriteTable;
            }

            /// <summary>
            /// Redraw the clients game board
            /// </summary>
            public void InvalidateGameBoard()
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DInvalidate);
            }

            /// <summary>
            /// Update the clients scoreboard
            /// </summary>
            public void UpdateScoreboard(Ships.ShipsLeft LocalShipsLeft, Ships.ShipsLeft OpponentShipsLeft)
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateScoreboard, new object[] { LocalShipsLeft, OpponentShipsLeft });
            }

            /// <summary>
            /// Shows the client which tiles the host shot at
            /// </summary>
            /// <param name="ScreenCordTargets">The screen coordinates of the targets</param>
            public void SetTargetsToDisplay(System.Drawing.Point[] ScreenCordTargets)
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DSetTargetsToDisplay, new object[] { ScreenCordTargets });
            }

            /// <summary>
            /// Informs the client who won the game and transfers some statistics from the game
            /// </summary>
            /// <param name="ClientWon">True if the Client Won and false if the Host won</param>
            /// <param name="ClientsShots">How many shots the client fired</param>
            /// <param name="ClientsHits">How many shots the client hit</param>
            /// <param name="HostsShots">How many shots the host fired</param>
            /// <param name="HostsHits">How many shots the host hit</param>
            /// <param name="Turns">How many full turns have been played</param>
            /// <param name="OpponentSurrenderd">Did the opponent surrender</param>
            public void Victory(bool ClientWon, int ClientsShots, int ClientsHits, int HostsShots, int HostsHits, double Turns, bool OpponentSurrenderd = false)
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DVictory, new object[] { ClientWon, ClientsShots, ClientsHits, HostsShots, HostsHits, Turns, OpponentSurrenderd });
            }

            /// <summary>
            /// Informs the client that the host is leaving the game
            /// </summary>
            public void HostLeftGame()
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DOpponentHasLeftGame);
                MDI_Container.OpponentHasLeftGame = true;
            }

            /// <summary>
            /// Informs the client that the host wants a rematch
            /// </summary>
            public void OpponentWantsRematch()
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DOpponentWantsRematch);
            }
        }

        /// <summary>
        /// Network RPC Server/Host side
        /// </summary>
        public static class NetworkServer
        {
            /// <summary>
            /// A static reference to the clients remote interface
            /// </summary>
            public static IClientInterface StaticClientInterface;

            /// <summary>
            /// A static reference to the games current instance of the GameLogic class
            /// </summary>
            public static GameLogic StaticgameLogic;

            /// <summary>
            /// Indicates whether the server is listening for new TCP connections
            /// </summary>
            public static bool ServerListening = false;

            /// <summary>
            /// The current RPC instance's ID
            /// </summary>
            public static string RPCInstanceID;

            /// <summary>
            /// Initializes the entire game and game logic on the host's side and starts the clients game initialization.
            /// </summary>
            public static Task InitializeGame()
            {
                IsServer = true;
                MDI_Container.GameIsFinished = false;
                MDI_Container.staticMdi_Container.Invoke(MDI_Container.DSwitchMDI, new object[] { MDI_Form_Enum.MDI_Game, true });
                NetworkServer.StaticgameLogic = new GameLogic();
                NetworkServer.StaticClientInterface.GameStarting(GetBinaryArray(NetworkServer.StaticgameLogic.ClientGameBoard, true), GetBinaryArray(NetworkServer.StaticgameLogic.HostGameBoard, true), NetworkServer.StaticgameLogic.ClientShipsLeft, Settings.Default.ShotsFirstTurn, Settings.Default.ShotsPerTurn);
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateGameBoard, new object[] { NetworkServer.StaticgameLogic.HostGameBoard, NetworkServer.StaticgameLogic.ClientGameBoard });
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DSetGameSettings, new object[] { NetworkServer.StaticgameLogic.HostShipsLeft, Settings.Default.ShotsFirstTurn, Settings.Default.ShotsPerTurn });
                return null;
            }

            /// <summary>
            /// Starts the RPC server and starts listening for connections. Returns a string array containing all opened endpoints
            /// </summary>
            /// <param name="port">The port the server will listen on</param>
            /// <returns></returns>
            public static string[] StartServer(int port)
            {
                //Register incoming packet handler for setting up RPC from client
                NetworkComms.AppendGlobalIncomingPacketHandler<string>("Initialize-Connection", GetConnection);

                //Start listening for TCP connections on all interfaces and the port specified in the port var
                Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, port));

                ServerListening = true;

                List<string> IPList = new List<string>();

                //Gather a list of all local endpoint's
                foreach (IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
                {
                    IPList.Add(localEndPoint.Address.ToString());
                }

                return IPList.ToArray();
            }

            /// <summary>
            /// Stop listening for new connections
            /// </summary>
            public static void StopServerListener()
            {
                //Stop listening for connections
                Connection.StopListening();
                //Remove the handler that called this function
                NetworkComms.RemoveGlobalIncomingPacketHandler<string>("Initialize-Connection", GetConnection);

                ServerListening = false;
            }

            //Called when the client sends a "Initialize-Connection" message to the server. Set's up all RPC on the host/server side
            static void GetConnection(PacketHeader header, Connection connection, string message)
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

        /// <summary>
        /// Network RPC client side
        /// </summary>
        public static class NetworkClient
        {

            /// <summary>
            /// A static reference to the servers remote interface
            /// </summary>
            public static IServerInterface RemoteServerInterface;

            /// <summary>
            /// The current RPC instance's ID
            /// </summary>
            public static string RPCInstanceID;

            /// <summary>
            /// Try to connect to the server/host
            /// </summary>
            /// <param name="connectionInfo">The IP and port to try to connect to</param>
            public static void ConnectToServer(ConnectionInfo connectionInfo)
            {
                Connection connection;

                //Try to connect to the server using TCP
                try
                {
                    connection = TCPConnection.GetConnection(connectionInfo);
                }
                //Catch any connection error and send an error message
                catch
                {
                    MDI_Container.staticMdi_Container.mdi_Join.Invoke(MDI_Forms.MDI_Join.DJoinResult, new object[] { false });
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

            /// <summary>
            /// Initializes RPC. Called when receiving a "Initialize-Connection" message
            /// </summary>
            static void InitializeServerRPC(PacketHeader header, Connection connection, string message)
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

        /// <summary>
        /// Shutdown all networking and RPC
        /// </summary>
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