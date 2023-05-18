using System.Reflection;
using FlexibleTransactionHandler.Application.Attributes;
using FlexibleTransactionHandler.Infra;
using MediatR;

namespace FlexibleTransactionHandler.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<TransactionBehavior<TRequest, TResponse>>  _logger;
    private readonly OrderDbContext _dbContext;

    public TransactionBehavior(
        OrderDbContext dbContext,
        ILogger<TransactionBehavior<TRequest, TResponse>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestType = request.GetType();
        
        var tranAttri = requestType.GetCustomAttribute(typeof(TransactionalAttribute));
        
        if (tranAttri is null)
            return await next();
        
        if (_dbContext.HasActiveTransaction)
            return await next();

        var response = default(TResponse);
        var typeName = requestType.Name;

        await using var transaction = await _dbContext.BeginTransactionAsync();

        _logger.LogInformation("----- Begin transaction for {CommandName} ({@Command})", typeName, request);

        response = await next();

        _logger.LogInformation("----- Commit transaction for {CommandName}", typeName);

        await _dbContext.CommitTransactionAsync(transaction);
        
        return response;
    }
}