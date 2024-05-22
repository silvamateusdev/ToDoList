namespace Api.Infrastructure.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Entities;

public class TaskRepository : ITaskRepository
{
    private readonly SqlContext sqlContext;

    public TaskRepository(SqlContext sqlContext)
    {
        this.sqlContext = sqlContext;
    }

    public TaskEntity Add(TaskEntity task)
    {
        try
        {
            sqlContext.Set<TaskEntity>().Add(task);
            sqlContext.SaveChanges();
            return task;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public TaskEntity Delete(Guid id)
    {
        var tasks = GetById(id);

        if(tasks != null)
        {
            sqlContext.Set<TaskEntity>().Remove(tasks);
            sqlContext.SaveChanges();
        }          

        return tasks;
    }

    public IEnumerable<TaskEntity> GetAll(int? idDay)
    {
        try
        {
            if(idDay == null)
                return sqlContext.Set<TaskEntity>().AsNoTracking().ToList();
            else    
                return sqlContext.Set<TaskEntity>().AsNoTracking().Where(d => d.IdDay == idDay).ToList();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public TaskEntity GetById(Guid id)
    {
        try
        {
            return sqlContext.Set<TaskEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public TaskEntity Update(TaskEntity task)
    {
        try
        {
            sqlContext.Set<TaskEntity>().Update(task);
            sqlContext.SaveChanges();
            return task;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}