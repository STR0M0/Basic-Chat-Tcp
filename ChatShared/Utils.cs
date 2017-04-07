using System;
using System.Text;
using System.Net.Sockets;


public class Utils
{
  /// <summary>
  /// Decodes the network stream into it's ASCII values and returns the results as a string
  /// </summary>
  public static string ReceiveInformation(NetworkStream stream, TcpClient connection, out MessageType type)
  {
    byte[] bytes = new byte[connection.ReceiveBufferSize];
    int length = stream.Read(bytes, 0, bytes.Length);
    return ReceiveInformation(bytes, length, out type);
  }

  public static string ReceiveInformation(byte[] bytes, int length, out MessageType type)
  {
    string data = Encoding.ASCII.GetString(bytes, 0, length);
    int iSpace = data.IndexOf(' ');
    if(iSpace < 0)
    {
      // uh oh..
    }

    string typeString = data.Substring(0, iSpace);
    type = (MessageType)Enum.Parse(typeof(MessageType), typeString);
    string message = data.Substring(iSpace + 1, data.Length - iSpace - 1);

    return message;
  }

  public static void SendInformation(MessageType type, NetworkStream stream, string message)
  {
    Byte[] sendBytes = Encoding.UTF8.GetBytes($"{type} {message}");
    stream.Write(sendBytes, 0, sendBytes.Length);
  }
}
