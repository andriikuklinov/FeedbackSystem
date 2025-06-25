using FluentValidation;
using Grpc.Core;
using Grpc.Core.Interceptors;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace DevimaFeedbackSystem.Common.Core.Validation
{
    public class ValidationInterceptor: Interceptor
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationInterceptor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch(ValidationException ex)
            {
                var details = string.Join("; ", ex.Errors.Select(e => e.ErrorMessage));
                throw new RpcException(new Status(StatusCode.InvalidArgument, details));
            }
            catch(RpcException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Internal server error"));
            }
        }
    }
}
