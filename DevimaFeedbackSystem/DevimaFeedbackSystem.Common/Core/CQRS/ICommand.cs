using MediatR;

namespace DevimaFeedbackSystem.Common.Core.CQRS
{
    public interface ICommand: IRequest<Unit>
    {
    }
    public interface ICommand<out T>: IRequest<T>
    {
    }
}
