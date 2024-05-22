using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.DTOs;
using Api.Domain.Entities;

namespace Api.Service.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        this.taskRepository = taskRepository;
    }

    public TaskDto Delete(Guid id)
    {
        var taskDtoReturn = (TaskDto) taskRepository.Delete(id);
        return taskDtoReturn;
    }

    public TaskDto Get(Guid id)
    {
        var taskDtoReturn = (TaskDto)taskRepository.GetById(id);        
        return taskDtoReturn;
    }

    public IEnumerable<TaskDto> GetAll(int? idDay)
    {
        IEnumerable<TaskDto> tasksDtoReturn = taskRepository.GetAll(idDay).Select(task => (TaskDto)task);        
        return tasksDtoReturn;            
    }

    public TaskDto Post(TaskDto taskDto)
    {
        var task = (TaskEntity) taskDto;
        var taskDtoReturn = (TaskDto)taskRepository.Add(task);        
        return taskDtoReturn;
    }

    public TaskDto Put(TaskDto taskDto)
    {
        var task = (TaskEntity) taskDto;
        var taskDtoReturn = (TaskDto) taskRepository.Update(task);        
        return taskDtoReturn;
    }
}