using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace FullSteamDrumMachine.net.Pages
{
    /// <summary>
    /// Interaction logic for MeasurePage.xaml
    /// </summary>
    public partial class MeasurePage : Page, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        private Song song;
        public Song Song { get { return song; } }

        private ISongManager songManager;
        private IMeasureManager measureManager;

        public MeasurePage(Song song)
        {
            InitializeComponent();
            this.song = song;
            songManager = new SongManager();
            measureManager = new MeasureManager();
            DataContext = this;
        }

        private void SpinButton_Spin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;

            int currentValue = (int)spinner.Content;

            if (e.Direction == SpinDirection.Increase)
            {
                currentValue++;
            }
            else if(currentValue > 0)
            {
                currentValue--;
            }

            spinner.Content = currentValue;
            songManager.updateBpm(Song, currentValue);
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new SongPage());
        }
    }
}
