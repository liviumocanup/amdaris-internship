using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp.Services
{
    public class StaffService
    {
        private IRepository<Staff> _staffRepository;
        private SubscriptionService _subscriptionService;

        public StaffService(IRepository<Staff> staffRepository, SubscriptionService subscriptionService)
        {
            _staffRepository = staffRepository;
            _subscriptionService = subscriptionService;
        }

        public void AddStaff(Staff staff)
        {
            _staffRepository.Add(staff);
            _subscriptionService.SubscribeStaff(staff);

        }

        public void DeleteStaff(Staff staff)
        {
            _staffRepository.Delete(staff);
            _subscriptionService.UnsubscribeStaff(staff);
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            return _staffRepository.GetAll();
        }

        public Staff? GetStaffById(Guid id)
        {
            return _staffRepository.GetById(id);
        }

        public void UpdateStaff(Staff staff)
        {
            _staffRepository.Update(staff);
        }
    }
}