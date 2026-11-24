namespace SklepInternetowy;

public enum OrderStatus
{
    AwaitingPayment,
    Paid,
    Shipped,
    Cancelled
}

public class Order
{
    public Order(int id, string customerEmail)
    {
        Id = id;
        CustomerEmail = customerEmail;
        Status = OrderStatus.AwaitingPayment;
    }

    public int Id { get; }
    public string CustomerEmail { get; }
    public OrderStatus Status { get; set; }
    public bool RefundRequested { get; set; }
}
