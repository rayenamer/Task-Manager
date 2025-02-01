using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using gestion_taches.Domain.Commands;
using gestion_taches.Domain.Handlers;
using gestion_taches.Domain.Queries;
using gestion_taches.Data.Repository;

using gestion_taches.Domain.models;
using gestion_taches.Domain.interfaces;
using AutoMapper;
using gestion_taches.Domain.Dto;
using Microsoft.EntityFrameworkCore;


namespace gestion_taches.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RessourcesControlleur : ControllerBase
    {
        private readonly IGenericRepository<Ressources> repository;
        private readonly IMapper mapper;

        #region Constructor
        public RessourcesControlleur(IGenericRepository<Ressources> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function

        [HttpGet("GetRessources")]
        public async Task<IEnumerable<Ressources>> GetRessources() =>
             await (new GetListGenericHandler<Ressources>(repository)).Handle(new GetListGenericQuery<Ressources>(condition: null, includes: null), new CancellationToken());
        
        
        [HttpGet("GetRessourcesById")]
        public async Task<IEnumerable<Ressources>> GetRessourcesById(Guid id) =>
             await (new GetListGenericHandler<Ressources>(repository)).Handle(new GetListGenericQuery<Ressources>(condition: x => x.IdRessources == id, includes: null), new CancellationToken());
        
        
        [HttpGet("GetRessourcesandtheirproject")]
        public IEnumerable<ProjectRessourcesDto> GetRessourcesandtheirproject()
        {
            var personnes = new GetListGenericHandler<Ressources>(repository)
                .Handle(new GetListGenericQuery<Ressources>(condition: null, includes: x => x.Include(x => x.Project)), new CancellationToken()).Result;

            return personnes.Select(ap => mapper.Map<ProjectRessourcesDto>(ap));
        }
        #endregion

        





        #region Add Function

        [HttpPost("PostRessources")]
        public async Task<Ressources> PostRessources([FromBody] Ressources li) =>
            await (new AddGenericHandler<Ressources>(repository)).Handle(new AddGenericCommand<Ressources>(li), new CancellationToken());
        #endregion

        #region Update Funtion
        [HttpPut("PutRessources")]
        public async Task<Ressources> PutProject([FromBody] Ressources l) =>
           await (new PutGenericHandler<Ressources>(repository)).Handle(new PutGenericCommand<Ressources>(l), new CancellationToken());
        #endregion

        #region Remove Function

        [HttpDelete("DeleteRessources")]
        public async Task<Ressources> DeleteRessouces(Guid id) =>
           await (new RemoveGenericHandler<Ressources>(repository)).Handle(new RemoveGenericCommand<Ressources>(id), new CancellationToken());
        #endregion
    }

}
