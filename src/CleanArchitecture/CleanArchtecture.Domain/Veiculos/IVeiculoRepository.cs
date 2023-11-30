using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchtecture.Domain.Veiculos
{
    public interface IVeiculoRepository
    {
        Task<Veiculo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        
    }
}