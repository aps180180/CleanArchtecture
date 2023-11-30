using CleanArchtecture.Domain.Abstractions;
using CleanArchtecture.Domain.Users.Events;

namespace CleanArchtecture.Domain.Users
{
    public sealed class User : Entity
    //esta classe não pode ser herdada
    {
        private User(Guid id,Nome nome,Sobrenome sobrenome, Email email) : base(id)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email  = email;

        }

        public Nome? Nome { get; private set; }
        public Sobrenome? Sobrenome { get; private set; }
        public Email? Email { get; private set; }

        public static User Create(
            Nome nome,
            Sobrenome sobrenome,
            Email email
        )
        {
            
            var user = new User(Guid.NewGuid(),nome,sobrenome,email);
            user.RaiseDomainEvent(new UserCreateDomainEvent(user.Id));
            return user;
        }
    }
}