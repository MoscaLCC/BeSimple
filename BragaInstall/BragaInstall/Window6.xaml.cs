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
using System.Data.SqlClient;

namespace BragaInstall
{
    /// <summary>
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        Gestao gestao;
        public Window6(Gestao gestao)
        {
            this.gestao = gestao;
            InitializeComponent();

            String n = "aaaaaaaaaaaaaaa";
            listBox.Items.Add(formata("OrdemID",n) + "\t" + formata("Descrição", n) + "\t" + formata("Credito", n) + "\t" + formata("Debito", n) + "\t" + formata("Data", n));
            foreach (OrdemServico a in gestao.Ordens.Values)
            {
                
                    listBox.Items.Add(formata(a.Id.ToString(), n) + "\t" + formata(a.Nome, n) + "\t" + formata(a.vvenda.ToString(), n) + "\t" + formata(a.vct.ToString(), n) + "\t" + formata(a.Data, n));

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Window5(gestao, this);
            a.Show();
            this.Close();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private string formata(string s, string n)
        {


            int i = 0;


            if (s.Length <= 15)
            {
                n = s;


                for (i = s.Length; i + 1 < 15; i++)
                {

                    n = n + ' ';

                }

                n = n + '\t';

            }

            else
            {

                n = s.Substring(0, 13);
                n = n + '\t';
            }


            return n;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String sel = listBox.SelectedItem.ToString();
                String[] sep = sel.Split('\t');
                if (!sep[0].Equals("OrdemID"))
                {

                    OrdemServico ord = gestao.Ordens[int.Parse(sep[0])];
                    MessageBox.Show(ord.Id.ToString());
                    listBox.Items.Remove(listBox.SelectedItem);
                    gestao.RemOrdem(ord.Id);

                    SqlConnection myConnection = new SqlConnection("user id=username;password=password;server=localhost;Trusted_Connection=yes;database=Tita;connection timeout=30");
                    SqlCommand myCommand = null;
                    try
                    {
                        myConnection.Open();
                        myCommand = new SqlCommand("DELETE FROM Ordem5 WHERE id=" + ord.Id + ";", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                    }
                    catch (Exception excep) { MessageBox.Show(excep.ToString()); }
                }
            }
            catch (Exception) { MessageBox.Show("Selecione uma ordem"); }

        }
    }
}
