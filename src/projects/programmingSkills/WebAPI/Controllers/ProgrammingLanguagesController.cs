using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageById;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguageById;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetAllProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageByIdCommand deleteProgrammingLanguageByIdCommand)
        {
            DeletedProgrammingLanguageByIdDto result = await Mediator.Send(deleteProgrammingLanguageByIdCommand);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageByIdCommand updateProgrammingLanguageByIdCommand)
        {
            UpdatedProgrammingLanguageByIdDto result = await Mediator.Send(updateProgrammingLanguageByIdCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetProgrammingLanguageByIdQuery getProgrammingLanguageByIdQuery)
        {
            ListedProgrammingLanguageByIdDto result = await Mediator!.Send(getProgrammingLanguageByIdQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetAllProgrammingLanguageQuery getAllProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ListedAllProgrammingLanguageModel result = await Mediator!.Send(getAllProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}
