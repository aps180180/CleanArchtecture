using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchtecture.Domain.Veiculos;

namespace CleanArchtecture.Domain.Alugueis
{
    public record PrecoDetalhe(
        Moeda PrecoPorPeriodo,
        Moeda Manutencao,
        Moeda Acessorios,
        Moeda PrecoTotal
    );
    
}