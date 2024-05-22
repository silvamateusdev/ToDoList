using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories;

public interface ITaskRepository
{
    TaskEntity Add(TaskEntity task);
    TaskEntity Update(TaskEntity task);
    TaskEntity GetById(Guid id);
    IEnumerable<TaskEntity> GetAll(int? idDay);
    TaskEntity Delete(Guid id);

}