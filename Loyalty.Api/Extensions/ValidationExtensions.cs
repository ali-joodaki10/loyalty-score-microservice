using FluentValidation;
using Grpc.Core;

namespace Loyalty.Api.Extensions;

public static class ValidationExtensions
{
    public static async Task ValidateAndThrowGrpc<T>(
        this IValidator<T> validator,
        T model)
    {
        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            throw new RpcException(new Status(
                StatusCode.InvalidArgument,
                string.Join(", ", result.Errors.Select(e => e.ErrorMessage))
            ));
        }
    }
}