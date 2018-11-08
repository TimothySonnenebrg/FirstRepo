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
using TJS.VehicleTracker.BL;

namespace TJS.VehicleTracker.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VehicleList vehicles;
        ColorList colors;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            vehicles = new VehicleList();
            Reload();
        }

        public void Reload()
        {
            vehicles.Load();
            dgvVehicles.ItemsSource = null;
            dgvVehicles.ItemsSource = vehicles; //bind

            dgvVehicles.Columns[2].Visibility = Visibility.Hidden;
            dgvVehicles.Columns[3].Visibility = Visibility.Hidden;
            dgvVehicles.Columns[4].Visibility = Visibility.Hidden;
            dgvVehicles.Columns[5].Visibility = Visibility.Hidden;

        }

        private void btnMakes_Click(object sender, RoutedEventArgs e)
        {
            MaintainAttributes attributes = new MaintainAttributes(ScreenMode.Make);
            attributes.ShowDialog();
        }

        private void btnModels_Click(object sender, RoutedEventArgs e)
        {
            MaintainAttributes attributes = new MaintainAttributes(ScreenMode.Model);
            attributes.ShowDialog();
        }

        private void btnColors_Click(object sender, RoutedEventArgs e)
        {
            MaintainColors colors = new MaintainColors();
            colors.ShowDialog();
        }
    }
}
