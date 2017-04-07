using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Net.Sockets;

public class ClientUserConnection : UserConnection
{
  public readonly Client.ChatClient chatClient;

  public string message = "";
  public string userListText;

  public ClientUserConnection(TcpClient client, Client.ChatClient chatClient, string userName) : base(client, userName)
  {
    this.chatClient = chatClient;
  }

  protected override void OnRead(MessageType type, string message)
  {
    if(type == MessageType.ChatMessage)
    {
      int iSpace = message.IndexOf(" ");

      if(iSpace < 0)
      {
        // oops?
        return;
      }

      string from = message.Substring(0, iSpace);
      string chatMessage = message.Substring(iSpace + 1, message.Length - iSpace - 1);
      this.message += $"[{type}] [{from}] {chatMessage}{Environment.NewLine}";
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
