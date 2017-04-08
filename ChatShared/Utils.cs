using System;
using System.Text;
using System.Net.Sockets;


public class Utils
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="stream"></param>
  /// <param name="connection"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  public static string ReceiveInformation(NetworkStream stream, TcpClient connection, out MessageType type)
  {
    byte[] bytes = new byte[connection.ReceiveBufferSize];
    int length = stream.Read(bytes, 0, bytes.Length);
    return ReceiveInformation(bytes, length, out type);
  }
  
  /// <summary>
  /// 
  /// </summary>
  /// <param name="bytes"></param>
  /// <param name="length"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  public static string ReceiveInformation(byte[] bytes, int length, out MessageType type)
  {
    string data = Encoding.ASCII.GetString(bytes, 0, length);
    int iSpace = data.IndexOf(' ');
    if(iSpace < 0)
    {
      // TODO
    }

    string typeString = data.Substring(0, iSpace);
    type = (MessageType)Enum.Parse(typeof(MessageType), typeString);
    string message = data.Substring(iSpace + 1, data.Length - iSpace - 1);

    return message;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="type"></param>
  /// <param name="stream"></param>
  /// <param name="message"></param>
  public static void SendInformation(MessageType type, NetworkStream stream, string message)
  {
    Byte[] sendBytes = Encoding.UTF8.GetBytes($"{type} {message}");
    stream.Write(sendBytes, 0, sendBytes.Length);
  }
}
