using Carwash.Application.Contracts;
using Carwash.Application.Contracts.Cars;
using Carwash.Domain;
using Carwash.Domain.Entities;

namespace Carwash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над автомобилями
/// </summary>
/// <param name="carRepository">Репозиторий автомобилей</param>
public class CarService(IRepository<Car, int> carRepository) : IApplicationService<CarDto, CarCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<CarDto> Create(CarCreateUpdateDto dto)
    {
        var car = Mapper.Map(dto);

        var result = await carRepository.Create(car);

        return Mapper.Map(result);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int id) => await carRepository.Delete(id);

    /// <inheritdoc/>
    public async Task<CarDto?> Read(int id)
    {
        var car = await carRepository.Read(id);

        if (car == null)
            return null;

        return Mapper.Map(car);
    }

    /// <inheritdoc/>
    public async Task<IList<CarDto>> ReadAll() => Mapper.Map(await carRepository.ReadAll());

    /// <inheritdoc/>
    public async Task<CarDto> Update(CarCreateUpdateDto dto, int id)
    {
        var car = Mapper.Map(dto);
        car.Id = id;

        var result = await carRepository.Update(car);

        return Mapper.Map(result);
    }
}
