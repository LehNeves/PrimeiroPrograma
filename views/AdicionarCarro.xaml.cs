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
        private List<Carro> carros = new List<Carro>();

        public AdicionarCarro(List<Carro> carros)
        {
            this.carros = carros;
            InitializeComponent();
        }

        public void SalvarCarro(object sender, RoutedEventArgs e)
        {
            try {

                if (VerificarCampos())
                {
                    this.carros.Add(new Carro(modelo.Text, Convert.ToInt16(ano.Text)));

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar carro", "erro");
                }

                

            } catch (Exception x)
            {
                MessageBox.Show("Inserido texto e não números inteiros");
            }
        }

        private void Fechar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool VerificarCampos()
        {
            if (ano.Text.Trim() == "")
            {
                MessageBox.Show("Não foi inserido Ano", "Ano está vazio");
                return false;
            }

            if (modelo.Text.TrimStart().TrimEnd() == "")
            {
                MessageBox.Show("Não foi inserido Modelo", "Modelo está vazio");
                return false;
            }

            Convert.ToInt32(ano.Text);

            return true;
        }
            
    }
}
