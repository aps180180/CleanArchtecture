using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchtecture.Domain.Veiculos;

namespace CleanArchtecture.Domain.Alugueis
{
    public class PrecoService
    {
        public PrecoDetalhe CalcularPreco(Veiculo veiculo, DateRange periodo)
        {
            var tipoMoeda = veiculo.Preco!.TipoMoeda;
            var precoPorPeriodo = new Moeda(periodo.QtdeDias * veiculo.Preco.valor, tipoMoeda);


            decimal porcentageChange = 0;
            foreach (var acessorio in veiculo.Acessorios)
            {
                porcentageChange += acessorio switch
                {
                    Acessorio.AppleCar or Acessorio.AndroidCar => 0.05m,
                    Acessorio.ArCondicionado => 0.01m,
                    Acessorio.Mapas => 0.01m,
                    _ => 0 // else
                };
            }

            var acessorioCobranca = Moeda.Zero(tipoMoeda);

            if (porcentageChange > 0)
            {
                acessorioCobranca = new Moeda(precoPorPeriodo.valor * porcentageChange, tipoMoeda);
            }
            var precoTotal = Moeda.Zero();
            precoTotal += precoPorPeriodo;
            if (!veiculo!.Manutencao!.IsZero())
            {
                precoTotal += veiculo.Manutencao;
            }

            precoTotal += acessorioCobranca;
            return new PrecoDetalhe(
                precoPorPeriodo,
                veiculo.Manutencao,
                acessorioCobranca,
                precoTotal);

        }
    }
}