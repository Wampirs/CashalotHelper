using System;
using System.Windows;

namespace CashBackup.Windows
{
    /// <summary>
    /// Логика взаимодействия для WaitWindow.xaml
    /// </summary>
    public partial class WaitWindow : Window
    {
        public WaitWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }

        public void StartWait(String reason = "")
        {
            Owner.IsEnabled = false;
            this.WaitReason.Text = reason;
            Show();
        }

        public void EndWait()
        {
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.IsEnabled = true;
        }

    }
}
