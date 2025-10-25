using MediatR;
using OnionArc.Application.Base;
using OnionArc.Application.Features.Categories.Results;

namespace OnionArc.Application.Features.Categories.Queries;

public class GetCategoryQuery : IRequest<BaseResult<List<GetCategoryQueryResult>>>
{
}