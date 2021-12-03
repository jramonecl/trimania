using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TriMania.Application.UserContext.Commands.Authenticate;
using TriMania.Application.UserContext.Commands.Register;
using Trimania.Shared.Api;
using TriMania.Application.UserContext.Commands.Delete;
using TriMania.Application.UserContext.Commands.Edit;
using TriMania.Application.UserContext.Queries.ListUsers;
using TriMania.Infra.Database.Repository.Base;

namespace Trimania.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private int GetUserId()
        {
            var subject = this.HttpContext.User.Claims
                              .FirstOrDefault(claim => claim.Type == ClaimTypes.Name);

            return int.TryParse(subject.Value, out var id) ? id : default(int);
        }


        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand command, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<string>();

            var result = await _mediator.Send(command, cancellationToken);

            response.SetData(result, null);

            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<int>();

            var result = await _mediator.Send(command, cancellationToken);

            response.SetData(result, "Criado com sucesso");

            return Ok(response);
        }

        [HttpPost]
        [Route("edit")]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] EditCommand command, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<int>();

            command.Id = GetUserId();

            var result = await _mediator.Send(command, cancellationToken);

            response.SetData(result, "Editado com sucesso");

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<object>();

            command.Id = GetUserId();

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet]
        [Route("all")]
        //[Authorize]
        public async Task<IActionResult> GetAll([FromQuery] ListUsersQuery query, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<QueryResult<UserDto>>();

            var result = await _mediator.Send(query, cancellationToken);

            response.SetData(result, null);

            return Ok(response);
        }
    }
}
