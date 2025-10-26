using MediatR;
using OnionArc.Application.Results;

namespace OnionArc.Application.Features.Categories.Commands;

public record CreateCategoryCommand(string Name) : IRequest<TResult<Guid>>;
