using Emails.Write.Api.Domain.Repositories;
using Emails.Write.Api.ExceptionHandling;
using Emails.Write.Api.Infrastructure.Persistence;
using Emails.Write.Api.Infrastructure.Persistence.Repositories;
using Emails.Write.Api.UseCases.ScheduleEmail;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmailWriteDbContext>(opt =>
    opt.UseNpgsql(
        builder.Configuration.GetConnectionString("Postgres"),
        npgsql => npgsql.EnableRetryOnFailure(3)));

builder.Services.AddScoped<IEmailMessageRepository, EmailMessageRepository>();
builder.Services.AddScoped<ScheduleEmailHandler>();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<DomainExceptionHandler>();

builder.Services.AddOpenApi();


var app = builder.Build();

app.UseExceptionHandler();
app.MapOpenApi();
app.MapScheduleEmailEndpoint();

// Простой healthcheck для k8s readiness/liveness
app.MapGet("/health", () => Results.Ok(new { status = "ok" })).AllowAnonymous();

app.Run();
