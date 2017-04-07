﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;


namespace Server
{
  public class ChatServer
  {
    const int PORT = 500;
    readonly Dictionary<string, ServerUserConnection> userToConnections = new Dictionary<string, ServerUserConnection>();
    readonly TcpListener listener;

    public static void Main()
    {
      ChatServer server = new ChatServer();

      while(true)
      {
        Thread.Sleep(1); // Temp to keep alive
      }
    }

    /// <summary>
    /// Listens for data from clients 
    /// </summary>
    public ChatServer()
    {
      listener = TcpListener.Create(PORT);
      listener.Start();
      WaitForConnections();
    }

    /// <summary>
    /// 
    /// </summary>
    private void WaitForConnections()
    {
      listener.BeginAcceptTcpClient(OnConnect, null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ar"></param>
    void OnConnect(IAsyncResult ar)
    {
      TcpClient client = listener.EndAcceptTcpClient(ar);
      Console.WriteLine("Connected");

      ReceiveUser(client);

      BroadcastUserList();

      WaitForConnections();
    }

    /// <summary>
    /// Gets username from client and decodes it into it's ASCII value
    /// Prints username to console
    /// </summary>
    /// <param name="client"></param>
    public void ReceiveUser(
      TcpClient client)
    {
      ServerUserConnection connection = new ServerUserConnection(this, client);
      userToConnections.Add(connection.userName, connection);
    }

    /// <summary>
    /// 
    /// </summary>
    void BroadcastUserList()
    {
      string userList = "";
      foreach(var connection in userToConnections)
      {
        userList += $"{connection.Value.userName},";
      }

      SendMsgToAll(MessageType.UserList, null, userList);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="user"></param>
    /// <param name="message"></param>
    public void SendMsgToAll(
      MessageType type,
      ServerUserConnection user, 
      string message)
    {
      Console.WriteLine($"{user?.userName}: {message}");

      foreach(var connection in userToConnections)
      {
        Console.WriteLine($"Sending to {connection.Value.userName}");
        Utils.SendInformation(type, connection.Value.stream, message);
      }
    }
  }
}
