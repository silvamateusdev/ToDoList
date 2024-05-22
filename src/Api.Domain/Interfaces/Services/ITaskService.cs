
using Api.Domain.DTOs;

namespace Api.Domain.Interfaces.Services;

public interface ITaskService
{
    TaskDto Post(TaskDto taskDto);
    TaskDto Put(TaskDto taskDto);
    TaskDto Get(Guid id);
    IEnumerable<TaskDto> GetAll(int? idDay);
    TaskDto Delete(Guid id);

}