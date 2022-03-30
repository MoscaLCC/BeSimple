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
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        Gestao gestao;
        public Window7(Gestao gestao)
        {
            this.gestao = gestao;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window5 novo = new Window5(gestao, this);
            novo.Show();
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("user id=username;password=password;server=localhost;Trusted_Connection=yes;database=Tita;connection timeout=30");
            SqlCommand myCommand = null;
            
              
            try
            {
                String nom = desc.Text;
                int Id = int.Parse(gera());
                String mor = "";
                String est = "Transacao";
                String mod = "";
                foreach (Class1 a in gestao.Modelos.Values)
                {
                    mod = a.Nome;
                }
                
                String mar = "";
                float vme = 0;
                float vco = 0;
                float vpo = 0;
                float vve = float.Parse(credito.Text);
                float vcr = 0;
                float vsa = 0;
                String da = data.Text;
                float vvd = 0;
                float ct = float.Parse(debito.Text);
                float vlu = vve - ct;
                String dt = "";

                try
                {
                    myConnection.Open();


                    myCommand = new SqlCommand("INSERT INTO Ordem5 (Marca, Capa, Morada, Cliente, Estado, VMedio, VCompra, VPortes, VVenda, VVendido, VLucro, VCT, VCorreio, VSaco, Data, id, Detalhes) " +
                                     "Values ('" + mar + "','" + mod + "','" + mor + "','" + nom + "','" + est + "','" + vme.ToString() + "','" + vco.ToString() + "','" + vpo.ToString() + "','" + vve.ToString() + "','" + vvd.ToString() + "','" + vlu.ToString() + "','" + ct.ToString() + "','" + vcr.ToString() + "','" + vsa.ToString() + "','" + da + "','" + Id + "','" + dt + "')", myConnection);

                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                catch (Exception ) { MessageBox.Show("Adicio Modelos de Capas Primeiro!! \n\n Se o erro presistir contacte o tecnico"); }

                this.gestao.AddOrdens(new OrdemServico(nom, Id, est, mod, mar, mor, vme, vco, vpo, vve, vvd, vlu, ct, vcr, vsa, da, dt));

                MessageBox.Show("Transação adicionada com sucesso");
                Window5 novo = new Window5(gestao, this);
                novo.Show();
                Close();
            }
            catch (Exception) { MessageBox.Show("Dados Incorretos"); }
        }

        private String gera()
        {
            Random rdn = new Random();

            int x = 0;
            String strNumeroaleatorio = "" + rdn.Next(0, 199999);

            while (x == 0 || existe(strNumeroaleatorio))
            {
                strNumeroaleatorio = "" + rdn.Next(0, 199999);
                x = 1;

            }

            return strNumeroaleatorio;
        }

        private Boolean existe(String i)
        {
            return gestao.Ordens.ContainsKey(int.Parse(i));
        }
    }
    }

