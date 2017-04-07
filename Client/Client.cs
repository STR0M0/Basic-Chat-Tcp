
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
        NetworkStream stream;
        TcpClient client = new TcpClient();
        ChatForm chatForm;
        string data;
     
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectForm(new ChatClient()));
        }
        
        public ChatClient()
        {

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

        public void ReceiveData(TcpClient connection)
        {
            stream = connection.GetStream();

            if (stream.CanRead)
            {
                this.data = Utils.ReceiveInformation(stream, connection);

                if (data.StartsWith("User"))
                {
                    chatForm.ReceiveUser(data);
                }

                else
                {
                    chatForm.ReceiveMessage(data);
                }
            }
        }
    }
}
