using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oficial.models;

namespace Oficial.views
{
    /// <summary>
    /// Lógica interna para AdicionarCarro.xaml
    /// </summary>
    public partial class AdicionarCarro : Window
    {
        private List<Carro> _carro = new List<Carro>();

        public AdicionarCarro()
        {
            InitializeComponent();
        }

        public List<Carro> GetCarros()
        {
            return _carro;
        }

        public void SalvarCarro(object sender, RoutedEventArgs e)
        {
            try {
                if (VerificarCampos())
                {
                    _carro.Add(new Carro(modeloTextBox.Text, Convert.ToInt32(anoTextBox.Text)));
                    this.LimparCampos();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar carro", "erro");
                }

            } catch (Exception x)
            {
                MessageBox.Show(x.Message, "Inserido texto e não números inteiros");
            }
        }

        private void Fechar(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private bool VerificarCampos()
        {
            if (anoTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Não foi inserido Ano", "Ano está vazio");
                return false;
            }

            if (modeloTextBox.Text.TrimStart().TrimEnd() == "")
            {
                MessageBox.Show("Não foi inserido Modelo", "Modelo está vazio");
                return false;
            }

            return true;
        }
           
        public void LimparCampos()
        {
            anoTextBox.Text = "";
            modeloTextBox.Text = "";
        }


    }
}
