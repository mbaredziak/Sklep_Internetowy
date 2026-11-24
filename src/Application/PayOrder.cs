namespace SklepInternetowy;

public class PayOrder(INotifier notifier) : OrderStatusChange(notifier)
{
    protected override OrderStatus NewStatus => OrderStatus.Paid;
    protected override OrderStatus[] AllowedFrom => [OrderStatus.AwaitingPayment];

    protected override string EmailSubject(Order order) =>
        $"Zamówienie {order.Id}: płatność przyjęta";
}
