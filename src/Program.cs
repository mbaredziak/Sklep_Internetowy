using SklepInternetowy;

INotifier notifier = new ConsoleNotifier();
var pay = new PayOrder(notifier);
var ship = new ShipOrder(notifier);
var cancel = new CancelOrder(notifier);

Console.WriteLine("1. Zamówienie: opłacenie i wysyłka");
var order1 = new Order(1, "jan@example.com");
pay.Execute(order1);
ship.Execute(order1);
Console.WriteLine($"Status: {order1.Status}\n");

Console.WriteLine("2. Anulowanie opłaconego zamówienia (zwrot środków)");
var order2 = new Order(2, "anna@example.com");
pay.Execute(order2);
cancel.Execute(order2);
Console.WriteLine($"Status: {order2.Status}, zwrot: {order2.RefundRequested}\n");

Console.WriteLine("3. Anulowanie nieopłaconego zamówienia (bez zwrotu)");
var order3 = new Order(3, "piotr@example.com");
cancel.Execute(order3);
Console.WriteLine($"Status: {order3.Status}, zwrot: {order3.RefundRequested}\n");

Console.WriteLine("4. Niedozwolona zmiana: wysyłka nieopłaconego zamówienia");
var order4 = new Order(4, "ewa@example.com");
try
{
    ship.Execute(order4);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Błąd: {ex.Message}");
    Console.WriteLine($"Status bez zmian: {order4.Status}");
}
class ConsoleNotifier : INotifier
{
    public void Send(string to, string subject) =>
        Console.WriteLine($"[E-MAIL do {to}] {subject}");
}
