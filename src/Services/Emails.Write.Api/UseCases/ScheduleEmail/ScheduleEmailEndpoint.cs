using Emails.Write.Api.Contracts;
using FluentValidation;

namespace Emails.Write.Api.UseCases.ScheduleEmail;

public static class ScheduleEmailEndpoint
{
    public static IEndpointRouteBuilder MapScheduleEmailEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/emails").WithTags("Emails");

        group.MapPost("/schedule", async (
            ScheduleEmailRequest request,
            ScheduleEmailHandler handler,
            CancellationToken ct) =>
        {
            var result = await handler.HandleAsync(
                new ScheduleEmailCommand(request.Recipient, request.Body, request.ScheduledAt),
                ct);

            return Results.Created(
                $"/api/emails/{result.Id}",
                new ScheduleEmailResponse(result.Id, result.ScheduledAt));
        })
        .AllowAnonymous()
        .WithName("ScheduleEmail")
        .Produces<ScheduleEmailResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        return app;
    }
}
