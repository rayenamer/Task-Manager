﻿using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using gestion_taches.Domain.Commands;

namespace gestion_taches.Domain.Queries
{
    public class GetListGenericQuery<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : class
    {
        public GetListGenericQuery(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            Condition = condition;
            Includes = includes;
        }
        public Expression<Func<TEntity, bool>> Condition { get; }
        public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; }
    }
}
