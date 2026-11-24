namespace SklepInternetowy;

public class ShipOrder(INotifier notifier) : OrderStatusChange(notifier)
{
    protected override OrderStatus NewStatus => OrderStatus.Shipped;
    protected override OrderStatus[] AllowedFrom => [OrderStatus.Paid];

    protected override string EmailSubject(Order order) =>
        $"Zamówienie {order.Id}: zostało wysłane";
}
