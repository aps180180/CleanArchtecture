using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchtecture.Domain.Alugueis
{
    public sealed record DateRange
    {
        private DateRange()
        {

        }

        public DateOnly Inicio { get; init; }
        public DateOnly Fim { get; init; }

        public int QtdeDias => Fim.DayNumber - Inicio.DayNumber;

        public static DateRange Create(DateOnly inicio, DateOnly fim)
        {
            if (inicio > fim)
            {
                throw new ApplicationException("Data final é anterior a data de início");
            }
            return new DateRange
            {
                Inicio = inicio,
                Fim = fim
            };


        }

    }
}