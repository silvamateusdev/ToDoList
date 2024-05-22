using Api.Domain.DTOs;
using Api.Domain.Interfaces.Services;
using Api.Service.Response;
using FluentValidation;
using Microsoft.OpenApi.Models;

namespace Api.Application.EndPoints;

public static class TaskEndPoints
{
    public static void RegisterTaskEndPoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/task", (ITaskService taskService, int? idDay) =>
        {
            try
            {
                var tasks = taskService.GetAll(idDay);
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = true,
                    Message = "Sucesso!",
                    List = tasks
                };
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = false,
                    Message = ex.Message
                };
                return Results.BadRequest(response);
            }
        }).WithOpenApi(x => new OpenApiOperation(x)
        {
            Tags = new List<OpenApiTag> { new() { Name = "Task" } }
        });

        endpoints.MapGet("/task/{id}", (Guid id, ITaskService taskService) =>
        {
            if (id == Guid.Empty)
            {
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = false,
                    Message = "É necessário informar o ID da tarefa!"
                };
                return Results.BadRequest(response);
            }
            try
            {
                var tasks = taskService.Get(id);
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = true,
                    Message = "Sucesso!",
                    Data = tasks
                };
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = false,
                    Message = ex.Message
                };
                return Results.BadRequest(response);
            }
        }).WithOpenApi(x => new OpenApiOperation(x)
        {
            Tags = new List<OpenApiTag> { new() { Name = "Task" } }
        });

        endpoints.MapPost("/task", (TaskCreateDto taskCreateDto, ITaskService taskService) =>
        {
            if (string.IsNullOrEmpty(taskCreateDto.Description) || taskCreateDto.IdDay == null)
            {
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = false,
                    Message = "É necessário informar a descrição da tarefa!"
                };
                return Results.BadRequest(response);
            }
            try
            {
                Guid id = Guid.NewGuid();
                TaskDto taskDto = new TaskDto
                {
                    Id = id,
                    Description = taskCreateDto.Description,
                    IdDay = taskCreateDto.IdDay
                };
                var result = taskService.Post(taskDto);
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = true,
                    Message = "Sucesso!",
                    Data = result
                };
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = false,
                    Message = ex.Message
                };
                return Results.BadRequest(response);
            }
        }).WithOpenApi(x => new OpenApiOperation(x)
        {
            Tags = new List<OpenApiTag> { new() { Name = "Task" } }
        });

        endpoints.MapPut("/task", (TaskDto taskDto, IValidator<TaskDto> validator, ITaskService taskService) =>
        {
            var validation = validator.Validate(taskDto);

            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            try
            {
                var result = taskService.Put(taskDto);
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = true,
                    Message = "Sucesso!",
                    Data = result
                };
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = false,
                    Message = ex.Message
                };
                return Results.BadRequest(response);
            }
        }).WithOpenApi(x => new OpenApiOperation(x)
        {
            Tags = new List<OpenApiTag> { new() { Name = "Task" } }
        });

        endpoints.MapDelete("/task", (Guid id, ITaskService taskService) =>
        {
            if (id == Guid.Empty)
            {
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = false,
                    Message = "É necessário informar o ID da tarefa!"
                };
                return Results.BadRequest(response);
            }
            try
            {
                var result = taskService.Delete(id);
                if (result != null)
                {
                    var response = new ResponseDefault<TaskDto>
                    {
                        IsOk = true,
                        Message = "Sucesso!",
                        Data = result
                    };
                    return Results.Ok(response);
                }
                else
                {
                    var response = new ResponseDefault<TaskDto>
                    {
                        IsOk = false,
                        Message = "Item não encontrado!"
                    };
                    return Results.BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                var response = new ResponseDefault<TaskDto>
                {
                    IsOk = false,
                    Message = ex.Message
                };
                return Results.BadRequest(response);
            }

        }).WithOpenApi(x => new OpenApiOperation(x)
        {
            Tags = new List<OpenApiTag> { new() { Name = "Task" } }
        });

    }
}