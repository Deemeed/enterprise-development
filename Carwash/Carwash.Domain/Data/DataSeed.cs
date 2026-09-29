using Carwash.Domain.Entities;
using Carwash.Domain.Enums;

namespace Carwash.Domain.Data;

/// <summary>
/// Класс тестовых данных
/// </summary>
public static class DataSeed
{
    /// <summary>
    /// Время, относительно которого формируются тестовые данные.
    /// </summary>
    public static DateTime CurrentTime { get; } = new(2026, 9, 24, 12, 0, 0);

    /// <summary>
    /// Клиенты
    /// </summary>
    public static List<Client> Clients { get; } =
    [
        new Client
        {
            Id = 1,
            FullName = "Иван Петров",
            PhoneNumber = "+79990000001",
            Cars = []
        },
        new Client
        {
            Id = 2,
            FullName = "Анна Сидорова",
            PhoneNumber = "+79990000002",
            Cars = []
        },
        new Client
        {
            Id = 3,
            FullName = "Алексей Смирнов",
            PhoneNumber = "+79990000003",
            Cars = []
        },
        new Client
        {
            Id = 4,
            FullName = "Мария Иванова",
            PhoneNumber = "+79990000004",
            Cars = []
        },
        new Client
        {
            Id = 5,
            FullName = "Дмитрий Кузнецов",
            PhoneNumber = "+79990000005",
            Cars = []
        },
        new Client
        {
            Id = 6,
            FullName = "Елена Попова",
            PhoneNumber = "+79990000006",
            Cars = []
        },
        new Client
        {
            Id = 7,
            FullName = "Сергей Волков",
            PhoneNumber = "+79990000007",
            Cars = []
        }
    ];

    /// <summary>
    /// Автомобили
    /// </summary>
    public static List<Car> Cars { get; } =
    [
        new Car
        {
            Id = 1,
            LicensePlate = "А111АА",
            Brand = "BMW",
            Client = Clients[0]
        },
        new Car
        {
            Id = 2,
            LicensePlate = "В222ВВ",
            Brand = "Toyota",
            Client = Clients[1]
        },
        new Car
        {
            Id = 3,
            LicensePlate = "С333СС",
            Brand = "Mercedes-Benz",
            Client = Clients[2]
        },
        new Car
        {
            Id = 4,
            LicensePlate = "Е444ЕЕ",
            Brand = "Audi",
            Client = Clients[3]
        },
        new Car
        {
            Id = 5,
            LicensePlate = "К555КК",
            Brand = "Lexus",
            Client = Clients[4]
        },
        new Car
        {
            Id = 6,
            LicensePlate = "М666ММ",
            Brand = "Volkswagen",
            Client = Clients[5]
        },
        new Car
        {
            Id = 7,
            LicensePlate = "Н777НН",
            Brand = "Volvo",
            Client = Clients[6]
        },
        new Car
        {
            Id = 8,
            LicensePlate = "О888ОО",
            Brand = "Range Rover",
            Client = Clients[0]
        }
    ];

    /// <summary>
    /// Услуги
    /// </summary>
    public static List<Service> Services { get; } =
    [
        new Service
        {
            Id = 1,
            Name = "Экспресс-мойка",
            Price = 800m,
            Category = Category.Standard,
            DurationInMinutes = 30
        },
        new Service
        {
            Id = 2,
            Name = "Комплексная мойка",
            Price = 1500m,
            Category = Category.Standard,
            DurationInMinutes = 60
        },
        new Service
        {
            Id = 3,
            Name = "Премиум-мойка",
            Price = 2500m,
            Category = Category.Premium,
            DurationInMinutes = 90
        },
        new Service
        {
            Id = 4,
            Name = "Мойка внедорожника",
            Price = 3000m,
            Category = Category.Suv,
            DurationInMinutes = 120
        },
        new Service
        {
            Id = 5,
            Name = "Люкс-мойка",
            Price = 4000m,
            Category = Category.Luxury,
            DurationInMinutes = 150
        }
    ];

