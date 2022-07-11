using System;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace FullSteamDrumMachine.net.Pages
{
    /// <summary>
    /// Interaction logic for MeasurePage.xaml
    /// </summary>
    public partial class MeasurePage : Page
    {
        public MeasurePage()
        {
            InitializeComponent();
        }

        private void SpinButton_Spin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;

            string currentSpinValue = (string)spinner.Content;



            int currentValue = String.IsNullOrEmpty(currentSpinValue) ? 0 : Convert.ToInt32(currentSpinValue);

            if (e.Direction == SpinDirection.Increase)

                currentValue++;

            else

                currentValue--;

            spinner.Content = currentValue.ToString();
        }
    }
}
