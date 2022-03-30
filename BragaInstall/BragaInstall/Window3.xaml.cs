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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Gestao gestao;
        Window ant;
        String logado;

        public Window3(String Logado, Window ant, Gestao g)
        {
            this.logado = Logado;
            this.gestao = g;
            this.ant = ant;

            InitializeComponent();



            String n = "aaaaaaaaaaaaaaa";
            listBox.Items.Add(formata("Nome", n) + "\t" + formata("Valor Medio", n));
            foreach (Class1 a in gestao.Modelos.Values)
            {


                
                    listBox.Items.Add(formata(a.Nome, n) + "\t" + formata(a.Vmedio.ToString(), n) );

            }

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Window4(logado, ant, gestao);
            a.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                String sel = listBox.SelectedItem.ToString();
                String[] sep = sel.Split('\t');
                if (!sep[0].Equals("Nome"))
                {
                    MessageBox.Show(sep[0]);


                    gestao.RemModelos(sep[0]);
                        
                    
                    listBox.Items.Remove(listBox.SelectedItem);
                    

                    SqlConnection myConnection = new SqlConnection("user id=username;password=password;server=localhost;Trusted_Connection=yes;database=Tita;connection timeout=30");
                    SqlCommand myCommand = null;
                    try
                    {
                        myConnection.Open();
                        myCommand = new SqlCommand("DELETE FROM Capa WHERE Nome ='"+ sep[0]+ "' ;", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                    }
                    catch (Exception excep) { MessageBox.Show(excep.ToString()); }
                }
            }
            catch (Exception) { MessageBox.Show("Selecione uma ordem"); }


        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Menu a = new Menu(logado, ant, gestao);
            a.Show();
            this.Close();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

       
    }

