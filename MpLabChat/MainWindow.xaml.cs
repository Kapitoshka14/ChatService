using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using MpLabChat.ChatServiceReference;


namespace MpLabChat
{
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();
    }
    private void loginE_Click(object sender, RoutedEventArgs e)
    {
      //вход
      var chatClient = new ChatServiceClient();
      var a = chatClient.Vhod(login.Text);
      if (a == false)
      {
        login.Text = "";
        return;
      }
      login.IsEnabled = false;
      loginExit.Visibility = Visibility.Visible;

      logins.IsEnabled = true;
      os.Visibility = Visibility.Hidden;
    }
    private void loginExit_Click(object sender, RoutedEventArgs e)
    {
      //выход
      var chatClient = new ChatServiceClient();
      chatClient.Vihod(login.Text);
      loginExit.Visibility = Visibility.Hidden;
      login.IsEnabled = true;

      logins.IsEnabled = false;
      os.Visibility = Visibility.Hidden;
    }
    private void nameE_Click(object sender, RoutedEventArgs e)
    {
      //создание нового чата
    }
    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
      //удалить чат из списка
    }
    private void enter_Click(object sender, RoutedEventArgs e)
    {
      //передача в чат сообщения
    }
    private void names_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //выбирается некоторый чат
    }
  }
}