    /// <summary>
    /// Заказы
    /// </summary>
    public static List<Order> Orders { get; } =
    [
        // Иван Петров — 6 посещений
        new Order
        {
            Id = 1,
            Client = Clients[0],
            Car = Cars[0],
            Service = Services[0],
            BoxNumber = 1,
            StartTime = CurrentTime.AddDays(-10).AddHours(1)
        },
        new Order
        {
            Id = 2,
            Client = Clients[0],
            Car = Cars[0],
            Service = Services[1],
            BoxNumber = 2,
            StartTime = CurrentTime.AddDays(-9).AddHours(2)
        },
        new Order
        {
            Id = 3,
            Client = Clients[0],
            Car = Cars[0],
            Service = Services[2],
            BoxNumber = 3,
            StartTime = CurrentTime.AddDays(-8).AddHours(3)
        },
        new Order
        {
            Id = 4,
            Client = Clients[0],
            Car = Cars[0],
            Service = Services[0],
            BoxNumber = 1,
            StartTime = CurrentTime.AddDays(-7).AddHours(1)
        },
        new Order
        {
            Id = 5,
            Client = Clients[0],
            Car = Cars[0],
            Service = Services[1],
            BoxNumber = 2,
            StartTime = CurrentTime.AddDays(-6).AddHours(2)
        },

        // Анна Сидорова — 5 посещений
        new Order
        {
            Id = 6,
            Client = Clients[1],
            Car = Cars[1],
            Service = Services[0],
            BoxNumber = 1,
            StartTime = CurrentTime.AddDays(-10).AddHours(2)
        },
        new Order
        {
            Id = 7,
            Client = Clients[1],
            Car = Cars[1],
            Service = Services[1],
            BoxNumber = 2,
            StartTime = CurrentTime.AddDays(-9).AddHours(3)
        },
        new Order
        {
            Id = 8,
            Client = Clients[1],
            Car = Cars[1],
            Service = Services[2],
            BoxNumber = 3,
            StartTime = CurrentTime.AddDays(-7).AddHours(4)
        },
        new Order
        {
            Id = 9,
            Client = Clients[1],
            Car = Cars[1],
            Service = Services[0],
            BoxNumber = 1,
            StartTime = CurrentTime.AddDays(-6).AddHours(1)
        },

        // Алексей Смирнов — 4 посещения
        new Order
        {
            Id = 10,
            Client = Clients[2],
            Car = Cars[2],
            Service = Services[3],
            BoxNumber = 4,
            StartTime = CurrentTime.AddDays(-9).AddHours(1)
        },
        new Order
        {
            Id = 11,
            Client = Clients[2],
            Car = Cars[2],
            Service = Services[2],
            BoxNumber = 3,
            StartTime = CurrentTime.AddDays(-7).AddHours(2)
        },
        new Order
        {
            Id = 12,
            Client = Clients[2],
            Car = Cars[2],
            Service = Services[0],
            BoxNumber = 1,
            StartTime = CurrentTime.AddDays(-5).AddHours(1)
        },

        // Мария Иванова — 3 посещения
        new Order
        {
            Id = 13,
            Client = Clients[3],
            Car = Cars[3],
            Service = Services[1],
            BoxNumber = 2,
            StartTime = CurrentTime.AddDays(-8).AddHours(2)
        },
        new Order
        {
            Id = 14,
            Client = Clients[3],
            Car = Cars[3],
            Service = Services[4],
            BoxNumber = 5,
            StartTime = CurrentTime.AddDays(-6).AddHours(3)
        },
        new Order
        {
            Id = 15,
            Client = Clients[3],
            Car = Cars[3],
            Service = Services[0],
            BoxNumber = 1,
            StartTime = CurrentTime.AddDays(-4).AddHours(1)
        },

        // Дмитрий Кузнецов — 2 посещения
        new Order
        {
            Id = 16,
            Client = Clients[4],
            Car = Cars[4],
            Service = Services[1],
            BoxNumber = 2,
            StartTime = CurrentTime.AddDays(-7).AddHours(2)
        },
        new Order
        {
            Id = 17,
            Client = Clients[4],
            Car = Cars[4],
            Service = Services[2],
            BoxNumber = 3,
            StartTime = CurrentTime.AddDays(-5).AddHours(3)
        },

        // Елена Попова — 2 посещения
        new Order
        {
            Id = 18,
            Client = Clients[5],
            Car = Cars[5],
            Service = Services[0],
            BoxNumber = 1,
            StartTime = CurrentTime.AddDays(-6).AddHours(2)
        },
        new Order
        {
            Id = 19,
            Client = Clients[5],
            Car = Cars[5],
            Service = Services[3],
            BoxNumber = 4,
            StartTime = CurrentTime.AddDays(-4).AddHours(3)
        },

        // Сергей Волков — 1 посещение
        new Order
        {
            Id = 20,
            Client = Clients[6],
            Car = Cars[6],
            Service = Services[4],
            BoxNumber = 5,
            StartTime = CurrentTime.AddDays(-3).AddHours(1)
        },

        // Текущие заказы
        new Order
        {
            Id = 21,
            Client = Clients[0],
            Car = Cars[0],
            Service = Services[2],
            BoxNumber = 1,
            StartTime = CurrentTime.AddMinutes(-20)
        },

        new Order
        {
            Id = 22,
            Client = Clients[1],
            Car = Cars[1],
            Service = Services[3],
            BoxNumber = 4,
            StartTime = CurrentTime.AddMinutes(-30)
        },

        new Order
        {
            Id = 23,
            Client = Clients[2],
            Car = Cars[2],
            Service = Services[1],
            BoxNumber = 2,
            StartTime = CurrentTime.AddMinutes(-15)
        }
    ];
}
