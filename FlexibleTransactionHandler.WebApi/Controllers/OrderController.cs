using FlexibleTransactionHandler.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlexibleTransactionHandler.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("addOrder")]
    public async Task<IActionResult> AddOrder()
    {
        var command = new AddOrderCommand();

        return Ok(await _mediator.Send(command));
    }

    [HttpGet("addProduct")]
    public async Task<IActionResult> AddProduct()
    {
        var command = new AddProductCommand();
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("updateOrder")]
    public async Task<IActionResult> UpdateOrder()
    {
        var command = new UpdateOrderCommand();
        return Ok(await _mediator.Send(command));
    }
}