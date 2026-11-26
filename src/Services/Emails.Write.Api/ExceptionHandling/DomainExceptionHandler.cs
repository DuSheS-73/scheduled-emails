using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Emails.Write.Api.ExceptionHandling;

public sealed class DomainExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext ctx, Exception ex, CancellationToken ct)
    {
        if (ex is not DomainException domain) return false;

        ctx.Response.StatusCode = StatusCodes.Status400BadRequest;
        await ctx.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Title = "Domain validation failed",
            Detail = domain.Message,
            Status = StatusCodes.Status400BadRequest,
            Instance = ctx.Request.Path
        }, ct);
        return true;
    }
}