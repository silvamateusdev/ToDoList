using System.ComponentModel.DataAnnotations.Schema;
using Api.Domain.DTOs;

namespace Api.Domain.Entities;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public int IdDay { get; set; }

    [ForeignKey("IdDay")]
    public DayEntity? Day{ get; set; }

    public static explicit operator TaskEntity(TaskDto task)
    {
         if(task == null)
            return null;
            
        return new TaskEntity
        {
            Id = task.Id,
            Description = task.Description,
            IdDay = task.IdDay
        };
    }
}