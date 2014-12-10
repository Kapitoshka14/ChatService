﻿using System;
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
      var a = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
      a.Tick += delegate
      {
        var chatClient = new ChatServiceClient();
        var LiN = false;

        var NAME = (names.SelectedIndex != -1 && names.SelectedIndex < names.Items.Count)
          ? (string)((ListBoxItem)names.Items[names.SelectedIndex]).Content
          : "";

        logins.Items.Clear();
        names.Items.Clear();

        var l = new string[1];
        var n = new string[1];
        chatClient.Spiski(ref l, ref n);
        foreach (var i in l) logins.Items.Add(new ListBoxItem { Content = i });
        foreach (var i in n) names.Items.Add(new ListBoxItem { Content = i });

        var obn = false;
        if (NAME != "" && n.Contains(NAME))
        {
          var num = -1;
          n.First(i =>
          {
            num++;
            return i == NAME;
          });
          names.SelectedIndex = num;
        }
        if (names.SelectedIndex != -1 && names.SelectedIndex < names.Items.Count)
        {
          foreach (
            var i in
              chatClient.ClickSpisok((string)((ListBoxItem)names.Items[names.SelectedIndex]).Content,
                pole.Text.Split('\n').Count()))
            pole.Text += i + "\n";
          obn = true;
        }
        pole.IsEnabled = vvod.IsEnabled = enter.IsEnabled = obn;

      };
      a.Start();
      Closing += delegate
      {
        loginExit_Click(null, null);
      };
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

      logins.IsEnabled = name.IsEnabled = names.IsEnabled = nameE.IsEnabled = true;
      
    }
    private void loginExit_Click(object sender, RoutedEventArgs e)
    {
      //выход
      var chatClient = new ChatServiceClient();
      chatClient.Vihod(login.Text);
      loginExit.Visibility = Visibility.Hidden;
      login.IsEnabled = true;

      logins.IsEnabled = name.IsEnabled = names.IsEnabled = nameE.IsEnabled = false;
      
    }
    private void nameE_Click(object sender, RoutedEventArgs e)
    {
      //создание нового чата
      var chatClient = new ChatServiceClient();
      chatClient.CreatSpisok(name.Text);
      name.Text = "";
      
    }
    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
      //удалить чат из списка
      if (names.SelectedIndex == -1 || names.SelectedIndex >= names.Items.Count) return;
      var chatClient = new ChatServiceClient();
      chatClient.DelSpisok((string)((ListBoxItem)names.Items[names.SelectedIndex]).Content);
    }
    private void enter_Click(object sender, RoutedEventArgs e)
    {
      //передача в чат сообщения
      var chatClient = new ChatServiceClient();
      var soobsh = string.Format("{0} - {1}\n{2}\n", DateTime.Now, login.Text, vvod.Text);
      chatClient.Chat((string)((ListBoxItem)names.Items[names.SelectedIndex]).Content, soobsh);
      vvod.Text = "";
    }
    private void names_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //выбирается некоторый чат
      pole.Text = "";
    }
  }
}
