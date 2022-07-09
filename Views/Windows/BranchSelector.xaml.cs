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

namespace CashalotHelper.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для BranchSelector.xaml
    /// </summary>
    public partial class BranchSelector : Window
    {
        private static BranchSelector instance; 
        private BranchSelector()
        {
            InitializeComponent();
        }

        public static void OpenWindow()
        {
            instance = new BranchSelector();
            instance.ShowDialog();
        }

        public static void CloseWindow()
        {
            if (instance != null && instance.IsActive) instance.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
