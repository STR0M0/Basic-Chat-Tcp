using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using Simple_Chat_Form_App;
using System.Threading;

namespace Client
{
  public class ChatClient
  {
    private const int PORT = 500;
    TcpClient client = new TcpClient();
    public ChatForm chatForm;
    public ClientUserConnection userConnection;
    string data;

    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      var client = new ChatClient();
      var form = new ConnectForm(client);
      Application.Run(form);
    }
    
    /// <summary>
    /// This is called when the ConnectForm btnSubmit is pressed.
    /// </summary>
    /// <param name="ipAddress"></param>
    /// <param name="userName"></param>
    public void ConnectToServer(string ipAddress, string userName)
    {
      client.Connect(ipAddress, PORT);
      SendUserName(userName);
    }

    /// <summary>
    /// Sends user to the server
    /// </summary>
    public void SendUserName(string user)
    {
      userConnection = new ClientUserConnection(client, this, user);
      Utils.SendInformation(MessageType.Connect, client.GetStream(), user);
    }

    /// <summary>
    /// Sends a message to the server
    /// </summary>
    /// <param name="msg"></param>
    public void SendMessage(string msg)
    {
      Utils.SendInformation(MessageType.ChatMessage, userConnection.stream, msg);
    }
  }
}
