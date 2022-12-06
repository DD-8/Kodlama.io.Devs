using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageById
{
    public class DeleteProgrammingLanguageByIdCommand : IRequest<DeletedProgrammingLanguageByIdDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageByIdCommandHandler : IRequestHandler<DeleteProgrammingLanguageByIdCommand, DeletedProgrammingLanguageByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public DeleteProgrammingLanguageByIdCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageByIdDto> Handle(DeleteProgrammingLanguageByIdCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageNotFound(request.Id);

                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(mappedProgrammingLanguage);
                DeletedProgrammingLanguageByIdDto deletedProgrammingLanguageByIdDto = _mapper.Map<DeletedProgrammingLanguageByIdDto>(deletedProgrammingLanguage);

                return deletedProgrammingLanguageByIdDto;
            }
        }
    }
}
