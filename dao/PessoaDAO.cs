using System;
using System.Collections.Generic;
using System.Linq;
using Oficial.contexto;
using Oficial.models;
using System.IO;
using System.Windows;

namespace Oficial.dao
{
    public class PessoaDAO
    {
        private Pessoa pessoa;

        private Contexto contexto;

        private String caminho = @"C:\Users\lneve\Documents\text.txt";

        public PessoaDAO()
        {
            contexto = new Contexto();
        }

        public void SalvarTexto(String texto)
        {
            try
            {
                File.WriteAllText(caminho, texto);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message , "Erro ao salvar arquivo");
            }
        }

        /**/

        public void Save(Pessoa pessoa)
        {
            contexto.Pessoa.Add(pessoa);
            contexto.SaveChanges();
        }

        public Pessoa GetPessoa(int index)
        {
            using (contexto)
            {
                return contexto.Pessoa.Find(index);
            }
        }

        public List<Pessoa> GetPessoas()
        {
            return contexto.Pessoa.ToList();
        }

        public void SalvarLista(List<Pessoa> Pessoas)
        {
            try
            {
                
                foreach (Pessoa pessoa in Pessoas)
                {
                    contexto.Pessoa.Add(pessoa);
                }
                contexto.SaveChanges();
            }
            catch (Exception SalvarLista)
            {
                MessageBox.Show(SalvarLista.Message, "Erro ao Salvar o arquivo importado");
            }
            
        }
    }
}
