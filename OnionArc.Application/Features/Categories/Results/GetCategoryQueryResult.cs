using OnionArc.Application.Base;

namespace OnionArc.Application.Features.Categories.Results;

public class GetCategoryQueryResult : BaseDto
{
    public string Name { get; set; }

    //public List<GetBlogQueryResult> Blogs { get; set; }
}