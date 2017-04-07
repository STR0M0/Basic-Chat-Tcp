using System;
using System.Windows.Forms;
using Client;

namespace Simple_Chat_Form_App
{
  public partial class ChatForm : Form
  {
    private ChatClient client;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    public ChatForm(ChatClient client)
    {
      client.chatForm = this;
      this.client = client;
      InitializeComponent();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSend_Click(object sender, EventArgs e)
    {
      client.SendMessage(this.msgTxtBox.Text);
      msgTxtBox.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public void ReceiveMessage(string message)
    {
      msgTxtBox.Text += message;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    public void ReceiveUser(string user)
    {
      userTxtBox.Text += user;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Application.Exit();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void timer1_Tick(object sender, EventArgs e)
    {
      if(client.userConnection == null)
      {
        return;
      }

      chatTxtBox.Text = client.userConnection.message;
      userTxtBox.Text = client.userConnection.userListText;
    }
  }
}
