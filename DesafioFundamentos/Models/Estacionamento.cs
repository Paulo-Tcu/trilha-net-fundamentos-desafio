using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.Write("Digite a placa do veículo para estacionar:\t");
            var placa = FormatPlaca(Console.ReadLine().ToString().ToUpper());
            var msg = $"O veículo com placa {placa} já consta como estacionado, deseja removelo?\n[1]\t\t\tSim\n[Qualquer outra tecla]\tNão\n";

            if (this[placa] == null  && ValidaPlaca(placa))
            {
                veiculos.Add(placa);
            }
            else if(ValidaPlaca(placa))
            {
                Console.WriteLine(msg);
                if( Convert.ToInt32(Console.ReadLine()) == 1)
                    RemoverVeiculo(placa);

                else
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente e tente novamente");
            }
            else
            {
                Console.WriteLine("Placa inválida, tente usar o padrão: AAA-1111 ou AAA-1A11");
            }

        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover:\t");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = FormatPlaca(Console.ReadLine().ToString().ToUpper());

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa) && ValidaPlaca(placa))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado:\t");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = (precoPorHora * horas) + precoInicial;
                
                veiculos.Remove(placa);

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void RemoverVeiculo(string placa)
        {
            
            if (veiculos.Select(x => x.ToUpper()).Where(w => w == placa.ToUpper()).FirstOrDefault() != null)
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado:\t");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = (precoPorHora * horas) + precoInicial;
                
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach(var placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private string FormatPlaca(string placaVeiculo)
        {
            if(placaVeiculo[3] != '-'){
                placaVeiculo = placaVeiculo.Substring(0,3) + '-' + placaVeiculo.Substring(3);
            }

            return placaVeiculo;
        }

        public string this [string placa]
        {
            get
            {
                return veiculos.Select(x => x.ToUpper()).Where(w => w == placa.ToUpper()).FirstOrDefault();
            }
        }

        private bool ValidaPlaca(string placa)
        {
            return Regex.IsMatch(placa.ToUpper(),"[A-Z]{3}-?[0-9][A-Z0-9][0-9]{2}$");

        }
    }
}
