using MediatR;

namespace FlexibleTransactionHandler.Application.Commands;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
{
    public async Task<bool> Handle(AddProductCommand request,
        CancellationToken cancellationToken)
    {
        return true;
    }
}