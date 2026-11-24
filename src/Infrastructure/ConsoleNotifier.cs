namespace SklepInternetowy;
public class ConsoleNotifier : INotifier
{
    public void Send(string to, string subject) =>
        Console.WriteLine($"[E-MAIL do {to}] {subject}");
}
