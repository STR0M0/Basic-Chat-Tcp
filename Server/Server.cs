using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;


namespace Server
{
  public class Server
  {
    // This is the port that the server will be listening on 
    const int PORT = 500;
    // This is where the usernames and their connections will be held
    readonly Dictionary<string, ServerUserConnection> userToConnections = new Dictionary<string, ServerUserConnection>();
    readonly TcpListener listener;

    public static void Main()
    {
      // Constructor for the ChatServer
      Server server = new Server();

      while(true)
      {
        Thread.Sleep(1); // Temp to keep alive
      }
    }

    /// <summary>
    /// Listens for data from clients 
    /// </summary>
    public Server()
    {
      listener = TcpListener.Create(PORT);
      listener.Start();
      WaitForConnections();
    }

    /// <summary>
    /// Begins an asynchronous operation to accept an incoming connection attempt
    /// </summary>
    private void WaitForConnections()
    {
      listener.BeginAcceptTcpClient(OnConnect, null);
    }

    /// <summary>
    /// This method is executed asynchronously
    /// Connects the client to the server
    /// Broadcasts the user to client to be displayed on the chatform
    /// Then waits for another connection to be established
    /// </summary>
    /// <param name="ar"></param>
    void OnConnect(IAsyncResult ar)
    {
      //Asynchronously accepts an incoming connection attempt and creates a new TcpClient to handle remote host communication.
      TcpClient client = listener.EndAcceptTcpClient(ar);
      Console.WriteLine("Connected");

      ReceiveUser(client);

      BroadcastUserList();

      WaitForConnections();
    }

    /// <summary>
    /// Connects a user to the server and adds them to the dictionary userToConnections
    /// </summary>
    /// <param name="client"></param>
    public void ReceiveUser(TcpClient client)
    {
      ServerUserConnection connection = new ServerUserConnection(this, client); // Constructor
      userToConnections.Add(connection.userName, connection);
    }

    /// <summary>
    /// For each user that is connected append the userList to include that user
    /// TODO Do not need to keep a running list of users; send the user over then throw it away
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
    /// Pushes out messages to the connected clients
    /// </summary>
    /// <param name="type"></param>
    /// <param name="user"></param>
    /// <param name="message"></param>
    public void SendMsgToAll(MessageType type, ServerUserConnection user, string message)
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
