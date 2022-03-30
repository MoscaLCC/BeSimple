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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

namespace BragaInstall
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Gestao gestao;
        Window ant;
        String logado;
        float lucro2;
        float custo;
        float estimado;
        public Menu(String logado, Window ant, Gestao g)
        {
            
            this.ant = ant;
            this.gestao = g;
            this.logado = logado;
            this.lucro2 = 0;

            atualiza();

            InitializeComponent();

            foreach (OrdemServico a in gestao.Ordens.Values)
            {
                estimado = estimado + a.vlucro;

                if (a.Estado.Equals("Vendido"))
                {
                    lucro2 = lucro2 + a.vlucro;
                    custo = custo + a.vct;
                }

                if (a.Estado.Equals("Pendente") || a.Estado.Equals("Stock"))
                {
                    custo = custo + a.vct;

                }
                this.lestimado.Content = estimado + " €";
                this.lucro.Content = lucro2 + " €";
                this.CT.Content = custo + " €";

            }

            String n = "aaaaaaaaaaaaaaa";
            listBox.Items.Add(formata("OrdemID", n) + "\t" + formata("Nome", n) + "\t" + formata("Estado", n));
            foreach (OrdemServico a in gestao.Ordens.Values)
            {


                if (!(a.Estado.Equals("Transacao")))
                    listBox.Items.Add(formata(a.Id.ToString(), n) + "\t" + formata(a.Nome, n) + "\t" + formata(a.Estado, n));

            }

        }




        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String sel = listBox.SelectedItem.ToString();
                String[] sep = sel.Split('\t');
                if (!sep[0].Equals("OrdemID       "))
                {
                    OrdemServico ord = gestao.Ordens[int.Parse(sep[0])];
                    Window1 prox = new Window1(ord, logado, ant, gestao);
                    prox.Show();
                    this.Close();
                }
            }
            catch (Exception) { MessageBox.Show("Selecione uma ordem"); }


        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window2 prox = new Window2(logado, ant, gera(), gestao);
            prox.Show();
            this.Close();
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

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
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

        private void button3_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                String[] varias = listBox.SelectedItem.ToString().Split('\t');
                if (!varias[0].Equals("OrdemID"))
                {
                    OrdemServico ordem = gestao.Ordens[int.Parse(varias[0])];


                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Ordem" + varias[0] + ".pdf", FileMode.Create));
                    doc.Open();


                    String pa;
                    iTextSharp.text.Paragraph par;



                    pa = "ID: " + ordem.Id + "                                            Estado:" + ordem.Estado + " \n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);




                    par = new iTextSharp.text.Paragraph("\n\n");
                    doc.Add(par);

                    pa = "Nome: " + ordem.Nome + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);
                    pa = "Morada: " + ordem.morada + "\n\nMarca: " + ordem.marca + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Modelo: " + ordem.modelo + "\n\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor de Compra: " + ordem.vcompra + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor Medio: " + ordem.vmedio + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor de Portes: " + ordem.vportes + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor de Venda: " + ordem.vvenda + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor Vendido: " + ordem.vvendido + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor de Lucro: " + ordem.vlucro + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor Custo Total: " + ordem.vct + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor dos Correios: " + ordem.vcorreios + "\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Valor do Saco: " + ordem.vsaco + "\n\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    pa = "Data:\n" + ordem.Data + "\n\n";
                    par = new iTextSharp.text.Paragraph(pa);
                    doc.Add(par);

                    doc.Close();
                }
            }
            catch (Exception) { MessageBox.Show("Selecione uma ordem ou PDF já Existe"); }

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Window5(gestao, this);
            a.Show();
            this.Close();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Window a = new Window3(logado, this, gestao);
            a.Show();
            this.Close();
        }

        private void atualiza()
        {

            gestao = new Gestao();
            SqlConnection myConnection = new SqlConnection("user id=username;password=password;server=localhost;Trusted_Connection=yes;database=Tita;connection timeout=30");
            try
            {


                myConnection.Open();
                SqlDataReader myReader2 = null;
                SqlCommand myCommando2 = new SqlCommand("select * from Ordem5", myConnection);
                myReader2 = myCommando2.ExecuteReader();

                while (myReader2.Read())
                {


                    String marca = myReader2["Marca"].ToString();
                    string modelo = myReader2["Capa"].ToString();
                    String morada = myReader2["Morada"].ToString();
                    String nome = myReader2["Cliente"].ToString();
                    String estado = myReader2["Estado"].ToString();
                    float vmedio = float.Parse(myReader2["VMedio"].ToString());
                    float vcompra = float.Parse(myReader2["VCompra"].ToString());
                    float vportes = float.Parse(myReader2["VPortes"].ToString());
                    float vvenda = float.Parse(myReader2["VVenda"].ToString());
                    float vvendido = float.Parse(myReader2["VVendido"].ToString());
                    float vlucro = float.Parse(myReader2["VLucro"].ToString());
                    float vct = float.Parse(myReader2["VCT"].ToString());
                    float vcorreio = float.Parse(myReader2["VCorreio"].ToString());
                    float vsaco = float.Parse(myReader2["VSaco"].ToString());
                    String data = myReader2["Data"].ToString();
                    int id = int.Parse(myReader2["id"].ToString());
                    String detalhes = myReader2["Detalhes"].ToString();





                    gestao.AddOrdens(new OrdemServico(nome, id, estado, modelo, marca, morada, vmedio, vcompra, vportes, vvenda, vvendido, vlucro, vct, vcorreio, vsaco, data, detalhes));

                }
                myConnection.Close();


                myConnection.Open();
                SqlDataReader myReader3 = null;
                SqlCommand myCommando3 = new SqlCommand("select * from Capa", myConnection);
                myReader3 = myCommando3.ExecuteReader();

                while (myReader3.Read())
                {


                    String modelo = myReader3["Nome"].ToString();
                    float vmedio = float.Parse(myReader3["VMedio"].ToString());



                    gestao.AddModelos(new Class1(modelo, vmedio));

                }





                myConnection.Close();

            }
            catch (Exception exc)
            {
                System.Windows.MessageBox.Show(exc.ToString());
            }
        }
    }
}
