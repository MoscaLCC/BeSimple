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

        public Gestao()
        {
            
            ordens = new Dictionary<int, OrdemServico>();
        }

       

        public void AddOrdens(OrdemServico a)
        {
            ordens.Add(a.Id, a);
        }


        public void RemOrdem(int Id)
        {
            ordens.Remove(Id);
        }





        public Dictionary<int, OrdemServico> Ordens
        {
            get { return ordens; }
            set { ordens = value; }
        }
    }
}
