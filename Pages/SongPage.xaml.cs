using FullSteamDrumMachine.net.DialogBoxes;
using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
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

        private Song? selectedSong;
        public Song? SelectedSong
        {
            get { return selectedSong; }
            set { selectedSong = value; OnPropertyChanged(); }
        }
        #endregion

        private ISongManager songManager;
        public SongPage()
        {
            InitializeComponent();
            songManager = new SongManager();
            PopulateSongs();
        }

        public void PopulateSongs()
        {
            Songs = songManager.getSongCollection();
            DataContext = this;
        }


        private void AddSongButton_Click(object sender, RoutedEventArgs e)
        {
            AddSongDialog dialog = new AddSongDialog();
            dialog.ShowDialog();
            if(dialog.DialogResult == true)
            {
                songManager.createSong(dialog.SongName);
                PopulateSongs();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedSong != null)
            {
                NavigationService.Navigate(new MeasurePage(selectedSong));
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedSong != null)
            {
                songManager.deleteSong(selectedSong);
                PopulateSongs();
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
