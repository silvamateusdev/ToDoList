using Api.Domain.DTOs;

namespace Api.Domain.Entities;

public class DayEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<TaskEntity>? Tasks { get; set; }

    public static explicit operator DayEntity(DayDto day)
    {
        if(day == null)
            return null;

        return new DayEntity
        {
            Id = day.Id,
            Name = day?.Name,
            Tasks = day?.Tasks?.Select(task => (TaskEntity)task).ToList()
        };
    }
}