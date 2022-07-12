using FullSteamDrumMachine.net.Model;
using FullSteamDrumMachine.net.Service;
using FullSteamDrumMachine.net.Service.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FullSteamDrumMachine.net.DialogBoxes
{
    /// <summary>
    /// Interaction logic for ReuseMeasureDialog.xaml
    /// </summary>
    public partial class ReuseMeasureDialog : Window, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        private ObservableCollection<Measure> measures = new();
        public ObservableCollection<Measure> Measures { get { return measures; } set { measures = value; OnPropertyChanged(); } }

        private Measure? selectedMeasure;
        public Measure? SelectedMeasure { get { return selectedMeasure; } set { selectedMeasure = value; OnPropertyChanged(); } }

        private IMeasureManager measureManager = new MeasureManager();
        public ReuseMeasureDialog()
        {
            InitializeComponent();
            Measures = measureManager.getAllMeasures();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void PreviewMeasure_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
