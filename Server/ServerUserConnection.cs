using System;
using System.Net.Sockets;

namespace Server
{
  public class ServerUserConnection : UserConnection 
  {
    readonly Server server;
   
    /// <summary>
    /// Facilitates connection
    /// </summary>
    /// <param name="server"></param>
    /// <param name="client"></param>
    public ServerUserConnection(Server server, TcpClient client) : base(client, GetUsername(client)) // Inherits from UserConnection()
    {
      this.server = server;
    }
    
    private static string GetUsername(TcpClient client)
    {
      NetworkStream stream = client.GetStream();
      if(stream.CanRead)
      {
        // Receives infromation from the stream, determines MessageType, and returns username 
        string userName = Utils.ReceiveInformation(stream, client, out MessageType type); 
        Console.WriteLine(userName);
        return userName;
      }

      return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="message"></param>
    protected override void OnRead(MessageType type, string message)
    {
      if(type != MessageType.ChatMessage)
      {
        return;
      }

      server.SendMsgToAll(MessageType.ChatMessage, this, $"{userName} {message}");
    }
  }
}
