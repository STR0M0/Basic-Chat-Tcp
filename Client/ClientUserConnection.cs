using System;
using System.Net.Sockets;

public class ClientUserConnection : UserConnection
{
  public readonly Client.ChatClient chatClient;
  public string message = "";
  public string userListText;

  /// <summary>
  /// 
  /// </summary>
  /// <param name="client"></param>
  /// <param name="chatClient"></param>
  /// <param name="userName"></param>
  public ClientUserConnection(TcpClient client, Client.ChatClient chatClient, string userName) : base(client, userName) // Inherits from UserConnection()
  {
    this.chatClient = chatClient;
  }

  /// <summary>
  /// When the data is reads determine what kind of message it is 
  /// Parse/split out the message and user; display only relevant data
  /// TODO Do not need to keep a running list of messages; send the message over then throw it away
  /// </summary>
  /// <param name="type"></param>
  /// <param name="message"></param>
  protected override void OnRead(MessageType type, string message)
  {
    if(type == MessageType.ChatMessage)
    {
      int iSpace = message.IndexOf(" ");

      if(iSpace < 0)
      {
        // if error
        return;
      }

      string from = message.Substring(0, iSpace);
      string chatMessage = message.Substring(iSpace + 1, message.Length - iSpace - 1);
      this.message += $"[{from}]: {chatMessage}{Environment.NewLine}";
    }
    else if(type == MessageType.UserList)
    {
      string[] userList = message.Split(',');
      string userListText = "";
      for(int i = 0; i < userList.Length; i++)
      {
        userListText += $"{userList[i]}{Environment.NewLine}";
      }
      this.userListText = userListText;
    }
  }
}
