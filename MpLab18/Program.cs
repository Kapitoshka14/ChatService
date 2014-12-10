using System;
using System.IO;
using System.ServiceModel;

namespace MpLab18
{
  public class Program
  {
    static void Main()
    {
      File.WriteAllLines("logins", new string[] {""});
      var serviceHost = new ServiceHost(typeof (ChatService));
      serviceHost.Open();
      Console.WriteLine("Сервис запущен...");
      Console.WriteLine("Нажмите любую клавишу для остановки");
      Console.ReadKey(true);
      serviceHost.Close();
      Console.WriteLine("Сервис остановлен.");
    }
  }
}
