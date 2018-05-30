using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChattingInterfaces
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IChattingService" в коде и файле конфигурации.
    [ServiceContract(CallbackContract =typeof(IClient))]

    public interface IChattingService
    {
        [OperationContract]
         int Login (string userName);
        [OperationContract]
        void SendMessageToAll(string message, string userName);
    }
}
