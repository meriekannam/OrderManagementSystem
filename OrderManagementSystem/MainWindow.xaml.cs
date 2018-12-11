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
        decimal RivinSummaYht =0;
        public MainWindow()
        {
            InitializeComponent();
            dpTilausPvm.SelectedDate = tänään;
            dpToimitusPvm.SelectedDate = tänään.AddDays(14);
            
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Binding = new Binding("TilausNumero");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Binding = new Binding("TuoteNumero");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Binding = new Binding("TuoteNimi");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Binding = new Binding("Maara");
            DataGridTextColumn textColumn5 = new DataGridTextColumn();
            textColumn5.Binding = new Binding("AHinta");
            DataGridTextColumn textColumn6 = new DataGridTextColumn();
            textColumn6.Binding = new Binding("RivinSumma");
            //DataGridin otsikot + edellä "ilmaan" luotujen sarakkeiden sijoitus konkreettiseen DataGridiin, joka on luotu formille
            textColumn1.Header = "Tilauksen numero";
            dgTilausRivit.Columns.Add(textColumn1);
            textColumn2.Header = "Tuotenumero";
            dgTilausRivit.Columns.Add(textColumn2);
            textColumn3.Header = "Tuotenimi";
            dgTilausRivit.Columns.Add(textColumn3);
            textColumn4.Header = "Määrä";
            dgTilausRivit.Columns.Add(textColumn4);
            textColumn5.Header = "AHinta";
            dgTilausRivit.Columns.Add(textColumn5);
            textColumn6.Header = "RivinSumma";
            dgTilausRivit.Columns.Add(textColumn6);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TilausOtsikko TilausInstance = new TilausOtsikko();
                TilausInstance.TilausNumero = int.Parse(txtTilausNumero.Text);
                TilausInstance.TilausPvm = dpTilausPvm.SelectedDate.Value;
                TilausInstance.AsiakkaanNimi = txtAsiakasNimi.Text;
                TilausInstance.AsiakasNumero = int.Parse(txtAsiakasNumero.Text);
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
            txtTuoteNumero.Clear();
            txtTuoteNimi.Clear();
            txtMaara.Clear();
            txtAHinta.Clear();

        }

        private void BtnLisääRivi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TilausRivi TilausR = new TilausRivi();
                TilausR.TilausNumero = int.Parse(txtTilausNumero.Text);
                TilausR.TuoteNumero = int.Parse(txtTuoteNumero.Text);
                TilausR.TuoteNimi = txtTuoteNimi.Text;
                TilausR.Maara = int.Parse(txtMaara.Text);
                TilausR.AHinta = int.Parse(txtAHinta.Text);

                MessageBox.Show("Tilausrivi tallennettu: Tialusnumero : " + "\r\n" + "Tialusnumero: " + TilausR.TilausNumero.ToString()
                   + "\r\n" + "TuoteNumero: " + TilausR.TuoteNumero.ToString()
                   + "\r\n" + "TuoteNimi: " + TilausR.TuoteNimi
                   + "\r\n" + "Määrä: " + TilausR.Maara
                   + "\r\n" + "Hinta: " + TilausR.AHinta.ToString()
                   );
                RivinSummaYht += TilausR.RiviSumma();
                txtRiviSumma.Text = RivinSummaYht.ToString();
                dgTilausRivit.Items.Add(TilausR);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

       
    }
}

