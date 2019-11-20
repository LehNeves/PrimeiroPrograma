using System.Collections.Generic;
using System.Windows;
using Oficial.models;
using Oficial.dao;

namespace Oficial.views
{
    /// <summary>
    /// Lógica interna para AdicionarPessoa.xaml
    /// </summary>
    public partial class AdicionarPessoa : Window
    {
        

        AdicionarCarro AdicionarCarroForm;

        Pessoa pessoa = new Pessoa();
        public AdicionarPessoa()
        {
            InitializeComponent();
        }

        public void AdicionarCarro(object sender, RoutedEventArgs e)
        {
            List<Carro> Carro = new List<Carro>();
            AdicionarCarroForm = new AdicionarCarro(Carro);
            AdicionarCarroForm.Show();
            pessoa.Carros = Carro;
        }

        private void Salvar(object sender, RoutedEventArgs e)
        {
            if (VerificarCampos())
            {
                PessoaDAO dao = new PessoaDAO();
                dao.Save(pessoa);
                if (AdicionarCarroForm != null)
                    if (AdicionarCarroForm.IsVisible)
                        AdicionarCarroForm.Close();
                this.Close();
            }
            
        }

        private void Fechar(object sender, RoutedEventArgs e)
        {
            if(AdicionarCarroForm != null)
                if (AdicionarCarroForm.IsVisible)
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
    }

    
}
