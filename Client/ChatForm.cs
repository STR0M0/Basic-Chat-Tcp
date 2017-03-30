using System;
using System.Windows.Forms;
using Client;

namespace Simple_Chat_Form_App
{
    public partial class ChatForm : Form
    {
        private ChatClient client;

        public ChatForm(ChatClient client)
        {
            this.client = client;
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.SendMessage(this.msgTxtBox.Text);
        }
    }
}
