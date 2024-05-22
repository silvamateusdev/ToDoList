using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories;

public interface IDayRepository 
{
    IEnumerable<DayEntity> GetAll(bool isInclude = false);
    DayEntity GetById(int id);
}