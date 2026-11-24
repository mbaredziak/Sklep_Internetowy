namespace SklepInternetowy;

public class CancelOrder(INotifier notifier) : OrderStatusChange(notifier)
{
    protected override OrderStatus NewStatus => OrderStatus.Cancelled;
    protected override OrderStatus[] AllowedFrom => [OrderStatus.AwaitingPayment, OrderStatus.Paid];

    protected override void OnChange(Order order)
    {
        order.RefundRequested = order.Status == OrderStatus.Paid;
    }

    protected override string EmailSubject(Order order) =>
        $"Zamówienie {order.Id}: zostało anulowane";
}
