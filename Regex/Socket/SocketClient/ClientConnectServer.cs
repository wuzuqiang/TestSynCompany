﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    class ClientSocket
    {
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public byte[] MsgBuffer { get; private set; }

        public void ClientCommunicateServer()
        {
            int port = 6000;
            string host = "127.0.0.1";   //服务器端ip地址

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            clientSocket.Connect(ipe);

            //send message
            string sendStr = "send to server :hello,nihao";
            byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
            clientSocket.Send(sendBytes);

            //receive message
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);
            Console.WriteLine("Client Receive Data：" + recStr);

            clientSocket.Close();
        }

        public void Connect(IPAddress ip, int port)
        {
            this.clientSocket.BeginConnect(ip, port, new AsyncCallback(ConnectCallback), this.clientSocket);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                handler.EndConnect(ar);
            }
            catch(SocketException ex)
            {

            }
        }

        #region 发送信息 Send(string data)
        public void Send(string data)
        {
            Send(System.Text.Encoding.UTF8.GetBytes(data));
        }

        private void Send(byte[] byteData)
        {
            try
            {
                int length = byteData.Length;
                byte[] head = BitConverter.GetBytes(length);
                byte[] data = new byte[head.Length + byteData.Length];
                Array.Copy(head, data, head.Length);
                Array.Copy(byteData, 0, data, head.Length, byteData.Length);
                this.clientSocket.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback)
                    , this.clientSocket);
            }
            catch (SocketException ex)
            { }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                handler.EndSend(ar);
            }
            catch (SocketException ex)
            { }
        }
        #endregion

        #region 接收信息 ReceiveData()
        public void ReceiveData()
        {
            clientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallback)
                , null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                int REnd = clientSocket.EndReceive(ar);
                if (REnd > 0)
                {
                    byte[] data = new byte[REnd];
                    Array.Copy(MsgBuffer, 0, data, 0, REnd);

                    //在此处可以对data进行按需处理

                    clientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length
                        , 0, new AsyncCallback(ReceiveCallback), null);
                }
                else
                {
                    dispose();
                }
            }
            catch (SocketException ex)
            { }
        }

        private void dispose()
        {
            try
            {
                this.clientSocket.Shutdown(SocketShutdown.Both);
                this.clientSocket.Close();
            }
            catch (Exception ex)
            { }
        }
        #endregion

    }
}
