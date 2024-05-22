using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Api.Infrastructure.Data;

public class SqlContext : DbContext
{

    public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

    public DbSet<TaskEntity> Tasks{ get; set; }
    public DbSet<DayEntity> Days{ get; set; }

}