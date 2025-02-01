using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

using gestion_taches.Domain.Commands;
using gestion_taches.Domain.Handlers;
using gestion_taches.Domain.Queries;
using gestion_taches.Domain.Dto;

using gestion_taches.Domain.models;
using gestion_taches.Domain.interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace gestion_taches.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectControlleur : ControllerBase
    {
        private readonly IGenericRepository<Project> repository;
        private readonly IMapper mapper;


        #region Constructor
        public ProjectControlleur(IGenericRepository<Project> repository , IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;   
        }
        #endregion

        #region Read Function

        [HttpGet("GetProject")]
        public async Task<IEnumerable<Project>> GetPROject() =>
             await (new GetListGenericHandler<Project>(repository)).Handle(new GetListGenericQuery<Project>(condition: null, includes: null), new CancellationToken());
        [HttpGet("GetProjectById")]
        public async Task<IEnumerable<Project>> GetProjectById(Guid id) =>
             await (new GetListGenericHandler<Project>(repository)).Handle(new GetListGenericQuery<Project>(condition: x => x.IdProject == id, includes: null), new CancellationToken());

        
        #endregion


        #region Add Function

        [HttpPost("PostProject")]
        public async Task<Project> PostProject([FromBody] Project li) =>
            await (new AddGenericHandler<Project>(repository)).Handle(new AddGenericCommand<Project>(li), new CancellationToken());
        #endregion

        #region Update Funtion
        [HttpPut("PutProject")]
        public async Task<Project> PutProject([FromBody]    Project l) =>
           await (new PutGenericHandler<Project>(repository)).Handle(new PutGenericCommand<Project>(l), new CancellationToken());
        #endregion

        #region Remove Function

        [HttpDelete("DeleteProject")]
        public async Task<Project> DeleteProject(Guid id) =>
           await (new RemoveGenericHandler<Project>(repository)).Handle(new RemoveGenericCommand<Project>(id), new CancellationToken());
        #endregion
    }

}

