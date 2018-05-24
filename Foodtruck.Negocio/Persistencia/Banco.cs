using Foodtruck.Negocio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Foodtruck.Negocio.Persistencia
{
    public class Banco
    {
        private String NomeArquivo = "banco.xml";

        public List<Cliente> Clientes;
        public List<Bebida> Bebidas;
        public List<Lanche> Lanches;
        public List<Pedido> Pedidos;

        public Banco()
        {
            this.Clientes = new List<Cliente>();
            this.Bebidas = new List<Bebida>();
            this.Lanches = new List<Lanche>();
            this.Pedidos = new List<Pedido>();

            this.CarregarDados();
        }

        public void SalvarDados()
        {
            Dados dados = new Dados();
            dados.Clientes = this.Clientes;
            dados.Bebidas = this.Bebidas;
            dados.Lanches = this.Lanches;
            dados.Pedidos = this.Pedidos;
            StreamWriter arquivo = new StreamWriter(this.NomeArquivo);
            XmlSerializer serializer = new XmlSerializer(typeof(Dados));
            serializer.Serialize(arquivo, dados);
            arquivo.Close();
        }

        public void CarregarDados()
        {
            if(File.Exists(NomeArquivo))
            {
                FileStream arquivo = File.OpenRead(NomeArquivo);
                XmlSerializer serializer = new XmlSerializer(typeof(Dados));
                Dados dados = serializer.Deserialize(arquivo) as Dados;
                this.Clientes = dados.Clientes;
                this.Bebidas = dados.Bebidas;
                this.Lanches = dados.Lanches;
                this.Pedidos = dados.Pedidos;
            }
        }
    }
}
