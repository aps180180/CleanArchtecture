using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchtecture.Domain.Veiculos
{
    public record Moeda(decimal valor, TipoMoeda TipoMoeda)
    {
        public static Moeda operator +(Moeda primeiro, Moeda segundo)
        {
            if (primeiro.TipoMoeda != segundo.TipoMoeda)
            {
                throw new InvalidOperationException("O tipo de moeda deve ser o mesmo");
            }
            return new Moeda(primeiro.valor + segundo.valor, primeiro.TipoMoeda);
        }

        public static Moeda Zero() => new(0, TipoMoeda.None);
        public static Moeda Zero(TipoMoeda tipoMoeda) => new(0,tipoMoeda);

        public bool IsZero() => this == Zero(TipoMoeda);
    }



}