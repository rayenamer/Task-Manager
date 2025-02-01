using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_taches.Domain.Commands
{
    public class PutGenericCommand<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public PutGenericCommand(TEntity entity)
        {
            Entity = entity;
        }
        public TEntity Entity { get; }

    }
}

