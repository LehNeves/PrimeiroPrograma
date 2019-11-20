using System;
using System.Collections.Generic;
using System.Windows;
using Oficial.dao;
using Oficial.models;

namespace Oficial.Services
{
    public class ArquivoService
    {
        private List<Pessoa> Pessoas = new List<Pessoa>();
        private List<Carro> Carros = new List<Carro>();
        PessoaDAO pessoaDAO = new PessoaDAO();

        public void SalvarTexto(List<Pessoa> pessoas)
        {
            string texto = "";

            CarroDAO carroDAO = new CarroDAO();

            foreach (Pessoa pessoa in pessoas)
            {
                pessoa.Carros = carroDAO.GetCarrosFromPessoa(pessoa.Id);
                texto += pessoa.ToString();
            }

            pessoaDAO.SalvarTexto(texto);

        }

        public void ImportarTexto(string caminho)
        {
            LerTexto(caminho);
        }

        public void LerTexto(string caminho)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(caminho.ToString());
                foreach (string line in lines)
                {
                    GerarObjetos(line);
                }
            }
            catch (Exception ler)
            {
                MessageBox.Show(ler.Message, "Erro ao ler arquivo");
            }

        }

        public void GerarObjetos(string line)
        {
            try
            {
                line = line.Replace("(", "");
                line = line.Replace(")", "");

                string[] vetor = line.Split(';');

                string[] vetor2;

                for (int i = 2; i < vetor.Length; i++)
                {
                    vetor2 = vetor[i].Split(',');
                    Carros.Add(new Carro(vetor2[0].Substring(7), Convert.ToInt32(vetor2[1].Substring(4))));
                }

                Pessoas.Add(new Pessoa(vetor[0].Substring(5), vetor[1].Substring(4), Carros));

                pessoaDAO.SalvarLista(Pessoas);

            }
            catch(Exception importar)
            {
                MessageBox.Show(importar.Message, "Erro ao ler arquivo importado");
            }
        }
    }
}
