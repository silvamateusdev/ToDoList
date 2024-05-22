using System.Text.Json.Serialization;
using Api.Domain.Entities;

namespace Api.Domain.DTOs;

public class TaskDto
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public int IdDay { get; set; }
    [JsonIgnore]
    public DayDto? Day{ get; set; }

    public static explicit operator TaskDto(TaskEntity task)
    {
        if(task == null)
            return null;
            
        return new TaskDto
        {
            Id = task.Id,
            Description = task.Description,
            IdDay = task.IdDay
        };
    }
}
