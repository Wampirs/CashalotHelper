using System.Windows;
using System.Linq;
using System.Windows.Media;

namespace CashalotHelper.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        SolidColorBrush ownerBackground;
        public DialogWindow()
        {
            InitializeComponent();
            Closing += DialogWindow_Closing;
        }

        private void DialogWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Background = ownerBackground;
            Owner.Opacity = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            var actWin = App.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            Owner = actWin;
            ownerBackground = (SolidColorBrush)Owner.Background;
            Owner.Background = new SolidColorBrush(Colors.Gray);
            Owner.Opacity = 0.5;
        }
    }
}
