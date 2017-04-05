
using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class ChatClient
    {
        private const int PORT = 500;
        NetworkStream stream;
        TcpClient client = new TcpClient(); //Test
        TcpListener listener;


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


        /// <summary>
        /// This is called when the ConnectForm btnSubmit is pressed.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="userName"></param>
        public void ConnectToServer(string ipAddress, string userName)
        {
            //conenct to ipAdress; server
            client.Connect(ipAddress, PORT);
            SendUserName(userName);
        }

        /// <summary>
        /// Sends user to the server
        /// </summary>
        public void SendUserName(string user)
        {
            stream = client.GetStream();
            if (stream.CanWrite)
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(user);
                stream.Write(sendBytes, 0, sendBytes.Length);
            }
        }

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="msg"></param>
        public void SendMessage(string msg)
        {
            stream = client.GetStream();
            if(stream.CanWrite)
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(msg);
                stream.Write(sendBytes, 0, sendBytes.Length);
            }
        }

        /// <summary>
        /// Listens for data from the server
        /// </summary>
        public ChatClient()
        {
         
        }

        /// <summary>
        /// Figures out if data received is a user of message 
        /// </summary>
        /// <param name="data"></param>
        private void FigureOutIfMsgOrUser(string data)
        {
            
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
