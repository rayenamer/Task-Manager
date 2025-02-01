using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_taches.Domain.Commands
{

    public class AddGenericCommand<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public TEntity Entity { get; }
        public AddGenericCommand(TEntity entity)
        {
            Entity = entity;
        }

    }
}