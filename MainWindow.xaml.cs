using FullSteamDrumMachine.net.Pages;
using System.Windows;

namespace FullSteamDrumMachine.net
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainframe.NavigationService.Navigate(new SongPage());
        }
    }
}
