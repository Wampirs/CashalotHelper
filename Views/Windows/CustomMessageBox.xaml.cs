using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CashalotHelper.Views.Windows
{
    public partial  class CustomMessageBox : Window
{
        //TODO: Сделать алгоритм поиска владельца окна
    public CustomMessageBox()
    {
        InitializeComponent();
        Owner = Application.Current.MainWindow;
    }

    void AddButtons(MessageBoxButton buttons)
    {
        switch (buttons)
        {
        case MessageBoxButton.OK:
            AddButton("OK", MessageBoxResult.OK);
            break;
        case MessageBoxButton.OKCancel:
            AddButton("OK", MessageBoxResult.OK);
            AddButton("Cancel", MessageBoxResult.Cancel, isCancel: true);
            break;
        case MessageBoxButton.YesNo:
            AddButton("Yes", MessageBoxResult.Yes);
            AddButton("No", MessageBoxResult.No);
            break;
        case MessageBoxButton.YesNoCancel:
            AddButton("Yes", MessageBoxResult.Yes);
            AddButton("No", MessageBoxResult.No);
            AddButton("Cancel", MessageBoxResult.Cancel, isCancel: true);
            break;
        default:
            throw new ArgumentException("Unknown button value", "buttons");
        }
    }

     private void SetImage(MessageType type)
        {
            switch (type)
            {
                case MessageType.Success:
                    ImageContainer.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/Images/Success.png"));
                    break;
                case MessageType.None:
                    ImageContainer.Height = 0;
                    ImageContainer.Width = 0;
                    break;
                case MessageType.Error:
                    ImageContainer.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/Images/Error.png"));
                    break;
                case MessageType.Warning:
                    ImageContainer.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/Images/Warning.png"));
                    break;
            }
        }

     private void AddButton(string text, MessageBoxResult result, bool isCancel = false)
    {
        var button = new Button() { Content = text, IsCancel = isCancel };
        button.Click += (o, args) => { Result = result; DialogResult = true; };
        ButtonContainer.Children.Add(button);
    }

    MessageBoxResult Result = MessageBoxResult.None;

        public static MessageBoxResult Show(string msg, string title, MessageBoxButton buttons, MessageType type )
        {
            var dialog = new CustomMessageBox();
            dialog.TitleBox.Text = title;
            dialog.MessageContainer.Text = msg;
            dialog.AddButtons(buttons);
            dialog.SetImage(type);
            dialog.ShowDialog();
            return dialog.Result;
        }
        public static MessageBoxResult Show(string msg)
        {
            var dialog = new CustomMessageBox();
            dialog.TitleBox.Text = "";
            dialog.MessageContainer.Text = msg;
            dialog.SetImage(MessageType.None);
            dialog.AddButtons(MessageBoxButton.OK);
            dialog.ShowDialog();
            return dialog.Result;
        }
        public static MessageBoxResult Show(string msg, MessageBoxButton buttons)
        {
            var dialog = new CustomMessageBox();
            dialog.MessageContainer.Text = msg;
            dialog.AddButtons(buttons);
            dialog.SetImage(MessageType.None);
            dialog.ShowDialog();
            return dialog.Result;
        }
        public static MessageBoxResult Show(string msg, MessageType type)
        {
            var dialog = new CustomMessageBox();
            dialog.MessageContainer.Text = msg;
            dialog.AddButtons(MessageBoxButton.OK);
            dialog.SetImage(type);
            dialog.ShowDialog();
            return dialog.Result;
        }



        private void ToolBarGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public enum MessageType
    {
        None = 0,
        Error = 1,
        Warning = 2,
        Success = 3
    }
}
