namespace Api.Domain.Validator;

using Api.Domain.DTOs;
using FluentValidation;

public class TaskValidator : AbstractValidator<TaskDto>
{
    public TaskValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("É necessário informar o ID");
        RuleFor(x => x.Description).NotEmpty().WithMessage("É necessário informar a descrição da tarefa");
    }
}