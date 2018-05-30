﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ChattingInterfaces;


namespace Chat_0._7
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]

    public class ClientCallback : IClient
    {
        public void GetMessage(string message, string userName)
        {
            ((MainWindow)Application.Current.MainWindow).TakeMessage(message, userName);
        }
        
    }
}
