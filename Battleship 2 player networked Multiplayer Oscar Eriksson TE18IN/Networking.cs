using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using static LibOscar.Methods;
using Battleship2pMP.MDI_Forms;

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
            public GameLogic.GameBoardTile[] CoveredTiles;
            public ShipOrientation ShipOrientation;
            public bool Enabled;

            public NetworkSprite(MDI_Game.Sprite sprite)
            {
                ShipType = sprite.ShipType.ShipEnum;
                Location = sprite.Location;
                CoveredTiles = sprite.CoveredTiles;
                ShipOrientation = sprite.ShipOrientation;
                Enabled = sprite.Enabled;
            }

            public NetworkSprite(MDI_Game.Sprite sprite, bool EnabelOverride)
            {
                ShipType = sprite.ShipType.ShipEnum;
                Location = sprite.Location;
                CoveredTiles = sprite.CoveredTiles;
                ShipOrientation = sprite.ShipOrientation;
                Enabled = EnabelOverride;
            }

        }

        // The servers RPC interface with functions called from the client
        public interface IServerInterface
        {
            void StartGame();

            void DonePlacingShips(byte[] ClientNetworkSprites, byte[] ClientGameBoard);

            void FireShots(System.Drawing.Point[] Target);


            void LeaveGame();
        }

        // The clients RPC interface with functions called from the server
        public interface IClientInterface
        {
            void GameStarting(byte[] gameBoardTilesBinary);

            /// <summary>
            /// Switches the clients view to their local game board if false and their opponents if true
            /// </summary>
            void SwitchGameBoard(bool ShowClietsGameBoard);

            /// <summary>
            /// Updates the map of the hosts game board including sprite table on the client instance
            /// </summary>
            void UpdateHostGameBoard(byte[] HostGameBoardBinaryArray, byte[] HostNetworkSpriteTableBinaryArray);

            void LeaveGame();
        }

        // Derived class of the server interface containing the actual functions
        private class ServerInterfaceClass : IServerInterface
        {

            public void StartGame()
            {
                Task.Run(InitializeGame);
            }

            Task InitializeGame()
            {
                IsServer = true;
                MDI_Container.staticMdi_Container.Invoke(MDI_Container.DSwitchMDI, new object[] { MDI_Form_Enum.MDI_Game, true });
                NetworkServer.StaticgameLogic = new GameLogic();
                NetworkServer.StaticClientInterface.GameStarting(GetBinaryArray(NetworkServer.StaticgameLogic.ClientGameBoard, true));
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateGameBoard, new object[] { NetworkServer.StaticgameLogic.HostGameBoard });
                return null;
            }

            public void DonePlacingShips(byte[] ClientNetworkSprites, byte[] ClientGameBoardByteAray)
            {
                NetworkServer.StaticgameLogic.ClientSpriteTable = GetObjectFromBinaryArray<NetworkSprite[]>(ClientNetworkSprites,true);

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

            public void FireShots(System.Drawing.Point[] Targets)
            {
                NetworkServer.StaticgameLogic.FireShots(Targets, true);
            }


            public void LeaveGame()
            {
            }
        }

        // Derived class of the client interface containing the actual functions
        private class ClientInterfaceClass : IClientInterface
        {
            public void GameStarting(byte[] gameBoardTilesBinary)
            {
                IsServer = false;
                MDI_Container.staticMdi_Container.Invoke(MDI_Container.DSwitchMDI, new object[] { MDI_Form_Enum.MDI_Game, true });
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DUpdateGameBoard, new object[] { GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(gameBoardTilesBinary, true) });
            }

            /// <summary>
            /// Switches the clients view to their local game board if false and their opponents if true
            /// </summary>
            public void SwitchGameBoard(bool ShowClietsGameBoard)
            {
                MDI_Game.staticGame.Invoke(MDI_Game.staticGame.DSwitchGameBoardView, new object[] { ShowClietsGameBoard });
            }

            /// <summary>
            /// Updates the map of the hosts game board including sprite table on the client instance
            /// </summary>
            public void UpdateHostGameBoard(byte[] HostGameBoardBinaryArray, byte[] HostNetworkSpriteTableBinaryArray)
            {
                MDI_Game.staticGame.remoteGameBoardTiles = GetObjectFromBinaryArray<GameLogic.GameBoardTile[,]>(HostGameBoardBinaryArray, true);
                List<MDI_Game.Sprite> hostSpriteTable = new List<MDI_Game.Sprite>();
                foreach(NetworkSprite networkSprite in GetObjectFromBinaryArray<NetworkSprite[]>(HostNetworkSpriteTableBinaryArray, true))
                {
                    hostSpriteTable.Add(new MDI_Game.Sprite(networkSprite.ShipType, networkSprite.ShipOrientation, networkSprite.Location, networkSprite.CoveredTiles, networkSprite.Enabled));
                }
                MDI_Game.staticGame.remoteSpriteTable = hostSpriteTable;
            }

            public void LeaveGame()
            {
            }
        }

        public static class NetworkServer
        {
            public static IClientInterface StaticClientInterface;

            public static GameLogic StaticgameLogic;

            public static bool ServerListening = false;

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

                //Set the RPC server to use the newly established connection with the client
                RemoteProcedureCalls.Server.serverConnection = connection;

                //Register a instance of the server interface and make it available to the client via RPC
                RemoteProcedureCalls.Server.RegisterInstanceForPublicRemoteCall<ServerInterfaceClass, IServerInterface>(new ServerInterfaceClass(), "Server");
                //Get the clients RPC interface
                StaticClientInterface = RemoteProcedureCalls.Client.CreateProxyToPublicNamedInstance<IClientInterface>(connection, "Client", out string instanceId, new SendReceiveOptions<ProtobufSerializer>());
                //Send a command to the client to tell it to connect to the servers RPC
                connection.SendObject<string>("Initialize-Connection", "");
            }
        }

        public static class NetworkClient
        {
            public static IServerInterface RemoteServerInterface;

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

                //Register incoming packet handler for setting up RPC from the server
                NetworkComms.AppendGlobalIncomingPacketHandler<string>("Initialize-Connection", InitializeServerRPC);
                //Set the RPC server to use the newly established connection with the server
                RemoteProcedureCalls.Server.serverConnection = connection;
                //Register a instance of the clients interface and make it available to the server via RPC
                RemoteProcedureCalls.Server.RegisterInstanceForPublicRemoteCall<ClientInterfaceClass, IClientInterface>(new ClientInterfaceClass(), "Client");
                //Send a command to the server to tell it to connect to the clients RPC
                connection.SendObject<string>("Initialize-Connection", "");
                mdi_Join.Invoke(MDI_Forms.MDI_Join.DJoinResult, new object[] { true });
            }

            public static void InitializeServerRPC(PacketHeader header, Connection connection, string message)
            {
                //Remove the handler that called this function
                NetworkComms.RemoveGlobalIncomingPacketHandler<string>("Initialize-Connection", InitializeServerRPC);
                //Get the servers RPC interface
                RemoteServerInterface = RemoteProcedureCalls.Client.CreateProxyToPublicNamedInstance<IServerInterface>(connection, "Server", out string s, new SendReceiveOptions<ProtobufSerializer>());
            }
        }
    }
}