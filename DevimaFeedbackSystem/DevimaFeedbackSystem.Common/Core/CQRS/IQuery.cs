using MediatR;

namespace DevimaFeedbackSystem.Common.Core.CQRS
{
    public interface IQuery<out T>: IRequest<T> where T : notnull
    {
    }
}
