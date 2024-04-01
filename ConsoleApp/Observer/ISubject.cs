namespace ConsoleApp.Observer
{
    public interface ISubject
    {
        void Attach(ISubscriber observer);
        void Detach(ISubscriber observer);
        void Notify();
    }
}
