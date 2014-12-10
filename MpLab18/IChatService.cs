using System.Collections.Generic;
using System.ServiceModel;

namespace MpLab18
{
  // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IChatService" в коде и файле конфигурации.
  [ServiceContract]
  public interface IChatService
  {
    //вход пользователя
    [OperationContract]
    bool Vhod(string login);
    [OperationContract]
    void Vihod(string login);
    [OperationContract]
    void Spiski(ref List<string> logins, ref List<string> names);
    [OperationContract]
    bool CreatSpisok(string name);
    [OperationContract]
    List<string> ClickSpisok(string name,int razm);
    [OperationContract]
    void DelSpisok(string name);
    [OperationContract]
    void Chat(string name, string enter);
  }
}
