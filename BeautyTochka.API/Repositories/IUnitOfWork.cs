using BeautyTochka.API.Models;

namespace BeautyTochka.API.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<Service> Services { get; }
    IRepository<Master> Masters { get; }
    IRepository<Appointment> Appointments { get; }
    IRepository<User> Users { get; }
    IRepository<Review> Reviews { get; }
    Task<int> SaveAsync();
}
