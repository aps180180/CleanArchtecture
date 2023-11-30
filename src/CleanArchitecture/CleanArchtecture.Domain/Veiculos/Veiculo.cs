using CleanArchtecture.Domain.Abstractions;

namespace CleanArchtecture.Domain.Veiculos
{
    public sealed class Veiculo : Entity
    // classe não pode ser herdada
    {
        public Veiculo(Guid id,
            Modelo modelo,
             Vin vin,
              Moeda preco,
               Moeda manutencao,
                DateTime? ultimoAluguel,
                List<Acessorio> acessorios,
                Direcao? direcao
            ) : base(id)
        {
            Modelo = modelo;
            Vin = vin;
            Preco = preco;
            Manutencao = manutencao;
            UltimoAluguel = ultimoAluguel;
            Acessorios = acessorios;
            Direcao =direcao;

        }

        public Modelo? Modelo { get; private set; }
        public Vin? Vin { get; private set; }
        public Direcao? Direcao { get; private set; }
        public Moeda? Preco { get; private set; }
        public Moeda? Manutencao { get; private set; }
        public DateTime? UltimoAluguel { get; internal set; }
        public List<Acessorio> Acessorios { get; private set; } = new();



    }
}