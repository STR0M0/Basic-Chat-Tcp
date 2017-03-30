using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ChatServer
    {
        TcpListener chatServer;
        NetworkStream stream;

        private const int PORT = 500;

        private Dictionary<string, TcpClient> userToConnections = new Dictionary<string, TcpClient>();

        /// <summary>
        /// 
        /// </summary>
        public static void Main()
        {
            ChatServer server = new ChatServer();
        }

        /// <summary>
        /// 
        /// </summary>
        public ChatServer()
        {
            chatServer = TcpListener.Create(PORT);
            chatServer.Start();
            while (true)
            {

                //check if there are any pending connection requests
                if (chatServer.Pending())
                {
                    //if there are pending requests create a new connection
                    TcpClient chatConnection = chatServer.AcceptTcpClient();
                    Console.WriteLine("Connected");
                    ReceiveUser(chatConnection);
                    ReceiveMsg(chatConnection);
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

        //Create new class 
        //Create method for encoding 
        /// <summary>
        /// 
        /// </summary>
        public static void DecodeStream()
        {

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
                byte[] bytes = new byte[connection.ReceiveBufferSize];
                Int32 numBytes = stream.Read(bytes, 0, connection.ReceiveBufferSize);
                string userName = Encoding.ASCII.GetString(bytes, 0, numBytes);
                Console.WriteLine(userName);

                userToConnections.Add(userName, connection);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ReceiveMsg(TcpClient connection)
        {
            TcpClient usersConnection;
            stream = connection.GetStream();

            if (stream.CanRead)
            {
                byte[] bytes = new byte[connection.ReceiveBufferSize];
                stream.Read(bytes, 0, (int)connection.ReceiveBufferSize);
                string msg = Encoding.UTF8.GetString(bytes);
                string username = getUserNameForConnection(connection);
                Console.WriteLine(username + msg);
            }

        }

        /// <summary>
        /// 
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
        
    }
}
