namespace SklepInternetowy;

public abstract class OrderStatusChange
{
    private readonly INotifier _notifier;

    protected OrderStatusChange(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void Execute(Order order)
    {
        if (!AllowedFrom.Contains(order.Status))
            throw new InvalidOperationException(
                $"Nie można zmienić statusu z {order.Status} na {NewStatus}.");

        OnChange(order);

        order.Status = NewStatus;

        _notifier.Send(order.CustomerEmail, EmailSubject(order));
    }

    protected abstract OrderStatus NewStatus { get; }
    protected abstract OrderStatus[] AllowedFrom { get; }
    protected abstract string EmailSubject(Order order);
    protected virtual void OnChange(Order order) { }
}
