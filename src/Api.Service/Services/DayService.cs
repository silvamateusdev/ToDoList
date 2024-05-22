using Api.Domain.DTOs;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services;

public class DayService : IDayService
{
    private readonly IDayRepository dayRepository;

    public DayService(IDayRepository dayRepository)
    {
        this.dayRepository = dayRepository;
    }

    public IEnumerable<DayDto> GetAll(bool? isInclude = false)
    {
        
        IEnumerable<DayDto> dayDtos= dayRepository.GetAll((bool)isInclude).Select(day => (DayDto)day);
        return dayDtos;
    }

    public DayDto GetById(int id)
    {
        var dayDto = (DayDto)dayRepository.GetById(id);
        return dayDto;
    }
}