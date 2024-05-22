
using Api.Domain.Entities;

namespace Api.Domain.DTOs;

public class DayDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<TaskDto>? Tasks { get; set; }

    public static explicit operator DayDto(DayEntity day)
    {
        if(day == null)
            return null;

        return new DayDto
        {
            Id = day.Id,
            Name = day?.Name,
            Tasks = day?.Tasks?.Select(task => (TaskDto)task).ToList()
        };
    }
}