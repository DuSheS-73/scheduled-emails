namespace Emails.Sender.Worker.Configuration;

public sealed class SmtpOptions
{
    public string Host { get; init; } = "";
    public int Port { get; init; } = 587;
    public bool UseStartTls { get; init; } = true;
    public string Username { get; init; } = "";
    public string Password { get; init; } = "";
    public string FromAddress { get; init; } = "";
    public string FromName { get; init; } = "Email Scheduler";
    public string DefaultSubject { get; init; } = "Scheduled notification";
    public int TimeoutSeconds { get; init; } = 30;
}
