using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchtecture.Domain.Abstractions;

namespace CleanArchtecture.Domain.Users.Events
{
    public sealed record UserCreateDomainEvent(Guid UserId) : IDomainEvent
    {
        
    }
}