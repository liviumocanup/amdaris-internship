namespace ConsoleApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private List<T> _items = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        public T? GetById(Guid id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }

        public void Add(T entity)
        {
            _items.Add(entity);
        }

        public void Delete(T entity)
        {
            _items.Remove(entity);
        }

        public void Update(T entity)
        {
            var index = _items.FindIndex(item => item.Id == entity.Id);
            if (index != -1)
            {
                _items[index] = entity;
            }
        }
    }
}