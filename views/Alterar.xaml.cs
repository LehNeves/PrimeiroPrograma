using System.Linq;
using System.Windows;
using Oficial.models;
using Oficial.dao;

namespace Oficial.views
{
    /// <summary>
    /// Lógica interna para Alterar.xaml
    /// </summary>
    public partial class Alterar : Window
    {
        Pessoa pessoa = new Pessoa();

        PessoaDAO PessoaDAO = new PessoaDAO();
        CarroDAO CarroDAO = new CarroDAO();

        public Alterar(int index)
        {
            pessoa = PessoaDAO.GetPessoa(index);
            var carros = CarroDAO.GetCarrosFromPessoa(index);
            
            foreach(Carro carro in carros)
            {
                pessoa.AddCarro(carro);
            }

            InitializeComponent();
            if(!(pessoa.Nome == null) || !(pessoa.Cpf == null))
            {
                NomeTextBox.Text = pessoa.Nome.ToString();
                CpfTextBox.Text = pessoa.Cpf.ToString();
            }
            
            DadosCarros.ItemsSource = 
                from c in pessoa.Carros
                    select new
                    {
                        Id = c.Id,
                        Modelo = c.Modelo,
                        Ano = c.Ano,
                    };
        }

        private void Fechar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
