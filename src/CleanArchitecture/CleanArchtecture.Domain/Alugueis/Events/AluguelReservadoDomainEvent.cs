using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchtecture.Domain.Abstractions;

namespace CleanArchtecture.Domain.Alugueis.Events
{

    public sealed record AluguelReservadoDomainEvent(Guid AluguelId) : IDomainEvent;

}