using System;
using System.Net.Sockets;

public abstract class UserConnection
{
  public readonly TcpClient client;
  public readonly NetworkStream stream;
  public readonly string userName;
  byte[] data;
  
  /// <summary>
  /// 
  /// </summary>
  /// <param name="client"></param>
  /// <param name="userName"></param>
  public UserConnection(TcpClient client, string userName)
  {
    this.client = client;
    this.userName = userName;
    stream = client.GetStream();

    data = new byte[client.ReceiveBufferSize];

    WaitForData();
  }

  /// <summary>
  /// 
  /// </summary>
  private void WaitForData()
  {
    Console.WriteLine("Wait");

    stream.BeginRead(data, 0, data.Length, OnReadData, null);
  }

  /// <summary>
  /// SocketException: An existing connection was forcibly closed by the remote host
  /// </summary>
  /// <param name="ar"></param>
  void OnReadData(IAsyncResult ar)
  {
    Console.WriteLine("Read");

    int result = stream.EndRead(ar); // TODO disconnect & error handling

    Console.WriteLine("Read done");
    if(result <= 0)
    {
      Console.WriteLine("Error reading");
      return;
    }

    string message = Utils.ReceiveInformation(data, result, out MessageType type);

    OnRead(type, message);

    WaitForData();
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="type"></param>
  /// <param name="message"></param>
  protected abstract void OnRead(MessageType type, string message);
}
