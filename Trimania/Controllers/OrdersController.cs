using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using TriMania.Application.ShoppingContext.AddItems;
using TriMania.Application.ShoppingContext.Checkout;
using TriMania.Application.ShoppingContext.Create;
using Trimania.Shared.Api;
using TriMania.Application.ShoppingContext.Queries.OrdersReport;
using TriMania.Application.ShoppingContext.Queries.OrdersReport.Output;

namespace Trimania.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
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
        [Route("createcart")]
        [Authorize]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartCommand command, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<int>();

            command.UserId = GetUserId();

            var result = await _mediator.Send(command, cancellationToken);

            response.SetData(result, null);

            return Ok(response);
        }

        [HttpPost]
        [Route("additems")]
        [Authorize]
        public async Task<IActionResult> AddItems([FromBody] AddItemsCommand command, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<OrderDto>();

            command.UserId = GetUserId();

            var result = await _mediator.Send(command, cancellationToken);

            response.SetData(result, null);

            return Ok(response);
        }

        [HttpPost]
        [Route("checkout")]
        [Authorize]
        public async Task<IActionResult> Checkout([FromBody] CheckoutCommand command, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<int>();

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet]
        [Route("report")]
        //[Authorize]
        public async Task<IActionResult> Report([FromQuery] OrdersReportQuery query, CancellationToken cancellationToken)
        {
            var response = new CustomResponse<OrderReportDto>();

            var result = await _mediator.Send(query, cancellationToken);

            response.SetData(result, null);

            return Ok(response);
        }
    }
}
