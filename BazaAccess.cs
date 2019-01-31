using System;
using System.Linq;
using System.Data;
using System.Windows;
using System.Data.OleDb;

namespace Dzienniki
{
    static class BazaAccess
    {
        private static readonly string danePolaczenia;

        static BazaAccess()
        {
            danePolaczenia = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Adresy.AdresBazyAccess();
        }

        public static DataTable PobierzDane(string polecenieSQL)
        {
            OleDbConnection Polaczenie = new OleDbConnection(danePolaczenia);
            Polaczenie.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(polecenieSQL, Polaczenie);
            DataTable tablica = new DataTable();
            adapter.Fill(tablica);
            Polaczenie.Close();
            return tablica;
        }

        public static void AktualizujBaze(string polecenieSQL)
        {
            OleDbConnection Polaczenie = new OleDbConnection(danePolaczenia);
            Polaczenie.Open();
            OleDbCommand polecenie = new OleDbCommand(polecenieSQL, Polaczenie);
            polecenie.ExecuteNonQuery();
            Polaczenie.Close();
        }
    }
}
