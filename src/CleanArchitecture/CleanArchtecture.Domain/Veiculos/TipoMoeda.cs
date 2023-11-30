using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchtecture.Domain.Veiculos
{
    public record TipoMoeda
    {
        public static readonly TipoMoeda None = new("");
        public static readonly TipoMoeda Usd = new("USD");
        public static readonly TipoMoeda Eur = new("EUR");

        private TipoMoeda(string codigo) => Codigo = codigo;
        public string? Codigo { get; init; }

        public static readonly IReadOnlyCollection<TipoMoeda> All = new[]
        {
                Usd,
                Eur
        };

        public static TipoMoeda FromCodigo(string codigo)
        {
            return All.FirstOrDefault(c => c.Codigo == codigo) ??
                throw new ApplicationException("Não foi encontrado o tipo de moeda para o código informado!");
        }

    }
}

