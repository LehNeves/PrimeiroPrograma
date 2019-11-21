using System.Collections.Generic;
using System.Windows;
using Oficial.models;
using Oficial.dao;
using System;

namespace Oficial.views
{
    /// <summary>
    /// Lógica interna para AdicionarPessoa.xaml
    /// </summary>
    public partial class AdicionarPessoa : Window
    {
        public AdicionarCarro AdicionarCarroForm = new AdicionarCarro();

        Pessoa pessoa = new Pessoa();

        public AdicionarPessoa()
        {
            InitializeComponent();
        }

        public void AdicionarCarro(object sender, RoutedEventArgs e)
        {
            AdicionarCarroForm.ShowDialog();
        }

        private void Salvar(object sender, RoutedEventArgs e)
        {
            if (AdicionarCarroForm != null)
                if (AdicionarCarroForm.IsVisible)
                {
                    MessageBox.Show("Primeiro encerro o form Adicionar Carro");
                }
                else
                {
                    pessoa.Carros = AdicionarCarroForm.GetCarros();
                    if (VerificarCampos())
                    {
                        PessoaDAO dao = new PessoaDAO();
                        dao.Save(pessoa);
                        if (AdicionarCarroForm != null)
                            AdicionarCarroForm.Close();
                        this.Close();
                    }
                }
        }

        private void Fechar(object sender, RoutedEventArgs e)
        {
            if (AdicionarCarroForm != null)
                AdicionarCarroForm.Close();
            this.Close();
        }

        private bool VerificarCampos()
        {

            pessoa.Nome = nomeTextBox.Text.TrimStart().TrimEnd();
            pessoa.Cpf = cpfTextBox.Text.TrimStart().TrimEnd();

            if (pessoa.Nome == "")
            {
                MessageBox.Show("Não foi inserido Nome", "Nome está vazio");
                return false;
            }

            if (pessoa.Cpf == "")
            {
                MessageBox.Show("Não foi inserido Cpf", "Cpf está vazio");
                return false;
            }

            if (pessoa.Carros.Count == 0)
            {
                MessageBox.Show("Não foram inseridos Carros", "Lista de Carros vazia");
                return false;
            }
            return true;
        }

        private void Fechando(object sender, EventArgs e)
        {
            AdicionarCarroForm.Close();
        }

        private void Fechado(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AdicionarCarroForm.Close();
        }

    }
}
