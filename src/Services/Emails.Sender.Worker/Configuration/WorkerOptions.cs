namespace Emails.Sender.Worker.Configuration;

public sealed class WorkerOptions
{
    public int BatchSize { get; init; } = 20;
    public int MaxBatchesPerCycle { get; init; } = 10;
    public int PollIntervalSeconds { get; init; } = 60;   // "раз в минуту"
    public int LeaseDurationMinutes { get; init; } = 5;
    public int MaxAttempts { get; init; } = 5;
    public int BackoffBaseSeconds { get; init; } = 60;
    public int BackoffMaxMinutes { get; init; } = 60;
}
