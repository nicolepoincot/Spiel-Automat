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

namespace Spiel_Automat
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int guthaben , einsatz, gewinn;
            int z1, z2, z3;
            guthaben = Convert.ToInt32(Guthaben_1.Content);
            einsatz = Convert.ToInt32(txt_Einsatz.Text);
            if (einsatz <= 0 || einsatz > guthaben)
            {
                MessageBox.Show("Der Einsatz muss zwischen 0 und Guthaben liegen!", "Fehler!");
            }
            else
            {
                Random r = new Random();
                z1 = r.Next(1, 10);
                z2 = r.Next(1, 10);
                z3 = r.Next(1, 10);
                zahl1.Content = z1;
                zahl2.Content = z2;
                zahl3.Content = z3;
                guthaben -= einsatz;

                Guthaben_1.Content = guthaben;
                if (z1 == z2 || z2 == z3 || z3 == z1)
                {
                    gewinn = einsatz + 3;
                    guthaben += gewinn;
                    MessageBox.Show("Kleiner Gewinn", "Gewonnen!");
                    Guthaben_1.Content = guthaben;

                }
                else if (z1==z2 && z2==z3)

                {
                    if (z1==7)
                    {
                        gewinn = einsatz * 7;
                        guthaben += gewinn;
                        MessageBox.Show("grossHauptgewinn!", "Gewonnen!");
                        Guthaben_1.Content = guthaben;
                    }
                    gewinn = einsatz * 3;
                    guthaben += gewinn;
                    MessageBox.Show("Hauptgewinn!", "Gewonnen!");
                    Guthaben_1.Content=guthaben;
                }
                else
                {
                    MessageBox.Show("Leider kein Gewinn.", "Schade! ");
                }
                if (guthaben<=0)
                {
                    //Messagebox konfigurieren
                    string Messageboxtext = "Das Spiel ist vorbei.";
                    string Titel = "Ende.";
                    MessageBoxButton knopf = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;
                    //Messagebox anzeigen
                    MessageBoxResult ergebnis = MessageBox.Show(Messageboxtext, Titel, knopf, icon);
                    //Auswahl auswerten
                    switch (ergebnis)
                    {
                        case MessageBoxResult.Yes:
                            guthaben = 5;

                            Guthaben_1.Content = guthaben;
                            zahl1.Content =0;
                            zahl2.Content = 0;
                            zahl3.Content = 0;
                            txt_Einsatz.Text = "";

                            break;
                        case MessageBoxResult.No:
                            Application.Current.Shutdown();
                            break;
                    }
                }


            }
        


        }
       
       
    }
}
