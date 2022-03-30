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

namespace BragaInstall
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Gestao gestao;
        Window ant;
        String logado;
        OrdemServico ordem;

        public Window1(OrdemServico ordem, String logado, Window ant, Gestao gestao)
        {
            this.gestao = gestao;
            this.ant = ant;
            this.logado = logado;
            this.ordem = ordem;

            InitializeComponent();

            this.id.Content = ordem.Id;
            this.nome.Content = ordem.Nome;
           
            
            this.estado.Content = ordem.Estado;

            this.modelo.Content = ordem.modelo;
            this.marca.Content = ordem.marca;
            this.morada.Content = ordem.morada;
            this.Vmedio.Content = ordem.vmedio + "€";
            this.Vcompra.Content = ordem.vcompra + "€";
            this.Vportes.Content = ordem.vportes + "€";
            this.Vvenda.Content = ordem.vvenda + "€";
            this.Vvendido.Content = ordem.vvendido + "€";
            this.Vlucro.Content = ordem.vlucro + "€";
            this.VCT.Content = ordem.vct + "€";
            this.Vcorreios.Content = ordem.vcorreios + "€";
            this.Vsaco.Content = ordem.vsaco + "€";
            this.data.Content = ordem.Data;
            
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window2 a = new Window2(logado, this, ordem, gestao);
            a.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Menu novo = new Menu(logado, ant, gestao);
            novo.Show();
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ordem.Detalhes);
        }
    }
}
