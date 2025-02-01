using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_taches.Domain.Dto;
using gestion_taches.Domain.models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
namespace gestion_taches.Api.Mapper
{
    public class MappingProfiles : Profile
    {
        
        public MappingProfiles()
        {


            CreateMap<Ressources, RessourcesDto>()

                        .ForMember(m => m.IdRessources, i => i.MapFrom(src => src.IdRessources))
                        .ForMember(m => m.Nom, i => i.MapFrom(src => src.Nom))
                        .ForMember(m => m.Etat, i => i.MapFrom(src => src.Etat))
                        

                        .ForMember(m => m.Nomp, i => i.MapFrom(src => src.Project.Nomp))
                        .ReverseMap();

            CreateMap<Ressources, ProjectRessourcesDto>()

                        
                        .ForMember(m => m.IdRessources, i => i.MapFrom(src => src.IdRessources))
                        .ForMember(m => m.Nom, i => i.MapFrom(src => src.Nom))
                        .ForMember(m => m.Etat, i => i.MapFrom(src => src.Etat))
                        .ForMember(m => m.Cout, i => i.MapFrom(src => src.Cout))
                        .ForMember(m => m.unit, i => i.MapFrom(src => src.unit))
                        .ForMember(m => m.IdProject, i => i.MapFrom(src => src.Project.IdProject))
                        .ForMember(m => m.Nomp, i => i.MapFrom(src => src.Project.Nomp))
                        .ReverseMap();
        }
    }
}