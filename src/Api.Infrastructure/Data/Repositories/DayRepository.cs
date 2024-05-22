using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Api.Infrastructure.Data.Repositories;

public class DayRepository : IDayRepository
{
    private readonly SqlContext sqlContext;

    public DayRepository(SqlContext sqlContext)
    {
        this.sqlContext = sqlContext;
    }

    public IEnumerable<DayEntity> GetAll(bool isInclude = false)
    {
        IEnumerable<DayEntity> days;
        try
        {
            if (isInclude)
            {
                days = sqlContext.Set<DayEntity>()
                                .AsNoTracking()
                                .Include(d => d.Tasks)
                                .ToList();
            }
            else
            {
                days = sqlContext.Set<DayEntity>()
                                .AsNoTracking()
                                .ToList();
            }

            return days;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DayEntity GetById(int id)
    {
        try
        {
            var day = sqlContext.Set<DayEntity>()
                                .AsNoTracking()
                                .Include(d => d.Tasks)
                                .FirstOrDefault(x => x.Id == id);

            return day;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}