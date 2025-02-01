using gestion_taches.Domain.Commands;
using gestion_taches.Domain.Queries;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestion_taches.Domain.interfaces;


namespace gestion_taches.Domain.Handlers
{
    public class PutGenericHandler<TEntity> : IRequestHandler<PutGenericCommand<TEntity>, TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;

        public PutGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public Task<TEntity> Handle(PutGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Update(request.Entity);
            return Task.FromResult(result);
        }
    }
}

