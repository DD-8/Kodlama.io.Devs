using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageById;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguageById;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageByIdCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageByIdDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageByIdCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageByIdDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, ListedProgrammingLanguageByIdDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, ListedAllProgrammingLanguageDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ListedAllProgrammingLanguageModel>().ReverseMap();
        }
    }
}
