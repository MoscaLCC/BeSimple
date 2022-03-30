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
        public Menu(String logado,Window ant, Gestao g)
        {
            this.ant = ant;
            this.gestao = g;
            this.logado = logado;
            this.lucro2 = 0;
            InitializeComponent();

            foreach(OrdemServico a in gestao.Ordens.Values)
            {
                if (a.Estado.Equals(true))
                {
                    lucro2 = lucro2 + a.vlucro;
                    custo = custo + a.vct;
                }

                else {
                    custo = custo + a.vct;
                }

                this.lucro.Content = lucro2;
                this.CT.Content = custo;

            }

            listBox.Items.Add("OrdemID\tModelo\t\tMarca\t\tNome\t\t\tEstado");
            foreach (OrdemServico a in gestao.Ordens.Values)
            {
                

                if (a.Estado)
                    listBox.Items.Add(a.Id+"\t\t"+a.modelo + "\t"+ a.marca + "\t" + a.Nome + "\t\tVendido\t");
                else
                    listBox.Items.Add(a.Id + "\t\t" + a.modelo + "\t" + a.marca + "\t" + a.Nome + "\t\tPendente\t");
            }
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
                    Window1 prox = new Window1(ord, logado, ant, gestao);
                    prox.Show();
                    this.Close();
                }
            }
            catch(Exception) { MessageBox.Show("Selecione uma ordem"); }
            
            
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window2 prox = new Window2(logado,ant, gera(),gestao);
            prox.Show();
            this.Close();
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
                        myCommand = new SqlCommand("DELETE FROM Ordem3 WHERE id=" + ord.Id + ";", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                    }
                    catch (Exception excep) { MessageBox.Show(excep.ToString()); }
                }
            }
            catch(Exception) { MessageBox.Show("Selecione uma ordem"); }
            
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

                    if (ordem.Estado)
                    {
                        pa = "ID: " + ordem.Id + "                                            Estado: Vendido\n";
                        par = new iTextSharp.text.Paragraph(pa);
                        doc.Add(par);
                    }

                    else
                    {
                        pa = "ID: " + ordem.Id + "                                            Estado: Pendente\n";
                        par = new iTextSharp.text.Paragraph(pa);
                        doc.Add(par);
                    }

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
            this.Close();
        }
    }
}
