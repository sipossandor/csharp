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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace _20221207
{
    /// <summary>
    /// Interaction logic for hozzaadas.xaml
    /// </summary>
    public partial class hozzaadas : Window
    {
        public hozzaadas()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_irsz.Text,out int irsz) && txt_nev.Text!="" 
                && txt_cim.Text!="" && txt_irsz.Text.Length==4 && txt_irsz.Text[0]!='0')
            {
                string connentionString = "datasource=127.0.0.1;port=3306;" +
               "username=root;password=;database=konyvtarak;";
                MySqlConnection databaseConnection = new MySqlConnection(connentionString);
                databaseConnection.Open();
                string query = "SELECT * FROM konyvtarak WHERE konyvtarNev='"+txt_nev.Text+"' " +
                    "and cim='"+txt_cim.Text+"' and irsz='"+txt_irsz.Text+"';";
                MySqlCommand myadat=new MySqlCommand(query, databaseConnection);
                MySqlDataReader reader=myadat.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Már benne van");
                    databaseConnection.Close();
                }
                else
                {
                    databaseConnection.Close();
                    databaseConnection.Open();
                    query = "Select irsz from telepulesek where irsz='" + txt_irsz.Text + "';";
                    myadat=new MySqlCommand(query, databaseConnection);
                    reader=myadat.ExecuteReader();
                    if (reader.HasRows)
                    {
                        databaseConnection.Close();
                        databaseConnection.Open();
                        MySqlCommand adat = databaseConnection.CreateCommand();
                        adat.CommandText = "insert into konyvtarak (konyvtarNev,irsz,cim) " +
                            "values ('" + txt_nev.Text + "','" + txt_irsz.Text + "','" + txt_cim.Text + "');";
                        MessageBox.Show(adat.CommandText);
                        adat.ExecuteNonQuery();
                        databaseConnection.Close();
                        MessageBox.Show("Sikeres mentés");
                    }
                    else
                    {
                        MessageBox.Show("Nem létező irsz");
                    }

                }
            }
            else
            {
                MessageBox.Show("Hibás adat");
            }
        }
    }
}
