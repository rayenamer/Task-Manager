using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_taches.Domain.Commands
{
    public class RemoveGenericCommand<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public RemoveGenericCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
