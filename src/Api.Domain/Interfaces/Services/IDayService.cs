using Api.Domain.DTOs;

namespace Api.Domain.Interfaces.Services;

public interface IDayService
{
    IEnumerable<DayDto> GetAll(bool? isInclude = false);
    DayDto GetById(int id);
}