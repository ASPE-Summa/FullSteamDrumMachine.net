using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FullSteamDrumMachine.net.Pages
{
    /// <summary>
    /// Interaction logic for BeatPage.xaml
    /// </summary>
    public partial class BeatPage : Page, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Properties
        private ICollection<Instrument> instruments = null!;
        public ICollection<Instrument> Instruments
        {
            get { return instruments; }
            set { instruments = value; OnPropertyChanged(); }
        }

        private SongMeasure songMeasure;
        public SongMeasure SongMeasure
        {
            get { return songMeasure; }
            set
            {
                songMeasure = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region fields
        private IInstrumentManager _instrumentManager;

        #endregion
        public BeatPage(SongMeasure selectedMeasure)
        {
            InitializeComponent();
            SongMeasure = selectedMeasure;
            _instrumentManager = new InstrumentManager();
            PopulateInstruments();
        }

        private void PopulateInstruments()
        {
            Instruments = _instrumentManager.getInstrumentCollectionForMeasure(SongMeasure.Measure);
            DataContext = this;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
