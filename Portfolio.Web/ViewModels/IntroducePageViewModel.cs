using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Web.ViewModels;

public class IntroducePageViewModel
{
    public IDataResult<IntroduceGetDto> Result { get; set; } = null!;
    public short GitHubRepoCount { get; set; }
    public bool IsProjectActive { get; set; } // Proje aktif mi
}