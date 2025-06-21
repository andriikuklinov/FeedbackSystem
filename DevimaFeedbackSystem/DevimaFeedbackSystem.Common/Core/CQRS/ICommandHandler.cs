using MediatR;

namespace DevimaFeedbackSystem.Common.Core.CQRS
{
    public interface ICommandHandler<in TCommand, TResponse>: IRequestHandler<TCommand, TResponse>
        where TCommand: ICommand<TResponse>
        where TResponse: notnull
    {
    }
    public interface ICommandHanlder<in TCommand>: ICommandHandler<TCommand, Unit> where TCommand: ICommand<Unit>
    {
    }
}
