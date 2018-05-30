using ChattingInterfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]

    public class ChattingService : IChattingService
    {
        public ConcurrentDictionary<string, ConnectClient> connectedClient = new ConcurrentDictionary<string, ConnectClient>();

        public int Login(string userName)
        {
            //is anyone else logged in with my name?
            foreach(var client in connectedClient)
            {
                if (client.Key.ToLower() == userName.ToLower())
                {
                    //if yes
                    return 1;
                }
            }

            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();

            ConnectClient newClient = new ConnectClient();
            newClient.connection = establishedUserConnection;
            newClient.UserName = userName;


            connectedClient.TryAdd(userName, newClient);

            return 0;
        }

        public void SendMessageToAll(string message, string userName)
        {
           foreach(var client in connectedClient)
            {
                if( client.Key.ToLower()!= userName.ToLower())
                {
                    client.Value.connection.GetMessage(message, userName);
                }
            }
        }
    }
}
