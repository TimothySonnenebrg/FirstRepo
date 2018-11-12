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

namespace TJS.SquareRoot.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create controls

            Grid grdControls = new Grid();
            grdControls.Name = "grdControls";
            grdControls.Width = 610;
            grdControls.Height = 70;
            grdControls.HorizontalAlignment = HorizontalAlignment.Left;
            grdControls.VerticalAlignment = VerticalAlignment.Top;
            grdControls.Background = new SolidColorBrush(Colors.LightBlue);
            grdMain.Children.Add(grdControls);

            Label lblBase = new Label();
            lblBase.Content = "Base:";
            lblBase.FontSize = 14;
            lblBase.Margin = new Thickness(65, 23, 0, 0);
            grdControls.Children.Add(lblBase);



            TextBox txtBase = new TextBox();
            txtBase.Name = "txtBase";
            txtBase.Width = 120;
            txtBase.Height = 25;
            txtBase.FontSize = 14;
            txtBase.Background = new SolidColorBrush(Colors.PaleGoldenrod);
            txtBase.HorizontalAlignment = HorizontalAlignment.Left;
            txtBase.Margin = new Thickness(107, 0, 0, 0);

            grdControls.Children.Add(txtBase);
                        
            
            //Important register controls

            grdControls.RegisterName(txtBase.Name, txtBase);
            

            Button btnGo = new Button();
            btnGo.Height = 30;
            btnGo.Width = 75;
            btnGo.Content = "Go";
            btnGo.FontSize = 14;
            btnGo.FontWeight = FontWeights.Bold;
            btnGo.HorizontalAlignment = HorizontalAlignment.Left;
            btnGo.Margin = new Thickness(350, 0, 0, 0);

            grdControls.Children.Add(btnGo);



            //route the button to the method via delegate

            btnGo.Click += BtnGo_Click;


            Grid grdResults = new Grid();
            grdResults.Name = "grdResults";
            grdResults.Width = 310;
            grdResults.Height = 230;
            grdResults.Margin = new Thickness(0, grdControls.Height, 0, 0);                        
            grdResults.Background = new SolidColorBrush(Colors.SlateGray);
            grdMain.Children.Add(grdResults);
            grdResults.RegisterName(grdResults.Name, grdResults);
        }

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox txtBase = (TextBox)this.grdMain.FindName("txtBase");
                Grid grdResults = (Grid)this.grdMain.FindName("grdResults");

                double dblBase;

                if (double.TryParse(txtBase.Text,out dblBase))
                {
                    for (int iCnt = 0; iCnt < 5; iCnt+=1)
                    {
                        double result = Math.Sqrt(dblBase + iCnt);

                        Label lblDisplay = new Label();
                        lblDisplay.Height = 25;
                        lblDisplay.Width = 75;
                        lblDisplay.FontSize = 14;
                        lblDisplay.Background = new SolidColorBrush(Colors.Green);
                        lblDisplay.HorizontalAlignment = HorizontalAlignment.Left;
                        lblDisplay.HorizontalContentAlignment = HorizontalAlignment.Center;
                        lblDisplay.VerticalAlignment = VerticalAlignment.Top;
                        lblDisplay.Content = (dblBase + iCnt).ToString() + " ^ .5";
                        lblDisplay.Margin = new Thickness(40, iCnt * lblDisplay.Height * 2, 0, 0);

                        grdResults.Children.Add(lblDisplay);


                        Label lblResult = new Label();
                        lblResult.Height = 25;
                        lblResult.Width = 75;
                        lblResult.FontSize = 14;
                        lblResult.Background = new SolidColorBrush(Colors.Yellow);
                        lblResult.HorizontalAlignment = HorizontalAlignment.Left;
                        lblResult.HorizontalContentAlignment = HorizontalAlignment.Center;
                        lblResult.VerticalAlignment = VerticalAlignment.Top;
                        lblResult.Content = result.ToString("n2");                                               
                        lblResult.Margin = new Thickness(175, lblDisplay.Margin.Top, 0, 0);

                        grdResults.Children.Add(lblResult);
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
