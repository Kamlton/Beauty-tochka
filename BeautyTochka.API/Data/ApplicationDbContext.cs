using BeautyTochka.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyTochka.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Service> Services => Set<Service>();
    public DbSet<Master> Masters => Set<Master>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Review> Reviews => Set<Review>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed initial services
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Классический маникюр", Description = "Простой уход за ногтями", Category = "Маникюр", Duration = "1 час", Price = "1000₽" },
            new Service { Id = 2, Name = "Французский маникюр", Description = "Светлые кончики ногтей", Category = "Маникюр", Duration = "1.2 часа", Price = "1200₽" },
            new Service { Id = 3, Name = "Аппаратный маникюр", Description = "Современный аппаратный уход", Category = "Маникюр", Duration = "1.1 часа", Price = "1100₽" },
            new Service { Id = 4, Name = "Маникюр с покрытием гель-лак", Description = "Укрепление и долговечное покрытие", Category = "Маникюр", Duration = "1.5 часа", Price = "1500₽" },
            new Service { Id = 5, Name = "Детский маникюр", Description = "Нежный уход за ногтями детей", Category = "Маникюр", Duration = "0.5 часа", Price = "500₽" },
            new Service { Id = 6, Name = "Аппаратный педикюр", Description = "Безопасная обработка стоп", Category = "Педикюр", Duration = "1.5 часа", Price = "1500₽" },
            new Service { Id = 7, Name = "Spa-педикюр", Description = "Расслабляющий уход за ногами", Category = "Педикюр", Duration = "2 часа", Price = "2000₽" },
            new Service { Id = 8, Name = "Аппаратный педикюр", Description = "Уход за ногами с аппаратом", Category = "Педикюр", Duration = "1.3 часа", Price = "1300₽" },
            new Service { Id = 9, Name = "Педикюр с покрытием гель-лак", Description = "Долговечное покрытие", Category = "Педикюр", Duration = "2 часа", Price = "2200₽" },
            new Service { Id = 10, Name = "Детский педикюр", Description = "Уход за ногтями на ногах у детей", Category = "Педикюр", Duration = "0.7 часа", Price = "700₽" },
            new Service { Id = 11, Name = "Женская стрижка", Description = "Стрижка любой сложности", Category = "Стрижки", Duration = "1 час", Price = "1200₽" },
            new Service { Id = 12, Name = "Мужская стрижка", Description = "Классическая или модельная", Category = "Стрижки", Duration = "1.2 часа", Price = "1400₽" },
            new Service { Id = 13, Name = "Стрижка челки", Description = "Подравнивание или создание челки", Category = "Стрижки", Duration = "1.5 часа", Price = "1600₽" },
            new Service { Id = 14, Name = "Стрижка горячими ножницами", Description = "Уход с запаиванием кончиков", Category = "Стрижки", Duration = "0.8 часа", Price = "1000₽" },
            new Service { Id = 15, Name = "Стрижка бороды и усов", Description = "Моделирование бороды", Category = "Стрижки", Duration = "1 час", Price = "1200₽" },
            new Service { Id = 16, Name = "Окрашивание в один тон", Description = "Красивый однотонный цвет", Category = "Окрашивание волос", Duration = "1.5 часа", Price = "2000₽" },
            new Service { Id = 17, Name = "Мелирование", Description = "Эффект солнечных бликов", Category = "Окрашивание волос", Duration = "2.5 часа", Price = "3500₽" },
            new Service { Id = 18, Name = "Балаяж", Description = "Плавные переходы цвета", Category = "Окрашивание волос", Duration = "2 часа", Price = "3000₽" },
            new Service { Id = 19, Name = "Шатуш", Description = "Естественное выгорание волос", Category = "Окрашивание волос", Duration = "1.2 часа", Price = "1800₽" },
            new Service { Id = 20, Name = "Тонирование волос", Description = "Придание оттенка волосам", Category = "Окрашивание волос", Duration = "3 часа", Price = "4000₽" },
            new Service { Id = 21, Name = "Наращивание ресниц классика", Description = "Классический объём", Category = "Ресницы", Duration = "1.5 часа", Price = "2000₽" },
            new Service { Id = 22, Name = "Наращивание ресниц 2D", Description = "Двойной объём", Category = "Ресницы", Duration = "2 часа", Price = "2500₽" },
            new Service { Id = 23, Name = "Наращивание ресниц 3D", Description = "Тройной объём", Category = "Ресницы", Duration = "2.5 часа", Price = "3000₽" },
            new Service { Id = 24, Name = "Ламинирование ресниц", Description = "Завивка и ламинирование", Category = "Ресницы", Duration = "0.5 часа", Price = "500₽" },
            new Service { Id = 25, Name = "Окрашивание ресниц", Description = "Окрашивание ресниц краской", Category = "Ресницы", Duration = "1 час", Price = "1200₽" },
            new Service { Id = 26, Name = "Коррекция бровей", Description = "Придание формы бровям", Category = "Брови", Duration = "0.5 часа", Price = "500₽" },
            new Service { Id = 27, Name = "Окрашивание бровей", Description = "Стойкое окрашивание", Category = "Брови", Duration = "1 час", Price = "800₽" },
            new Service { Id = 28, Name = "Ламинирование бровей", Description = "Укладка бровей", Category = "Брови", Duration = "1 час", Price = "900₽" },
            new Service { Id = 29, Name = "Брови + окрашивание", Description = "Комплексная услуга", Category = "Брови", Duration = "1.2 часа", Price = "1200₽" },
            new Service { Id = 30, Name = "Брови + ламинирование", Description = "Укладка + окрашивание", Category = "Брови", Duration = "1.2 часа", Price = "1300₽" },
            new Service { Id = 31, Name = "Депиляция ног", Description = "Удаление волос на ногах", Category = "Депиляция", Duration = "1 час", Price = "1200₽" },
            new Service { Id = 32, Name = "Депиляция рук", Description = "Удаление волос на руках", Category = "Депиляция", Duration = "0.5 часа", Price = "700₽" },
            new Service { Id = 33, Name = "Депиляция подмышек", Description = "Удаление волос в зоне подмышек", Category = "Депиляция", Duration = "0.3 часа", Price = "500₽" },
            new Service { Id = 34, Name = "Депиляция зоны бикини", Description = "Комплексная депиляция", Category = "Депиляция", Duration = "0.8 часа", Price = "1000₽" },
            new Service { Id = 35, Name = "Депиляция лица", Description = "Удаление нежелательных волос", Category = "Депиляция", Duration = "1 час", Price = "1500₽" }
        );

        // Seed initial masters
        modelBuilder.Entity<Master>().HasData(
            new Master { Id = 1, FullName = "Анна Петрова", Position = "Мастер маникюра", Description = "Безопасный аппаратный маникюр", Email = "anna@beautytochka.ru", PhoneNumber = "+79991234567", PhotoUrl = "https://i.pinimg.com/736x/07/fa/d3/07fad317b2a9a179ed69b398e16f4e8c.jpg", WorkPhotos = new List<string> { "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Маникюр+2", "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Маникюр+3" } },
            new Master { Id = 2, FullName = "Мария Иванова", Position = "Мастер педикюра", Description = "Безопасный аппаратный педикюр", Email = "maria@beautytochka.ru", PhoneNumber = "+79991234568", PhotoUrl = "https://i.pinimg.com/736x/b7/c1/28/b7c12860487f4dee409cfdafd80984f6.jpg", WorkPhotos = new List<string> { "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Педикюр+2", "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Педикюр+3" } },
            new Master { Id = 3, FullName = "Екатерина Смирнова", Position = "Мастер по ресницам и бровям", Description = "Идеальные ресницы и брови", Email = "kate@beautytochka.ru", PhoneNumber = "+79991234569", PhotoUrl = "https://i.pinimg.com/736x/9e/ce/64/9ece64401f95ccf86d4f9e14df502822.jpg", WorkPhotos = new List<string> { "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Ресницы+2", "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Брови+3" } },
            new Master { Id = 4, FullName = "Ольга Кузнецова", Position = "Депиляция", Description = "Безболезненная депиляция", Email = "olga@beautytochka.ru", PhoneNumber = "+79991234570", PhotoUrl = "https://i.pinimg.com/1200x/64/ab/4d/64ab4d0acd0d74ed86575d556d8443d8.jpg", WorkPhotos = new List<string> { "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Депиляция+2", "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Депиляция+3" } },
            new Master { Id = 5, FullName = "Кристина Волкова", Position = "Парикмахер-стилист", Description = "Стрижка и окрашивание любой сложности", Email = "kristina@beautytochka.ru", PhoneNumber = "+79991234571", PhotoUrl = "https://i.pinimg.com/736x/7a/02/e2/7a02e27698eef75fccf750d3a6089fa4.jpg", WorkPhotos = new List<string> { "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Стрижка+2", "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Окрашивание+3" } },
            new Master { Id = 6, FullName = "Дарья Соколова", Position = "Косметолог", Description = "Профессиональный уход за кожей", Email = "daria@beautytochka.ru", PhoneNumber = "+79991234572", PhotoUrl = "https://i.pinimg.com/736x/1d/25/20/1d25204d5aeaf6f1bff221d856d672db.jpg", WorkPhotos = new List<string> { "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Косметология+2", "https://placehold.co/400x500/2F1C1B/FFFBF3?text=Уход+3" } }
        );

        // Seed initial reviews
        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, AuthorName = "Александра", Text = "Отличный салон! Мастер Анна сделала идеальный маникюр. Обязательно приду ещё.", Rating = 5, CreatedAt = new DateTime(2026, 5, 10, 10, 0, 0, DateTimeKind.Utc) },
            new Review { Id = 2, AuthorName = "Елена", Text = "Очень довольна стрижкой у Марии. Профессионал своего дела.", Rating = 5, CreatedAt = new DateTime(2026, 5, 12, 14, 30, 0, DateTimeKind.Utc) },
            new Review { Id = 3, AuthorName = "Оксана", Text = "Педикюр у Ольги прошёл просто замечательно, очень аккуратно.", Rating = 4, CreatedAt = new DateTime(2026, 5, 15, 9, 15, 0, DateTimeKind.Utc) },
            new Review { Id = 4, AuthorName = "Ирина", Text = "Косметолог Екатерина подобрала мне отличный уход за кожей. Рекомендую!", Rating = 5, CreatedAt = new DateTime(2026, 5, 18, 16, 45, 0, DateTimeKind.Utc) },
            new Review { Id = 5, AuthorName = "Виктория", Text = "Делала ресницы у Кристины, результат превзошёл ожидания.", Rating = 5, CreatedAt = new DateTime(2026, 5, 20, 11, 0, 0, DateTimeKind.Utc) }
        );
    }
}
