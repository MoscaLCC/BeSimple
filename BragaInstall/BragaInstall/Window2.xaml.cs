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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Window ant;
        Gestao gestao;
        string ide;
        String logado;

        public Window2(String logado, Window ant, OrdemServico ordem, Gestao gestao)
        {
            this.ant = ant;
            this.gestao = gestao;

            InitializeComponent();

            this.logado = logado;
            this.ide = ordem.Id.ToString();

            this.id.Content = ordem.Id;
            this.nome.Text = ordem.Nome;
            this.estado.Items.Add("Pendente");
            this.estado.Items.Add("Vendido");
            this.estado.Items.Add("Stock");
            this.estado.SelectedItem = ordem.Estado;

            foreach (Class1 b in gestao.Modelos.Values)
            {
                this.modelos.Items.Add(b.Nome);
            }
        

            this.marca.Text = ordem.marca;
             this.morada.Text = ordem.morada;
             this.Vmedio.Text = ordem.vmedio.ToString();
             this.Vcompra.Text = ordem.vcompra.ToString();
             this.Vportes.Text = ordem.vportes.ToString();
             this.Vvenda.Text = ordem.vvenda.ToString();
             this.Vvendido.Content = ordem.vvendido;
             this.Vlucro.Content = ordem.vlucro;
             this.VCT.Content = ordem.vct;
             this.Vcorreios.Text = ordem.vcorreios.ToString();
             this.Vsaco.Text = ordem.vsaco.ToString();
             this.data.Text = ordem.Data;
            this.detalhes.Text = ordem.Detalhes;


        }

        public Window2(String logado, Window ant, String idrec, Gestao gestao)
        {
            this.ant = ant;
            this.gestao = gestao;
            InitializeComponent();
            this.logado = logado;
            this.ide = idrec;

            foreach (Class1 b in gestao.Modelos.Values)
            {
                this.modelos.Items.Add(b.Nome);
            }

            this.estado.Items.Add("Pendente");
            this.estado.Items.Add("Vendido");
            this.estado.Items.Add("Stock");
            this.estado.SelectedItem = "Stock";
            this.id.Content = idrec;
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("user id=username;password=password;server=localhost;Trusted_Connection=yes;database=Tita;connection timeout=30");
            SqlCommand myCommand = null;
            if (gestao.Ordens.ContainsKey(int.Parse(ide)))
            {
                try
                {
                    myConnection.Open();
                    gestao.Ordens.Remove(int.Parse(ide));
                    myCommand = new SqlCommand("DELETE FROM Ordem5 WHERE id=" + ide+";", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                catch (Exception) { MessageBox.Show("Erro"); }
                
            }
            try
            {
                String nom = nome.Text;
                int Id = int.Parse(ide);
                String mor = morada.Text;
                String est = estado.SelectedItem.ToString();
                String mod = modelos.SelectedItem.ToString();
                String mar = marca.Text;
                float vme = float.Parse(Vmedio.Text);
                float vco = float.Parse(Vcompra.Text);
                float vpo = float.Parse(Vportes.Text);
                float vve = float.Parse(Vvenda.Text);
                float vcr = float.Parse(Vcorreios.Text);
                float vsa = float.Parse(Vsaco.Text);
                String da = data.Text;
                float vvd = vme + vpo + 2;
                float ct = vco + vcr + vsa;
                float vlu = vve - ct;
                String dt = detalhes.Text;

                try
                {
                    myConnection.Open();
                
                   
                        myCommand = new SqlCommand("INSERT INTO Ordem5 (Marca, Capa, Morada, Cliente, Estado, VMedio, VCompra, VPortes, VVenda, VVendido, VLucro, VCT, VCorreio, VSaco, Data, id, Detalhes) " +
                                         "Values ('" + mar + "','" + mod + "','" + mor + "','" + nom + "','" + est + "','" + vme.ToString() + "','" + vco.ToString() + "','" + vpo.ToString() + "','" + vve.ToString() + "','" + vvd.ToString() + "','" + vlu.ToString() + "','" + ct.ToString() + "','" + vcr.ToString() + "','" + vsa.ToString() + "','" + da + "','" + Id + "','" + dt + "')", myConnection);
                   
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                catch (Exception excep) { MessageBox.Show(excep.ToString()); }
                
                    this.gestao.AddOrdens(new OrdemServico(nom, Id, est, mod, mar, mor, vme, vco, vpo, vve, vvd, vlu, ct, vcr, vsa, da, dt)); 
                
                MessageBox.Show("Ordem adicionada com sucesso");
                Menu novo = new Menu(logado, ant, gestao);
                novo.Show();
                Close();
            }
            catch (Exception) { MessageBox.Show("Dados Incorretos"); }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Menu novo = new Menu(logado, ant, gestao);
            novo.Show();
            Close();
        }

        private void detalhes_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }
    }

        
    }

