using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _20221207
{
    /// <summary>
    /// Interaction logic for update.xaml
    /// </summary>
    public partial class update : Window
    {
        public update()
        {
            InitializeComponent();
            string connentionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=konyvtarak;";
            MySqlConnection databaseConnection = new MySqlConnection(connentionString);
            databaseConnection.Open();
            string query = "SELECT * FROM konyvtarak;";
            MySqlCommand myadat = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = myadat.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string seged = reader.GetString(1);
                    seged += "\t" + reader.GetString(2);
                    seged += "\t" + reader.GetString(3);
                    cb_lista.Items.Add(seged);

                }
            }
            databaseConnection.Close();
        }

        private void btn_valtoztat_Click(object sender, RoutedEventArgs e)
        {
            if (cb_lista.SelectedIndex == -1)
            {
                MessageBox.Show("Nem választottál ki semmit");

            }
            else
            {
                string[] darabol = cb_lista.SelectedItem.ToString().Split('\t');
                cb_valtoztat.Items.Add("Név: " + darabol[0]);
                cb_valtoztat.Items.Add("Irsz: " + darabol[1]);
                cb_valtoztat.Items.Add("Cím: " + darabol[2]);
                cb_valtoztat.SelectedIndex = 0;
                cb_valtoztat.Visibility = Visibility.Visible;
                cb_valtoztat.IsEnabled = true;
                cb_lista.IsEnabled = false;
                btn_valtoztat.IsEnabled = false;
            }
        }

        private void cb_valtoztat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txt_adat.Text = cb_valtoztat.SelectedItem.ToString();
        }

        private void cb_valtoztat_Selected(object sender, RoutedEventArgs e)
        {
            txt_adat.Text = cb_valtoztat.SelectedItem.ToString();
        }

        private void cb_valtoztat_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void cb_valtoztat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_adat.Text = cb_valtoztat.SelectedItem.ToString();
            if (cb_valtoztat.SelectedItem.ToString()[0] == 'I')
            {
                txt_adat.Text = cb_valtoztat.SelectedItem.ToString().Substring(6);
            }
            else
            {
                txt_adat.Text = cb_valtoztat.SelectedItem.ToString().Substring(5);
            }
            btn_fr.Visibility = Visibility.Visible;
            txt_adat.Visibility = Visibility.Visible;
            lbl_want.Visibility = Visibility.Visible;
            lbl_tothis.Visibility = Visibility.Visible;

        }

        
        private void btn_fr_Click(object sender, RoutedEventArgs e)
        {
            string connentionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=konyvtarak;";
            MySqlConnection databaseConnection = new MySqlConnection(connentionString);
            switch (cb_valtoztat.SelectedIndex)
            {
                //HF: UPDATE megírása
                case 0://névc
                    databaseConnection.Open();
                    MySqlCommand adat = databaseConnection.CreateCommand();
                    adat.CommandText = "UPDATE konyvtarak SET konyvtarNev = '" + txt_adat.Text + "' WHERE konyvtarak.id='" + cb_valtoztat.SelectedIndex + "';";
                    MessageBox.Show(adat.CommandText);
                    adat.ExecuteNonQuery();
                    databaseConnection.Close();
                    MessageBox.Show("Mentés sikerült!");
                    break;

                case 1://irsz
                    int irsz = Convert.ToInt32(txt_adat.Text);
                    databaseConnection.Open();
                    MySqlCommand adat1 = databaseConnection.CreateCommand();
                    adat1.CommandText = "UPDATE konyvtarak SET irsz = '" + irsz + "' WHERE konyvtarak.id='" + cb_valtoztat.SelectedIndex + "';";
                    MessageBox.Show(adat1.CommandText);
                    adat1.ExecuteNonQuery();
                    databaseConnection.Close();
                    MessageBox.Show("Mentés sikerült!");
                    break;

                case 2://cím
                    databaseConnection.Open();
                    MySqlCommand adat2 = databaseConnection.CreateCommand();
                    adat2.CommandText = "UPDATE konyvtarak SET cim = '" + txt_adat.Text + "' WHERE konyvtarak.id='" + cb_valtoztat.SelectedIndex + "';";
                    MessageBox.Show(adat2.CommandText);
                    adat2.ExecuteNonQuery();
                    databaseConnection.Close();
                    MessageBox.Show("Mentés sikerült!");
                    break;
            }

            btn_fr.Visibility = Visibility.Hidden;
            txt_adat.Visibility = Visibility.Hidden;
            lbl_want.Visibility = Visibility.Hidden;
            lbl_tothis.Visibility = Visibility.Hidden;
            cb_valtoztat.Visibility = Visibility.Hidden;
            cb_lista.IsEnabled = true;
            btn_valtoztat.IsEnabled = true;

        }
    }
}
