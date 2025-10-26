using AutoMapper;
using MediatR;
using OnionArc.Application.Conctract.Persistence;
using OnionArc.Application.Features.Categories.Queries;
using OnionArc.Application.Features.Categories.Results;
using OnionArc.Application.Results;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Categories.Handlers;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, TResult<List<GetCategoryQueryResult>>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TResult<List<GetCategoryQueryResult>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync();
        if (categories == null || categories.Count == 0)
        {
            return TResult<List<GetCategoryQueryResult>>.Failure(ErrorType.NotFound, "Kategori bulunamadı");
        }

        var result = _mapper.Map<List<GetCategoryQueryResult>>(categories);

        return TResult<List<GetCategoryQueryResult>>.Success(result);
    }
}