using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficial.models
{
    public class Carro
    {
        private int _id;

        private String _modelo;

        private int _ano;

        private int _idPessoa;

        public Carro() { }

        public Carro(string modelo, int ano)
        {
            this._modelo = modelo;
            this._ano = ano;
        }

        public Carro(int id, string modelo, int ano)
        {
            this._id = id;
            this._modelo = modelo;
            this._ano = ano;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        public int Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }

        public int IdPessoa
        {
            get { return _idPessoa; }
            set { _idPessoa = value; }
        }

        public String ToString(Carro carro)
        {
             String texto = "";

            texto = "modelo:" + carro.Modelo + ",ano:" + carro.Ano + ";";

            return texto;
        }

    }
}
