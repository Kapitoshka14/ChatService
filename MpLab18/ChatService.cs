using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MpLab18
{
  public class ChatService : Program, IChatService
  {
    /// <summary>
    /// Вход пользователя под написанным логином
    /// </summary>
    /// <param name="login">Выранный логин</param>
    /// <returns>Возвращает вошёл ли он в базу (не сдублирован ли логин)</returns>
    public bool Vhod(string login)
    {
      var logins = File.ReadAllLines("logins").ToList();
      
      if (logins.Contains(login))
      {
        Console.WriteLine("Неудача при входе.");
        return false;
      }
      Console.WriteLine("Пользователь {0} вошёл.", login);
      var a = new StreamWriter("logins", true);
      a.WriteLine(login);
      a.Close();
      return true;
    }
    /// <summary>
    /// Выход пользователя и стирание его из базы
    /// </summary>
    /// <param name="login">Логин выходящего</param>
    public void Vihod(string login)
    {
      File.WriteAllLines("logins", File.ReadAllLines("logins").ToList().Where(i => i != login));
      Console.WriteLine("Пользователь {0} вышел", login);
    }

    /// <summary>
    /// Выводит списки пользователей и чатов
    /// </summary>
    /// <returns>Лист[0] пользователи,[1]-чаты</returns>
    public void Spiski(ref List<string> logins, ref List<string> names)
    {
    }

    /// <summary>
    /// Создаёт новый чат
    /// </summary>
    /// <param name="name">Имя нового чата</param>
    /// <returns>true - создано удачно</returns>
    public bool CreatSpisok(string name)
    {
      return true;
    }

    /// <summary>
    /// Выбор чата а также обновление чата
    /// </summary>
    /// <param name="name">имя выбранного чата</param>
    /// <param name="razm">размер базы, которая уже есть у клиента</param>
    /// <returns>Содержимое чата</returns>
    public List<string> ClickSpisok(string name, int razm)
    {
      return null;
    }
    /// <summary>
    /// Удаление чата из списка и базы
    /// </summary>
    /// <param name="name">Имя удаляемого чата</param>
    public void DelSpisok(string name)
    {
    }
    /// <summary>
    /// Создание соощения
    /// </summary>
    /// <param name="name">Имя чата</param>
    /// <param name="enter">Сообщение</param>
    public void Chat(string name, string enter)
    {
    }
  }
}
