using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
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

namespace Dzienniki
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Aktywacja okna
        /// </summary>

        private void Window_Activated(object sender, EventArgs e)
        {
            WczytajZleceniaZBazy();
        }

        /// <summary>
        ///  Obsługa Kontrolek
        /// </summary>

        private void CBzlecenia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.CBzlecenia.Items.Refresh();
            WczytajGrupyZBazy(this.CBzlecenia.Text);
            this.CBgrupy.Text = "Wybierz grupę ...";
        }

        private void CBgrupy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ButtonGenerowanieDz.IsEnabled = true;
            this.ButtonOpisSpoin.IsEnabled = true;
        }

        private void ButtonZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///  Metody
        /// </summary>

        private void WczytajZleceniaZBazy()
        {
            try
            {
                this.CBzlecenia.Items.Clear();
                DataTable dane = BazaAccess.PobierzDane("SELECT nrZlecenia FROM zlecenia");
                foreach (DataRow row in dane.Rows)
                    this.CBzlecenia.Items.Add(row[0].ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd połączenia z bazą danych! \n" + e.Message);
            }
        }

        private void WczytajGrupyZBazy(string zlec)
        {
            try
            {
                this.CBgrupy.Items.Clear();
                DataTable dane = BazaAccess.PobierzDane("SELECT nazwaGrupy FROM grupy WHERE nrZlecenia='"+zlec+"' ORDER BY idGrupy");
                foreach (DataRow row in dane.Rows)
                    this.CBgrupy.Items.Add(row[0].ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd połączenia z bazą danych! \n" + e.Message);
            }
        }

    }
}
