public class UserService
{
    private IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }

    public void DeleteUser(int userId)
    {
        User? user = _userRepository.GetById(userId);
        if (user != null)
        {
            _userRepository.Delete(user);
        }
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public User? GetUserById(int userId)
    {
        return _userRepository.GetById(userId);
    }

    public void UpdateUser(User user)
    {
        _userRepository.Update(user);
    }
}
