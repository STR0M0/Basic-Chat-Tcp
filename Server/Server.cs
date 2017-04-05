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
        TcpListener Listener;
        NetworkStream stream;

        String userName;
        String message;
    

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
            Listener = TcpListener.Create(PORT);
            Listener.Start();
            while (true)
            {
                //check if there are any pending connection requests
                if (Listener.Pending())
                {
                    //if there are pending requests create a new connection
                    TcpClient chatConnection = Listener.AcceptTcpClient();
                    Console.WriteLine("Connected");
                    ReceiveUser(chatConnection);
                    ReceiveMsg(chatConnection);
                    //SendMsgToAll();
                    //SendUserToAll();
                }
            }
        }

        /// <summary>
        /// Gets username from client and decodes it into it's ASCII value
        /// Prints username to console
        /// </summary>
        /// <param name="connection"></param>
        public void ReceiveUser(TcpClient connection)
        {
            stream = connection.GetStream();

            if (stream.CanRead)
            {
                userName = "User: " + Utils.ReceiveInformation(stream, connection);
                userToConnections.Add(userName, connection);
                Console.WriteLine(userName);
            }

        }

        /// <summary>
        /// Gets message from client and decodes it into it's ASCII value 
        /// Prints username to console
        /// </summary>
        /// <param name="msg"></param>
        public void ReceiveMsg(TcpClient connection)
        {
            stream = connection.GetStream();

            if (stream.CanRead)
            {
               message = getUserNameForConnection(connection) + " " + Utils.ReceiveInformation(stream, connection);
                Console.WriteLine(message);
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
        public void SendUserToAll()
        {
            Utils.SendInformation(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="msg"></param>
        public void SendMsgToAll()
        {
            Utils.SendInformation(message);
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
