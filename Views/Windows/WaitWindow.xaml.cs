using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
