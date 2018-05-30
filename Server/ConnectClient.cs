using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   public class ConnectClient
    {
        public IClient connection;

        public string UserName { get; set; }
    }
}
