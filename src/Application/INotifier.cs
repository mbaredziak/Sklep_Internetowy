namespace SklepInternetowy;

public interface INotifier
{
    void Send(string to, string subject);
}
