using FullSteamDrumMachine.net.DialogBoxes;
using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service;
using FullSteamDrumMachine.net.Service.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
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

        #region Properties
        private Song song;
        public Song Song { get { return song; } }

        private ObservableCollection<SongMeasure> measures = new();
        public ObservableCollection<SongMeasure> Measures
        {
            get { return measures; }
            set { measures = value; OnPropertyChanged(); }
        }

        private SongMeasure? selectedMeasure;
        public SongMeasure? SelectedMeasure
        {
            get { return selectedMeasure; }
            set { selectedMeasure = value; OnPropertyChanged(); }
        }
        #endregion

        private ISongManager _songManager;
        private IMeasureManager _measureManager;

        public MeasurePage(Song song)
        {
            InitializeComponent();
            this.song = song;
            _songManager = new SongManager();
            _measureManager = new MeasureManager();
            populateMeasures();
        }

        public void populateMeasures()
        {
            Measures = _measureManager.getSongMeasureCollection(Song);
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
            _songManager.updateBpm(Song, currentValue);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedMeasure != null)
            {
                NavigationService.Navigate(new BeatPage(selectedMeasure));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedMeasure != null)
            {
                MessageBoxResult result;
                bool isOnlyInstance = _measureManager.isOnlyInstance(SelectedMeasure.Measure);
                if (isOnlyInstance)
                {
                    result = System.Windows.MessageBox.Show("This is the only instance of this measure. Once removed it will be gone completely.", "Confirm Delete", MessageBoxButton.YesNo);
                    if(result == MessageBoxResult.Yes)
                    {
                        _measureManager.deleteSongMeasure(SelectedMeasure);
                        _measureManager.deleteMeasure(SelectedMeasure.Measure);
                    }
                }
                else
                {
                    result = System.Windows.MessageBox.Show("The selected measure will be removed from the song.It will still be available for later reuse." , "Confirm Delete", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        _measureManager.deleteSongMeasure(SelectedMeasure);
                    }
                }
                populateMeasures();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddMeasureDialog dialog = new AddMeasureDialog();
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                _measureManager.createForSong(dialog.MeasureName,song, Measures.Count);
                populateMeasures();
            }
        }

        private void ReuseButton_Click(object sender, RoutedEventArgs e)
        {
            ReuseMeasureDialog dialog = new ReuseMeasureDialog();
            dialog.ShowDialog();
            if (dialog.DialogResult == true && dialog.SelectedMeasure != null)
            {
                _measureManager.addToSong(song, dialog.SelectedMeasure, Measures.Count);
                populateMeasures();
            }
        }
    }
}
