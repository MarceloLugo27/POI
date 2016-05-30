using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TcpServer
{
    public class Server
    {
        private IPAddress serverIp;
        private int serverPort;
        private TcpListener serverListener;
        private bool isServerRunning = false;

        private Thread backgroundListner;
        private Thread connectionThread;


        List<User> tcpClients = new List<User>();


        public delegate void PropertyChangeHandler(object sender, EventArgs args);
        
        public event PropertyChangeHandler OnclientConnected;


      


        public Server(string serverIp, int serverPort)
        {
            
            this.serverIp = IPAddress.Parse(serverIp);
            this.serverPort = serverPort;
      


        }

        public List<User> TcpClients
        {
            get { return tcpClients; }
            set { tcpClients = value; }
        }



        public void startListener()
        {
            this.serverListener = new TcpListener(this.serverIp, this.serverPort);
            this.serverListener.Start();
            this.isServerRunning = true;

            backgroundListner = new Thread(()=>KeepListening());
            backgroundListner.IsBackground = true;
            backgroundListner.Start();

          
        }


        private void KeepListening()
        {
            // While the server is running
            while (this.isServerRunning == true)
            {

                TcpClient tcpClient = this.serverListener.AcceptTcpClient(); // Otherwise this will block the UI // Called when a Client Connect

                connectionThread = new Thread(() => connectionHandler(tcpClient));
                connectionThread.IsBackground = true;
                connectionThread.Start();

                

                

            }
        }

        private void connectionHandler(TcpClient client)
        {
           
            TcpClient this_client = client;
            Stream clientStream = this_client.GetStream();


            StreamWriter strWritter = new StreamWriter(clientStream);
            StreamReader strReader = new StreamReader(clientStream);
            string clientMessage;

         

             // Keep waiting for a message from the user
            while (this.isServerRunning == true)
            {
                clientMessage = strReader.ReadLine();

                string[] response = clientMessage.Split(';');

                if (response[0] == "CONNECT_REQUEST")
                {
                    User usr = new User(client, response[1]);

                    this.tcpClients.Add(usr);
                    OnclientConnected(usr, new EventArgs());


                }
                if(response[0] == "SEND_MSG")
                {
                    string to = response[1];
                    string msgBody = response[2];

                    User source = this.TcpClients.Where(c => c.TcpClient.Equals(this_client)).Select(c => c).FirstOrDefault();
                    User destination = this.TcpClients.Where(c => c.UserName == to).Select(c => c).FirstOrDefault();


                    string client_chat;
                    client_chat = "INCOMING_MSG;" + source.UserName + ";" + msgBody;

                    Stream desStream = destination.TcpClient.GetStream();

                    StreamWriter wr = new StreamWriter(desStream);
                    wr.WriteLine(client_chat);
                    wr.Flush();
                }

                if (response[0] == "SEND_BUZZ")
                {
                    string to = response[1];
                    string msgBody = response[2];

                    User source = this.TcpClients.Where(c => c.TcpClient.Equals(this_client)).Select(c => c).FirstOrDefault();
                    User destination = this.TcpClients.Where(c => c.UserName == to).Select(c => c).FirstOrDefault();


                    string client_chat;
                    client_chat = "INCOMING_BUZZ;" + source.UserName + ";" + msgBody;

                    Stream desStream = destination.TcpClient.GetStream();

                    StreamWriter wr = new StreamWriter(desStream);
                    wr.WriteLine(client_chat);
                    wr.Flush();
                }



            }

         
        }

    }
}
