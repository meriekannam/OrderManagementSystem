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

namespace OrderManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime tänään = DateTime.Today;
        public MainWindow()
        {
            InitializeComponent();
            dpTilausPvm.SelectedDate = tänään;
            dpToimitusPvm.SelectedDate = tänään.AddDays(14);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TilausOtsikko TilausInstance = new TilausOtsikko();
                TilausInstance.TilausNumero = int.Parse(txtTilausNumero.Text);
                TilausInstance.TilausPvm = dpTilausPvm.SelectedDate.Value;
                TilausInstance.AsiakkaanNimi = txtAsiakasNimi.Text;
                TilausInstance.AsiakasNumero = int.Parse(txtAsiakasNimi.Text);
                TilausInstance.ToimitusOsoite = txtOsoite.Text;
                TilausInstance.ToimitusPvm = dpToimitusPvm.SelectedDate.Value;
                //txtToimitusAika.Text = TilausInstance.LaskeToimitusAika();



                MessageBox.Show("Tilaus tallennettu: Tialusnumero : " + "\r\n" + "Tialusnumero: " + TilausInstance.TilausNumero.ToString()
                + "\r\n" + "Tilauspäivämäärä: " + TilausInstance.TilausPvm.ToString()
                + "\r\n" + "Toimituspäivämäärä: " + TilausInstance.ToimitusPvm.ToString()
                + "\r\n" + "AsiakkaanNimi: " + TilausInstance.AsiakkaanNimi
                + "\r\n" + "AsiakasNumero: " + TilausInstance.AsiakasNumero.ToString()
                + "\r\n" + "ToimitusOsoite: " + TilausInstance.ToimitusOsoite
                
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


    }
}

