using ConsoleApp.Channels;
using ConsoleApp.Channels.Manager;
using ConsoleApp.Models;
using ConsoleApp.Repositories;
using ConsoleApp.Services;

class Program
{
    static void Main(string[] args)
    {
        INotificationChannel smsChannel = new SmsNotificationChannel();
        INotificationChannel emailChannel = new EmailNotificationChannel();
        INotificationManager notificationManager = new NotificationManager();
        notificationManager.AddChannel(NotificationChannelType.Sms, smsChannel);
        notificationManager.AddChannel(NotificationChannelType.Email, emailChannel);

        IRepository<Book> bookRepository = new Repository<Book>();
        IRepository<Customer> customerRepository = new Repository<Customer>();
        IRepository<Staff> staffRepository = new Repository<Staff>();
        IRepository<Order> orderRepository = new Repository<Order>();
        
        BookService bookService = new BookService(bookRepository);
        CustomerService customerService = new CustomerService(customerRepository);


        Staff joeStaff = new Staff("John Doe", "jdoe@gmail.com", "+1234567890");
        joeStaff.PreferredChannel.Add(NotificationChannelType.Email);

        Staff mikeStaff = new Staff("Mike Smith", "msmith@gmail.com", "+0987654321");
        mikeStaff.PreferredChannel.Add(NotificationChannelType.Sms);

        Customer aliceCustomer = new Customer("Alice Brown", "abrown@gmail.com", "+1357924680");
        aliceCustomer.PreferredChannel.Add(NotificationChannelType.Email);
        aliceCustomer.PreferredChannel.Add(NotificationChannelType.Sms);
        customerService.AddCustomer(aliceCustomer);

        Book book = new Book("The Hobbit", "J.R.R. Tolkien", "isbn1234567890", 10);
        bookService.AddBook(book);

        SubscriptionService subscriptionService = new SubscriptionService(notificationManager);
        StaffService staffService = new StaffService(staffRepository, subscriptionService);
        staffService.AddStaff(joeStaff);
        staffService.AddStaff(mikeStaff);
        
        OrderService orderService = new OrderService(orderRepository, bookRepository, subscriptionService);

        Console.WriteLine("Placing order for Alice...");
        Guid orderId = orderService.PlaceOrder(aliceCustomer, new List<Guid> { book.Id }).GetValueOrDefault();
        Console.WriteLine();


        Console.WriteLine("Processing order...");
        orderService.ProcessOrder(orderId, joeStaff.Id);
        Console.WriteLine();

        Console.WriteLine("Order ready for shipping...");
        orderService.ReadyOrder(orderId);
        Console.WriteLine();

        // Console.WriteLine("Order cancelled...");
        // orderService.CancelOrder(orderId);
        // Console.WriteLine();

        Console.WriteLine("Order shipped...");
        orderService.ShipOrder(orderId, mikeStaff.Id);
        Console.WriteLine();

        Console.WriteLine("Order delivered...");
        orderService.DeliveredOrder(orderId);
        Console.WriteLine();

        Console.WriteLine("Order completed...");
        orderService.CompleteOrder(orderId);
        Console.WriteLine();

        // Console.WriteLine("Order shipped...");
        // orderService.ShipOrder(orderId, mikeStaff.Id);
        // Console.WriteLine();

        orderService.CheckOrderStatus(orderId);
    }
}