using System;
using System.Collections.Generic;
using System.Linq;

namespace Oficial.models
{
    public class Pessoa
    {
        private int _id;

        private String _nome;

        private String _cpf;

        private List<Carro> _carros = new List<Carro>();

        public int Id { get { return _id; } set { _id = value; } }

        public String Nome { get { return _nome; } set { _nome = value; } }

        public String Cpf { get { return _cpf; } set { _cpf = value; } }

        public List<Carro> Carros { get { return _carros; } set { _carros = value; } }

        public void Carro(int index, Carro carro)
        {
            this._carros[index] = carro;
        }

        public void AddCarro(Carro carro)
        {
            this._carros.Add(carro);
        }

        public Carro GetCarro(int index)
        {
            if(_carros.Count < index || _carros.Count == 0)
            {
                return null;
            }
            return _carros.ElementAt(index);
        }

        public Pessoa()
        {}
        public Pessoa(String nome, String cpf, List<Carro> carros)
        {
            this._nome = nome;
            this._cpf = cpf;
            this._carros = carros;
        }

        public Pessoa(int id, String nome, String cpf, List<Carro> carros)
        {
            this._id = id;
            this._nome = nome;
            this._cpf = cpf;
            this._carros = carros;
        }

        public override String ToString()
        {
            return "(nome:" + this.Nome + ";cpf:" + this.Cpf + ";" + Printar() + ")\n";
        }

        private String Printar()
        {
            String texto = "";
            foreach (Carro carro in Carros)
            {
                texto += carro.ToString(carro);
            }
            if(texto != "")
                texto = texto.Remove(texto.Length - 1);
            return texto;
        }

    }
}
