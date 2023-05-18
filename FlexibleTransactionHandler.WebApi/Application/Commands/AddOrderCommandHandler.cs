using MediatR;

namespace FlexibleTransactionHandler.Application.Commands;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, bool>
{
    private readonly IMediator _mediator;

    public AddOrderCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<bool> Handle(AddOrderCommand request,
        CancellationToken cancellationToken)
    {
        var productCommand = new AddProductCommand();

        await _mediator.Send(productCommand);
        return true;
    }
}