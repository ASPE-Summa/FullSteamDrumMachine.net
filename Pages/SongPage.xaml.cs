using FullSteamDrumMachine.net.DialogBoxes;
using FullSteamDrumMachine.net.Service.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace FullSteamDrumMachine.net.Pages
{
    /// <summary>
    /// Interaction logic for SongPage.xaml
    /// </summary>
    public partial class SongPage : Page
    {
        ISongManager songManager;
        public SongPage()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MeasurePage());
        }

        private void AddSongButton_Click(object sender, RoutedEventArgs e)
        {
            AddSongDialog dialog = new AddSongDialog();
            if(dialog.DialogResult == true)
            {
                songManager.createSong(dialog.SongName);
            }
        }
    }
}
