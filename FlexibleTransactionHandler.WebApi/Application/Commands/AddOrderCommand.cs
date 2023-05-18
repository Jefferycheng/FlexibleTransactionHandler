using FlexibleTransactionHandler.Application.Attributes;
using MediatR;

namespace FlexibleTransactionHandler.Application.Commands;

[Transactional]
public class AddOrderCommand : IRequest<bool>
{
    
}