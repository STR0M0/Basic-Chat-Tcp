using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;


namespace Server
{
    class ChatServer
    {
        private const int PORT = 500;
        private Dictionary<string, TcpClient> userToConnections = new Dictionary<string, TcpClient>();
        TcpListener tcpListener;
        NetworkStream stream;

        /// <summary>
        /// Default constructor
        /// </summary>
        public static void Main()
        {
            ChatServer server = new ChatServer();
        }

        /// <summary>
        /// Listens for data from clients 
        /// </summary>
        public ChatServer()
        {
            tcpListener = TcpListener.Create(PORT);
            tcpListener.Start();
            while (true)
            {
                //check if there are any pending connection requests
                if (tcpListener.Pending())
                {
                    //if there are pending requests create a new connection
                    TcpClient chatConnection = tcpListener.AcceptTcpClient();
                    Console.WriteLine("Connected");
                    ReceiveUser(chatConnection);
                    ReceiveMsg(chatConnection);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public void ReceiveUser(TcpClient connection)
        {
            stream = connection.GetStream();

            if (stream.CanRead)
            {
                string userName = Decode(stream, connection);
                userToConnections.Add(userName, connection);
                userToConnections.Add(userName, connection);
                Console.WriteLine(userName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ReceiveMsg(TcpClient connection)
        {
            stream = connection.GetStream();

            if (stream.CanRead)
            {
                string msg = Decode(stream, connection);
                string userName = getUserNameForConnection(connection);
                Console.WriteLine(userName + msg);
            }

        }

        /// <summary>
        /// Matches the connection to the username that is sending information to the server
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        private string getUserNameForConnection(TcpClient connection) {
            string userName = null;
            foreach (KeyValuePair<string, TcpClient> entry in userToConnections) {
                if (connection.Equals(entry.Value)) {
                    userName = entry.Key;
                    break;
                }
            }
            return userName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public static void SendUserToAll(string user)
        {
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="msg"></param>
        public static void SendMsgToAll(string user, string msg)
        {
        
        }
        
        /// <summary>
        /// Decodes the network stream into it's ASCII values and returns the results as a string
        /// </summary>
        public string Decode(NetworkStream stream, TcpClient connection)
        {
            byte[] bytes = new byte[connection.ReceiveBufferSize];
            Int32 numBytes = stream.Read(bytes, 0, connection.ReceiveBufferSize);
            string data = Encoding.ASCII.GetString(bytes, 0, numBytes);
            return data;
        }
    }
}
        //private async void ListenForClientConnections()
        //{
        //    //start the chat server
        //    //if there are pending requests create a new connection
        //    TcpClient chatConnection = await chatServer.AcceptTcpClientAsync();
        //    Console.WriteLine("Connected");
        //    ReceiveUser(chatConnection);
        //    ReceiveMsg(chatConnection);
        //}
