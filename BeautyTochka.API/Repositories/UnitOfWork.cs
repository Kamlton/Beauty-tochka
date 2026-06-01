using BeautyTochka.API.Data;
using BeautyTochka.API.Models;

namespace BeautyTochka.API.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IRepository<Service> Services { get; }
    public IRepository<Master> Masters { get; }
    public IRepository<Appointment> Appointments { get; }
    public IRepository<User> Users { get; }
    public IRepository<Review> Reviews { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Services = new Repository<Service>(context);
        Masters = new Repository<Master>(context);
        Appointments = new Repository<Appointment>(context);
        Users = new Repository<User>(context);
        Reviews = new Repository<Review>(context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
