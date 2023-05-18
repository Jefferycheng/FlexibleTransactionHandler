using MediatR;

namespace FlexibleTransactionHandler.Application.Commands;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    public async Task<bool> Handle(UpdateOrderCommand request,
        CancellationToken cancellationToken)
    {
        return true;
    }
}