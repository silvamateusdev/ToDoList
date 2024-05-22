using Api.Domain.DTOs;
using Api.Domain.Interfaces.Services;
using Api.Service.Response;
using Microsoft.OpenApi.Models;

namespace Api.Application.EndPoints;

public static class DayEndPoints
{
    public static void RegisterDayEndPoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/day", (IDayService dayService, bool? isInclude = false) =>
        {
            try
            {
                var days = dayService.GetAll(isInclude);
                var response = new ResponseDefault<DayDto>
                {
                    IsOk = true,
                    Message = "Sucesso!",
                    List = days
                };
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDefault<DayDto>
                {
                    IsOk = false,
                    Message = ex.Message
                };
                return Results.BadRequest(response);
            }
        }).WithOpenApi(x => new OpenApiOperation(x)
        {
            Tags = new List<OpenApiTag> { new() { Name = "Day" } }
        });

        endpoints.MapGet("/day/{id}", (int id, IDayService dayService) =>
        {
            if (id == null)
            {
                var response = new ResponseDefault<DayDto>
                {
                    IsOk = false,
                    Message = "É necessário informar o ID do diua!"
                };
                return Results.BadRequest(response);
            }
            try
            {
                var tasks = dayService.GetById(id);
                var response = new ResponseDefault<DayDto>
                {
                    IsOk = true,
                    Message = "Sucesso!",
                    Data = tasks
                };
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDefault<DayDto>
                {
                    IsOk = false,
                    Message = ex.Message
                };
                return Results.BadRequest(response);
            }
        }).WithOpenApi(x => new OpenApiOperation(x)
        {
            Tags = new List<OpenApiTag> { new() { Name = "Day" } }
        });
    }
}