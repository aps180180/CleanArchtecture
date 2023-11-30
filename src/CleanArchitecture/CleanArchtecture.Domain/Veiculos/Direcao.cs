using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchtecture.Domain.Veiculos
{
    public record Direcao(
        string Pais,
        string Departamento,
        string Provincia,
        string Cidade, 
        string Calle       

    );
    
}