using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BragaInstall
{
    public class Class1
    {

        private String nome;
        private float vmedio;

        public Class1()
        {
            this.nome = "";
            this.vmedio = 0;
          
        }
        public Class1(String nome, float Vmedio)
        {
            this.nome = nome;
           
            this.vmedio = Vmedio;
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
      
        public float Vmedio
        {
            get { return vmedio; }
            set { vmedio = value; }
        }
        

            

            
            }
        }
    



