using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Client
{
    class Utils
    {

        /// <summary>
        /// Decodes the network stream into it's ASCII values and returns the results as a string
        /// </summary>
        public static string ReceiveInformation(NetworkStream stream, TcpClient connection)
        {
            byte[] bytes = new byte[connection.ReceiveBufferSize];
            Int32 numBytes = stream.Read(bytes, 0, connection.ReceiveBufferSize);
            string data = Encoding.ASCII.GetString(bytes, 0, numBytes);
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public static void SendInformation(string data)
        {
            TcpClient client = new TcpClient();
            NetworkStream stream = client.GetStream();

            if (stream.CanWrite)
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(data);
                stream.Write(sendBytes, 0, sendBytes.Length);
            }
        }
    }
}
