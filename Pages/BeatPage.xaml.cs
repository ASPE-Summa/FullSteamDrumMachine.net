using FullSteamDrumMachine.net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FullSteamDrumMachine.net.Pages
{
    /// <summary>
    /// Interaction logic for BeatPage.xaml
    /// </summary>
    public partial class BeatPage : Page
    {
        public BeatPage(SongMeasure selectedMeasure)
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
