using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FullSteamDrumMachine.net.DialogBoxes
{
    /// <summary>
    /// Interaction logic for AddMeasureDialog.xaml
    /// </summary>
    public partial class AddMeasureDialog : Window, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
        private string measureName = "";
        public string MeasureName { get { return measureName; } set { measureName = value; OnPropertyChanged(); } }

        public AddMeasureDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
