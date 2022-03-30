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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {

        Gestao gestao;
        Window ant;
        string logado;

        public Window4(String Logado, Window ant, Gestao g)
        {

            this.gestao = g;
            this.ant = ant;
            this.logado = Logado;

            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Window3(logado, this, gestao);
            a.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("user id=username;password=password;server=localhost;Trusted_Connection=yes;database=Tita;connection timeout=30");
            SqlCommand myCommand = null;
           
                

           
            try
            {
                String nom = nome.Text;
                
                float vme = float.Parse(vmedio.Text);
               

                try
                {
                    myConnection.Open();


                    myCommand = new SqlCommand("INSERT INTO Capa (Nome, VMedio) " +
                                     "Values ('" + nom + "','" + vme + "')", myConnection);

                    myCommand.ExecuteNonQuery();
                    myConnection.Close();


    }
                catch (Exception ) { MessageBox.Show("Nome existente!!"); }

                this.gestao.AddModelos(new Class1(nom, vme));

                MessageBox.Show("Modelo adicionada com sucesso");
                Window novo = new Window3 (logado, ant, gestao);
                novo.Show();
                Close();
            }
            catch (Exception) { MessageBox.Show("Dados Incorretos"); }
        }

        private void nome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void vmedio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }

