using MediatR;
using OnionArc.Application.Features.Categories.Results;
using OnionArc.Application.Results;

namespace OnionArc.Application.Features.Categories.Queries;

public class GetCategoryQuery : IRequest<TResult<List<GetCategoryQueryResult>>>
{
}