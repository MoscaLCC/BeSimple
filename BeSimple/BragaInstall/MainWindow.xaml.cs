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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace BragaInstall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gestao gestao;
        String imaLoc = "";

        public MainWindow()
        {
            gestao = new Gestao();
            SqlConnection myConnection = new SqlConnection("user id=username;password=password;server=localhost;Trusted_Connection=yes;database=Tita;connection timeout=30");
            try
            {

                
                myConnection.Open();
                SqlDataReader myReader2 = null;
                SqlCommand myCommando2 = new SqlCommand("select * from Ordem3", myConnection);
                myReader2 = myCommando2.ExecuteReader();
                
                while (myReader2.Read())
                {
                   
                    
                    String marca = myReader2["Marca"].ToString();
                    string modelo = myReader2["Modelo"].ToString();
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




                    if (estado.Equals("True"))
                        gestao.AddOrdens(new OrdemServico(nome, id, true, modelo, marca, morada, vmedio, vcompra, vportes, vvenda, vvendido, vlucro, vct, vcorreio, vsaco, data));
                    else
                        gestao.AddOrdens(new OrdemServico(nome, id, false, modelo, marca, morada, vmedio, vcompra, vportes, vvenda, vvendido, vlucro, vct, vcorreio, vsaco, data));
                }
                myConnection.Close();

                InitializeComponent();

                System.Drawing.Bitmap bitmap1 = BragaInstall.Properties.Resources.BeSimple;

                BitmapSource bitSrc = null;

                var hBitmap = bitmap1.GetHbitmap();
                
                bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

                this.image.Source = bitSrc;
            }
            catch (Exception exc)
            {
                System.Windows.MessageBox.Show(exc.ToString());
            }
        }
        public MainWindow(Gestao gest)
        {
            this.gestao = gest;
            InitializeComponent();
            System.Drawing.Bitmap bitmap1 = BragaInstall.Properties.Resources.BeSimple;

            BitmapSource bitSrc = null;

            var hBitmap = bitmap1.GetHbitmap();

            bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            this.image.Source = bitSrc;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            String utilizador = textBox.Text;
            String password = passwordBox.Password;
          
            if ( utilizador.Equals("besimple") && password.Equals("Tita9800000"))
            {
                String logado = "besimple";
                Menu a = new Menu(logado, this, gestao);
                a.Show();
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("DADOS INCORRETOS");
            }            
           
        }

        

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
