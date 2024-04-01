namespace ConsoleApp.Models
{
    public class Order : BaseEntity, ISubject
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public List<Book> Books { get; set; }
        public Guid CustomerId { get; set; }
        private OrderStatus _status;
        public OrderStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                Notify();
            }
        }

        public void Attach(ISubscriber observer)
        {
            _subscribers.Add(observer);
        }

        public void Detach(ISubscriber observer)
        {
            _subscribers.Remove(observer);
        }

        public void Notify()
        {
            _subscribers.ForEach(observer => observer.Update(this));
        }
    }
}
