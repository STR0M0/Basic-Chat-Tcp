using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;


namespace Server
{
    class ChatServer
    {
        private const int PORT = 500;
        private Dictionary<string, TcpClient> userToConnections = new Dictionary<string, TcpClient>();
        TcpListener listener;
        TcpClient client;
        NetworkStream stream;

        string userName;
        string message;
    
        public static void Main()
        {
            ChatServer server = new ChatServer();
        }

        /// <summary>
        /// Listens for data from clients 
        /// </summary>
        public ChatServer()
        {
            listener = TcpListener.Create(PORT);
            listener.Start();

            // Wait until first connection is made
            while (true)
            {
                //check if there are any pending connection requests
                if (listener.Pending())
                {
                    //if there are pending requests create a new connection
                    client = listener.AcceptTcpClient();
                    Console.WriteLine("Connected");
                    ReceiveUser(client);
                    break;
                }
            }

            // Keep waiting and receiving messages from the client
            while (true)
            {
                ReceiveMsg(client);
                SendMsgToAll();
                SendUserToAll();
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
                this.userName = "User: " + Utils.ReceiveInformation(stream, connection);
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
                this.message = getUserNameForConnection(connection) + " " + Utils.ReceiveInformation(stream, connection);
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

        public void SendUserToAll()
        {
            Utils.SendInformation(client, userName);
        }

        public void SendMsgToAll()
        {
            Utils.SendInformation(client, message);
        }
    }
}
