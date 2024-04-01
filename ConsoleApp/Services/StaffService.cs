namespace ConsoleApp.Services
{
    public class StaffService
    {
        private IRepository<Staff> _staffRepository;

        public StaffService(IRepository<Staff> staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            return _staffRepository.GetAll();
        }

        public Staff? GetStaffById(Guid id)
        {
            return _staffRepository.GetById(id);
        }

        public void AddStaff(Staff staff)
        {
            _staffRepository.Add(staff);
        }

        public void DeleteStaff(Staff staff)
        {
            _staffRepository.Delete(staff);
        }

        public void UpdateStaff(Staff staff)
        {
            _staffRepository.Update(staff);
        }
    }
}