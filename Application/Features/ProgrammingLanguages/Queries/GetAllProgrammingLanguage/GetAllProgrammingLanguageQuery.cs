using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetAllProgrammingLanguage
{
    public class GetAllProgrammingLanguageQuery : IRequest<ListedAllProgrammingLanguageModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetAllProgrammingLanguageQueryHandler : IRequestHandler<GetAllProgrammingLanguageQuery, ListedAllProgrammingLanguageModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetAllProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ListedAllProgrammingLanguageModel> Handle(GetAllProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                ListedAllProgrammingLanguageModel mappedlistedAllProgrammingLanguageModel = _mapper.Map<ListedAllProgrammingLanguageModel>(programmingLanguages);
                return mappedlistedAllProgrammingLanguageModel;
            }
        }
    }
}
