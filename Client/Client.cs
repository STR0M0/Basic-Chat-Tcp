
using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class ChatClient
    {
        NetworkStream stream;
        TcpClient tcpClient;
        TcpListener listener;

        private const int PORT = 500;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectForm(new ChatClient()));
        }

        public ChatClient()
        {
            //listen for data from server
        }

        private void FigureOutIfMsgOrUser(string data)
        {
            // Figure out
        }

        /// <summary>
        /// This is called when the ConnectForm btnSubmit is pressed.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="userName"></param>
        public void ConnectToServer(string ipAddress, string userName)
        {
            //conenct to ipAdress; server
            tcpClient.Connect(ipAddress, PORT);
            SendUserName(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendUserName(string user)
        {
            stream = tcpClient.GetStream();
            if (stream.CanWrite)
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(user);
                stream.Write(sendBytes, 0, sendBytes.Length);
            }
        }

        /// <summary>
        /// This sends a message to the server
        /// </summary>
        /// <param name="msg"></param>
        public void SendMessage(string msg)
        {
            stream = tcpClient.GetStream();
            if(stream.CanWrite)
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(msg);
                stream.Write(sendBytes, 0, sendBytes.Length);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReceiveUsers()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void ReceiveMsgs()
        {

        }
   
    }
}
