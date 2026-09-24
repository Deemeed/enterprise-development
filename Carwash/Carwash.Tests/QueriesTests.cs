using Carwash.Domain.Entities;

namespace Carwash.Tests;

/// <summary>
/// Тесты
/// </summary>
public class QueriesTests(QueriesTestsFixture fixture) : IClassFixture<QueriesTestsFixture>
{
    /// <summary>
    /// Проверяет данные о топ-5 клиентов по количеству посещений.
    /// </summary>
    [Fact]
    public void GetTopFiveClients_ShouldReturnClientsOrderedByVisitCount()
    {
        var result = fixture.Orders
            .GroupBy(order => order.Client)
            .Select(group => new
            {
                Client = group.Key,
                VisitCount = group.Count()
            })
            .OrderByDescending(item => item.VisitCount)
            .ThenBy(item => item.Client.Id)
            .Take(5)
            .ToList();

        Assert.Equal(5, result.Count);

        Assert.Equal("Иван Петров", result[0].Client.FullName);
        Assert.Equal(6, result[0].VisitCount);

        Assert.Equal("Анна Сидорова", result[1].Client.FullName);
        Assert.Equal(5, result[1].VisitCount);

        Assert.Equal("Алексей Смирнов", result[2].Client.FullName);
        Assert.Equal(4, result[2].VisitCount);

        Assert.Equal("Мария Иванова", result[3].Client.FullName);
        Assert.Equal(3, result[3].VisitCount);

        Assert.Equal("Дмитрий Кузнецов", result[4].Client.FullName);
        Assert.Equal(2, result[4].VisitCount);
    }

    /// <summary>
    /// Проверяет информацию об автомобилях, которые находятся на мойке в текущий момент времени.
    /// </summary>
    [Fact]
    public void GetCarsCurrentlyAtCarWash_ShouldReturnActiveOrders()
    {
        var currentTime = fixture.CurrentTime;

        var result = fixture.Orders
            .Where(order =>
                order.StartTime <= currentTime &&
                order.EndTime > currentTime)
            .Select(order => order.Car)
            .Distinct()
            .ToList();

        Assert.Equal(3, result.Count);

        Assert.Contains(result, car => car.Id == 1);
        Assert.Contains(result, car => car.Id == 2);
        Assert.Contains(result, car => car.Id == 3);

        Assert.DoesNotContain(result, car => car.Id == 4);
        Assert.DoesNotContain(result, car => car.Id == 5);
        Assert.DoesNotContain(result, car => car.Id == 6);
        Assert.DoesNotContain(result, car => car.Id == 7);
        Assert.DoesNotContain(result, car => car.Id == 8);
    }

    /// <summary>
    /// Проверяет информацию о топ-5 наиболее популярных услуг.
    /// </summary>
    [Fact]
    public void GetTopFivePopularServices_ShouldReturnServicesOrderedByOrderCount()
    {
        var result = fixture.Orders
            .GroupBy(order => order.Service)
            .Select(group => new
            {
                Service = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(item => item.OrderCount)
            .ThenBy(item => item.Service.Id)
            .Take(5)
            .ToList();

        Assert.Equal(5, result.Count);

        Assert.Equal("Экспресс-мойка", result[0].Service.Name);
        Assert.Equal(7, result[0].OrderCount);

        Assert.Equal("Комплексная мойка", result[1].Service.Name);
        Assert.Equal(6, result[1].OrderCount);

        Assert.Equal("Премиум-мойка", result[2].Service.Name);
        Assert.Equal(5, result[2].OrderCount);

        Assert.Equal("Мойка внедорожника", result[3].Service.Name);
        Assert.Equal(3, result[3].OrderCount);

        Assert.Equal("Люкс-мойка", result[4].Service.Name);
        Assert.Equal(2, result[4].OrderCount);
    }

    /// <summary>
    /// Проверяет информацию о времени освобождения выбранного бокса.
    /// </summary>
    [Fact]
    public void GetBoxReleaseTime_ShouldReturnLatestActiveOrderEndTime()
    {
        const int boxNumber = 1;
        var currentTime = fixture.CurrentTime;

        var releaseTime = fixture.Orders
            .Where(order =>
                order.BoxNumber == boxNumber &&
                order.StartTime <= currentTime &&
                order.EndTime > currentTime)
            .Select(order => order.EndTime)
            .Max();

        var expectedReleaseTime = new DateTime(
            2026,
            9,
            24,
            13,
            10,
            0);

        Assert.Equal(expectedReleaseTime, releaseTime);
    }

    /// <summary>
    /// Проверяет информацию о суммарной выручке по каждой услуге.
    /// </summary>
    [Fact]
    public void GetTotalRevenueByService_ShouldReturnCorrectRevenue()
    {
        var result = fixture.Orders
            .GroupBy(order => order.Service)
            .Select(group => new
            {
                Service = group.Key,
                Revenue = group.Sum(order => order.Service.Price)
            })
            .OrderBy(item => item.Service.Id)
            .ToList();

        Assert.Equal(5, result.Count);

        Assert.Equal(
            5600m,
            result.Single(item => item.Service.Id == 1).Revenue);

        Assert.Equal(
            9000m,
            result.Single(item => item.Service.Id == 2).Revenue);

        Assert.Equal(
            12500m,
            result.Single(item => item.Service.Id == 3).Revenue);

        Assert.Equal(
            9000m,
            result.Single(item => item.Service.Id == 4).Revenue);

        Assert.Equal(
            8000m,
            result.Single(item => item.Service.Id == 5).Revenue);
    }
}