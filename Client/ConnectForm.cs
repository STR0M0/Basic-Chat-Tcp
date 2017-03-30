using System;
using System.Windows.Forms;
using System.Net.Sockets;
using Simple_Chat_Form_App;

namespace Client
{
    public partial class ConnectForm : Form
    {
        private ChatClient client;
        TcpClient tcpClient = new TcpClient();

        public string ipAddress;
        public string userName;
        /// <summary>
        /// 
        /// </summary>
        public ConnectForm(ChatClient client)
        {
            this.client = client;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ipAddress = this.txtBoxIPAddress.Text;
            userName = this.txtBoxUserName.Text;
            client.ConnectToServer(ipAddress, userName);
            this.Hide();
            new ChatForm(client).Show();
        }
    }
}
