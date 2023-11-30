using CleanArchtecture.Domain.Abstractions;
using CleanArchtecture.Domain.Alugueis.Events;
using CleanArchtecture.Domain.Veiculos;

namespace CleanArchtecture.Domain.Alugueis
{
    public sealed class Aluguel : Entity
    // classe não pode ser herdada
    {
        private Aluguel(
            Guid id,
            Guid userId,
            Guid veiculoId,
             Moeda precoPorPeriodo,
             Moeda manutencao,
             Moeda acessorios,
             Moeda precoTotal,
             AluguelStatus status,
             DateRange duracao,
             DateTime dataCriacao


        ) : base(id)
        {
            VeiculoId = veiculoId;
            UserId = userId;
            Duracao = duracao;
            PrecoPorPeriodo = precoPorPeriodo;
            Manutencao = manutencao;
            Acessorios = acessorios;
            PrecoTotal = precoTotal;
            Status = status;
            DataCriacao = dataCriacao;


        }

        public Guid UserId { get; private set; }
        public Guid VeiculoId { get; private set; }
        public Moeda? PrecoPorPeriodo { get; private set; }
        public Moeda? Manutencao { get; private set; }
        public Moeda Acessorios { get; private set; }
        public Moeda? PrecoTotal { get; private set; }

        public AluguelStatus Status { get; private set; }

        public DateRange? Duracao { get; private set; }
        public DateTime? DataCriacao { get; private set; }
        public DateTime? DataConfirmacao { get; private set; }
        public DateTime? DataRecusa { get; private set; }
        public DateTime? DataFinalizacao { get; private set; }

        public DateTime? DataCancelamento { get; private set; }



        public static Aluguel Reservar(
            Veiculo veiculo,
            Guid userId,
            DateRange duracao,
            DateTime dataCriacao,
            PrecoService precoService

        )
        {
            var precoDetalhe = precoService.CalcularPreco(
                veiculo,duracao    
            );
            var aluguel = new Aluguel(
                Guid.NewGuid(),
                userId,
                veiculo.Id,
                precoDetalhe.PrecoPorPeriodo,
                precoDetalhe.Manutencao,
                precoDetalhe. Acessorios,
                precoDetalhe.PrecoTotal,
                AluguelStatus.Reservado,
                duracao,
                dataCriacao
            );
            aluguel.RaiseDomainEvent(new AluguelReservadoDomainEvent(aluguel.Id));
            veiculo.UltimoAluguel = dataCriacao;
            return aluguel;
        }


    }
}