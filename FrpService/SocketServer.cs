using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FrpService
{
    public class SocketServer
    {

        
        private static Socket _server;
        private static Socket _client;
        public SocketServer(int port = 9360)
        {
            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
            _server.Bind(endpoint);
            _server.Listen(5);
            var thread = new Thread(new ParameterizedThreadStart(ToAccept));
            thread.IsBackground = true;
            thread.Start(_server);
        }
        

        
        private void ToAccept(object socket)
        {
            while (true)
            {
                _client = ((Socket)socket).Accept();
            }
        }
        
        /// <summary>
        /// 发送通道状态
        /// </summary>
        /// <param name="line"></param>
        public void WriteToClient(string message)
        {
          
            var data = Encoding.Default.GetBytes(message);
            try
            {
                if (_client != null && _client.Connected)
                {
                    var e = new SocketAsyncEventArgs();
                    e.SetBuffer(data, 0, data.Length);
                    _client.SendAsync(e);
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        public void Close()
        {
            if (_client != null && _client.Connected)
            {
                _client.Close();
                _client.Dispose();
            }
            _server.Close();
            _server.Dispose();
        }
    }
}
