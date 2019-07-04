
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Libuv;
using Examples.Common;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using DotNetty.Handlers.Tls;

namespace SocketServerV1
{
    public class Server
    {
        public static async Task RunServerAsync()
        {
            //ExampleHelper.SetConsoleLogger();

            //重要的概念 IEventLoopGroup代表了处理网络的线程，server端用两个，client端一个就够了。
            //boss处理网络连接的概念，client处理数据概念。两个IEventLoopGroup不代表两个线程，而是代表了两组线程
            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup workerGroup = new MultithreadEventLoopGroup();

            ////如果通信需要加密的话，使用证书
            //X509Certificate2 tlsCertificate = null;
            //if (ServerSettings.IsSsl)
            //{
            //    tlsCertificate = new X509Certificate2(Path.Combine(ExampleHelper.ProcessDirectory, "dotnetty.com.pfx")
            //        , "password");
            //}
            try
            {
                var bootstrap = new ServerBootstrap();
                bootstrap.Group(bossGroup, workerGroup);
                bootstrap.Channel<TcpServerSocketChannel>();
                bootstrap
                    .Option(ChannelOption.SoBacklog, 100)
                    .Handler(new LoggingHandler("SRV-LSTN"))
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        //重要概念 增加Handler和Decoder，Encoder到pipeline中去
                        IChannelPipeline pipeline = channel.Pipeline;
                        //if (tlsCertificate != null)
                        //{
                        //    pipeline.AddLast("tls", TlsHandler.Server(tlsCertificate));
                        //}
                        pipeline.AddLast(new LoggingHandler("SRV-CONN"));
                        pipeline.AddLast("framing-enc", new LengthFieldPrepender(2));
                        pipeline.AddLast("framing-dec"
                            ,new LengthFieldBasedFrameDecoder(ushort.MaxValue, 0, 2, 0, 2));
                        //自定义的handler
                        pipeline.AddLast("echo", new EchoServerHandler());
                    }));

                IChannel boundChannel = await bootstrap.BindAsync(ServerSettings.Port);
                Console.ReadLine();
                await boundChannel.CloseAsync();
            }
            finally
            {
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1))
                    , workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            }
        }
    }
}
