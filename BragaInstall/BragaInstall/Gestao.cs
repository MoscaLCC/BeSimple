using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BragaInstall
{
    public class Gestao
    {
       
        private Dictionary<int, OrdemServico> ordens;
        private Dictionary<String, Class1> modelos;

        public Gestao()
        {
            
            ordens = new Dictionary<int, OrdemServico>();
            modelos = new Dictionary<string, Class1>();

        }

       

        public void AddOrdens(OrdemServico a)
        {
            ordens.Add(a.Id, a);
        }


        public void RemOrdem(int Id)
        {
            ordens.Remove(Id);
        }

        public void AddModelos(Class1 b)
        {
            modelos.Add(b.Nome, b);
        }


        public void RemModelos(String nome)
        {
            modelos.Remove(nome);
        }





        public Dictionary<int, OrdemServico> Ordens
        {
            get { return ordens; }
            set { ordens = value; }
        }

        public Dictionary<String, Class1> Modelos
        {
            get { return modelos; }
            set { modelos = value; }
        }
    }
}
