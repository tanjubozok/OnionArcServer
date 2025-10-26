using AutoMapper;
using MediatR;
using OnionArc.Application.Conctract.Persistence;
using OnionArc.Application.Features.Categories.Commands;
using OnionArc.Application.Results;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Categories.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, TResult<Guid>>
{
    private readonly IRepository<Category> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TResult<Guid>> Handle(CreateCategoryCommand request, CancellationToken ct)
    {
        var exists = await _repository.GetSingleAsync(x => x.Name == request.Name);
        if (exists is not null)
            return TResult<Guid>.Failure(ErrorType.Conflict, "Category name already exists");

        var category = _mapper.Map<Category>(request);
        await _repository.AddAsync(category);

        try
        {
            var affected = await _unitOfWork.SaveChangesAsync();
            return TResult<Guid>.Success(category.Id);
        }
        catch (Exception ex)
        {
            return TResult<Guid>.Exception(ex.Message);
        }
    }
}
