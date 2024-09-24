using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            try
            {
				int i = 0;

				foreach (var item in hospedes)
				{
					i++;
				}
				if (i <= Suite.Capacidade)
				{
					Hospedes = hospedes;
				}
				else
				{
					throw new ArgumentException("Não é possivel fazer está reserva pois o numero de hospedes execede a capacidade da Suite!");

				}
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
			
		}

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidadeHospedes = 0;
            if (Hospedes is null)
            {
                Console.WriteLine("Nenhum Hospede Cadastrado!");
                return quantidadeHospedes;
            }
            else {
				quantidadeHospedes = Hospedes.Count;

                return quantidadeHospedes;

			}

        }

        public decimal CalcularValorDiaria()
        {
			decimal valorDiaria = Suite.ValorDiaria;
			int diasReservados = DiasReservados;
            if (Hospedes is null)
            {
                Console.WriteLine("Sem Hospedes Cadastrados não é possivel calcular a diaria");
                return 0;
            }

			if (diasReservados >= 10)
            {

                decimal desconto =( valorDiaria *10 )/ 100;

				decimal valorComDesconto= valorDiaria - desconto;
				

                
                return valorComDesconto * diasReservados;

			}
            else
            {
                return diasReservados * valorDiaria;

			}


		}
    }
}