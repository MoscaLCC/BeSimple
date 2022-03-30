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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        Gestao gestao;
        Window ant;
        public Window5(Gestao g, Window ant)
        {
            this.gestao = g;
            this.ant = ant;

            float credit = 0;
            float debit = 0;
            float sald = 0;

            foreach(OrdemServico a in gestao.Ordens.Values )
            {
                debit = debit + a.vct;
                credit = credit + a.vvenda;

            }

            sald = credit - debit; 


            InitializeComponent();

            credito.Content = credit;
            debito.Content = debit;
            saldo.Content = sald;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window6 a = new Window6(gestao);
            a.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Menu a = new Menu("", this, gestao);
            a.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window7 a = new Window7(gestao);
            a.Show();
            this.Close();
        }
    }
}
