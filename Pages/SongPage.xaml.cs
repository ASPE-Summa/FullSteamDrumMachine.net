using FullSteamDrumMachine.net.DialogBoxes;
using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service;
using FullSteamDrumMachine.net.Service.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace FullSteamDrumMachine.net.Pages
{
    /// <summary>
    /// Interaction logic for SongPage.xaml
    /// </summary>
    public partial class SongPage : Page, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Properties
        private ObservableCollection<Song> songs = new();
        public ObservableCollection<Song> Songs
        {
            get { return songs; }
            set { songs = value; OnPropertyChanged(); }
        }
        #endregion

        private ISongManager songManager;
        public SongPage()
        {
            InitializeComponent();
            songManager = new SongManager();
            Songs = songManager.getSongCollection();
            DataContext = this;
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
