using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Web.ViewComponents;

public class LeftSideBarViewComponent : ViewComponent
{
    private readonly IService _service;

    public LeftSideBarViewComponent(IService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userResult = await _service.UserService.GetUserAsync();
        var socialMediaResult = await _service.SocialMediaService.GetAllSocialMediaAsync();


        UserProfileDto userProfileDto = new UserProfileDto
        {
            Address = userResult.Data.Address,
            Degree = userResult.Data.Degree,
            Email = userResult.Data.Email,
            Picture = userResult.Data.Picture,
            SocialMediaGetAllDto = socialMediaResult.Data
        };
        return View(userProfileDto);
    }
}