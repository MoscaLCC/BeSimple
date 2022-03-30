using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BragaInstall
{
    public class OrdemServico
    {
        private String nome;
        private int id;
        private String estado;
        private String Modelo;
        private String Marca;
        private String Morada;
        private float Vmedio;
        private float Vcompra;
        private float Vportes;
        private float Vvenda;
        private float Vvendido;
        private float Vlucro;
        private float VCT;
        private float Vcorreios;
        private float Vsaco;
        private String data;
        private String detalhes;

        public OrdemServico()
        {
            this.nome = "";
            this.id = 0 ;
            this.estado = "";
            this.Modelo = "";
            this.Marca = "";
            this.Morada = "";
            this.Vmedio = 0;
            this.Vcompra = 0;
            this.Vportes = 0;
            this.Vvenda = 0;
            this.Vvendido = 0;
            this.Vlucro = 0;
            this.VCT = 0;
            this.Vcorreios = 0;
            this.Vsaco = 0;
            this.data = "";
            this.detalhes = "";
    }
        public OrdemServico(String nome, int id, String estado, String Modelo, String Marca, String Morada, float Vmedio, float Vcompra, float Vportes, float Vvenda, float Vvendido, float Vlucro, float VCT, float Vcorreios, float Vsaco, String data, String detalhes)
        {
            this.nome = nome;
            this.id = id;
            this.estado = estado;
            this.Modelo = Modelo;
            this.Marca = Marca;
            this.Morada = Morada;
            this.Vmedio = Vmedio;
            this.Vcompra = Vcompra;
            this.Vportes = Vportes;
            this.Vvenda = Vvenda;
            this.Vvendido = Vvendido;
            this.Vlucro = Vlucro;
            this.VCT = VCT;
            this.Vcorreios = Vcorreios;
            this.Vsaco = Vsaco;
            this.data = data;
            this.detalhes = detalhes;
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public String modelo
        {
            get { return Modelo; }
            set { Modelo = value; }
        }
        public String marca
        {
            get { return Marca; }
            set { Marca = value; }
        }
        public String morada
        {
            get { return Morada; }
            set { Morada = value; }
        }
        public float vmedio
        {
            get { return Vmedio; }
            set { Vmedio = value; }
        }
        public float vcompra
        {
            get { return Vcompra; }
            set { Vcompra = value; }
        }
        public float vportes
        {
            get { return Vportes; }
            set { Vportes = value; }
        }
        public float vvenda
        {
            get { return Vvenda; }
            set { Vvenda = value; }
        }
        public float vvendido
        {
            get { return Vvendido; }
            set { Vvendido = value; }
        }
        public float vlucro
        {
            get { return Vlucro; }
            set { Vlucro = value; }
        }
        public float vct
        {
            get { return VCT; }
            set { VCT = value; }
        }
        public float vcorreios
        {
            get { return Vcorreios; }
            set { Vcorreios = value; }
        }
        public float vsaco
        {
            get { return Vsaco; }
            set { Vsaco = value; }
        }
        public String Data
        {
            get { return data; }
            set { data = value; }
        }
        public String Detalhes
        {
            get { return detalhes; }
            set { detalhes = value; }
        }
    }
}
