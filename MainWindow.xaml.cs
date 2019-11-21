using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Oficial.views;
using Oficial.dao;
using Oficial.models;
using System.Collections.Generic;
using Oficial.Services;
using Microsoft.Win32;
using System;

namespace Oficial
{
    public partial class MainWindow : Window
    {
        List<Pessoa> pessoas = new List<Pessoa>();

        public AdicionarPessoa adicionarPessoa = new AdicionarPessoa();
        public AdicionarCarro AdicionarCarroForm = new AdicionarCarro();

        PessoaDAO pessoaDAO = new PessoaDAO();
        public MainWindow()
        {
            InitializeComponent();
            Atualizar(null, null);
        }
        private void AdicionarPessoa(object sender, RoutedEventArgs e)
        {
            adicionarPessoa.Show();
        }

        private void Sair(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Atualizar(object sender, RoutedEventArgs e)
        {
            Dados.ItemsSource = null;
            Dados.Items.Clear();
            pessoas = pessoaDAO.GetPessoas();
            var dados = from pessoa in pessoas
                        select new
                        {
                            Id = pessoa.Id,
                            Nome = pessoa.Nome,
                            Cpf = pessoa.Cpf,
                            Detalhes = "Detalhes"
                        };
            Dados.ItemsSource = dados.ToList();
        }   

        private void Alterar(object sender, RoutedEventArgs e)
        {
            Alterar alterar = new Alterar(Convert.ToInt32((sender as TextBlock).Tag.ToString()));
            alterar.Show();
        }

        private void SalvarArquivo(object sender, RoutedEventArgs e)
        {
            Atualizar(null, null);

            ArquivoService service = new ArquivoService();

            service.SalvarTexto(pessoas);
        }

        private void Importar(object sender, RoutedEventArgs e)
        {
            string caminho = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                caminho = openFileDialog.FileName;

            ArquivoService arquivoService = new ArquivoService();
            arquivoService.ImportarTexto(caminho);
        }

        private void AdicionarPessoa_Closed(object sender, System.EventArgs e)
        {
            if(adicionarPessoa != null)
                if (adicionarPessoa.AdicionarCarroForm != null)
                    adicionarPessoa.AdicionarCarroForm.Close();
        }

        private void on_Closed() {
            if (adicionarPessoa != null)
                if (adicionarPessoa.AdicionarCarroForm != null)
                    adicionarPessoa.AdicionarCarroForm.Close();
        }

    }
}
