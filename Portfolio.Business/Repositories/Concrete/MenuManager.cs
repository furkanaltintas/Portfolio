using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Business.Constants;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Core.Aspects.Autofac.Caching;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete.Error;
using Portfolio.Core.Utilities.Results.Concrete.Success;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Concrete;

public class MenuManager : BaseManager, IMenuService
{
    public MenuManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    [CacheAspect]
    public async Task<IDataResult<List<MenuGetAllDto>>> GetAllByIsActiveMenuAsync()
    {
        var menus = await Repository
            .GetRepository<Menu>()
            .Query()
            .Where(m => m.IsActive)
            .Include(m => m.MenuHeaders)
            .OrderBy(m => m.Queue)
            .ToListAsync();

        //var menus = await Repository
        //    .GetRepository<Menu>()
        //    .GetAll(m => m.IsActive, m => m.MenuHeaders)
        //    .OrderBy(m => m.Queue)
        //    .ToListAsync();

        if (!menus.Any())
            return new ErrorDataResult<List<MenuGetAllDto>>();

        var menuGetAllDtos = Mapper.Map<List<MenuGetAllDto>>(menus);
        return new SuccessDataResult<List<MenuGetAllDto>>(menuGetAllDtos);
    }

    [CacheAspect]
    public async Task<IDataResult<List<MenuGetAllDto>>> GetAllMenuAsync()
    {
        var menus = await Repository
            .GetRepository<Menu>()
            .Query()
            .OrderBy(m => m.Queue)
            .ToListAsync();

        //.GetRepository<Menu>()
        //.GetAllAsync()
        //.OrderBy(m => m.Queue)
        //.ToListAsync();

        if (!menus.Any())
            return new ErrorDataResult<List<MenuGetAllDto>>();

        var menuGetAllDtos = Mapper.Map<List<MenuGetAllDto>>(menus);
        return new SuccessDataResult<List<MenuGetAllDto>>(menuGetAllDtos);
    }

    [CacheAspect]
    public async Task<IDataResult<MenuGetDto>> GetMenuAsync(string menuName)
    {
        if (string.IsNullOrEmpty(menuName))
            return new ErrorDataResult<MenuGetDto>();

        var menu = await Repository
            .GetRepository<Menu>()
            .GetAsync(m => m.ComponentName.Equals(menuName), includeProperties: m => m.MenuHeaders);

        if (menu is null)
            return new ErrorDataResult<MenuGetDto>();

        var menuGetDto = Mapper.Map<MenuGetDto>(menu);
        return new SuccessDataResult<MenuGetDto>(menuGetDto);
    }

    [CacheAspect]
    public async Task<IDataResult<T>> GetMenuByIdTypeEntity<T>(int id)
    {
        var menu = await Repository.GetRepository<Menu>().GetAsync(m => m.Id.Equals(id));

        if (menu is null)
            return new ErrorDataResult<T>();

        var tEntity = Mapper.Map<T>(menu);
        return new SuccessDataResult<T>(tEntity);
    }

    [CacheAspect]
    public async Task<List<string>> GetMenuQueueAsync()
    {
        var queues = await Repository
            .GetRepository<Menu>()
            .Query()
            .Select(m => m.Queue.ToString()).ToListAsync();
        return queues;
    }



    [CacheRemoveAspect("IMenuService.Get")]
    public async Task<IResult> MenuCreateAsync(MenuCreateDto menuCreateDto)
    {
        if (menuCreateDto is null)
            return new ErrorResult();

        var menuCount = await Repository.GetRepository<Menu>().CountAsync();
        menuCreateDto.Queue = Convert.ToInt16(menuCount + 1);
        var menu = Mapper.Map<Menu>(menuCreateDto);

        await Repository.GetRepository<Menu>().AddAsync(menu);
        await Repository.SaveAsync();

        return new SuccessResult(Messages<Menu>.GenericMessage.TAdded);
    }

    public async Task<IResult> MenuDeleteAsync(int id)
    {
        var menu = await Repository.GetRepository<Menu>().GetAsync(a => a.Id.Equals(id), true);

        if (menu is null)
            return new ErrorResult($"");

        menu.IsDeleted = true;
        menu.IsActive = false;
        // await Repository.GetRepository<Menu>().UpdateAsync(menu);
        await Repository.SaveAsync();
        return new SuccessResult(Messages<Menu>.GenericMessage.TDeleted);
    }

    public async Task<IResult> MenuUnDeleteAsync(int id)
    {
        var menu = await Repository.GetRepository<Menu>().GetAsync(a => a.Id.Equals(id), true);

        if (menu is null)
            return new ErrorResult($"");

        menu.IsDeleted = false;
        menu.IsActive = true;
        // await Repository.GetRepository<Menu>().UpdateAsync(menu);
        await Repository.SaveAsync();
        return new SuccessResult(Messages<Menu>.GenericMessage.TDeleted);
    }

    public async Task<IResult> MenuUpdateAsync(MenuUpdateDto menuUpdateDto)
    {
        if (menuUpdateDto is null)
            return new ErrorResult();

        var queuqOwnerMenu = await Repository.GetRepository<Menu>().GetAsync(m => m.Queue.Equals(menuUpdateDto.Queue));
        // Sıralama takası için sıralama sahibini çekiyoruz

        if (queuqOwnerMenu is null)
            return new ErrorResult();

        queuqOwnerMenu.Queue = menuUpdateDto.OldQueue; // Eski sıralamayı takas ile veriyoruz

        var newMenu = Mapper.Map<Menu>(menuUpdateDto);

        Repository.GetRepository<Menu>().UpdateRange(
            new List<Menu> { queuqOwnerMenu, newMenu });
        await Repository.SaveAsync();

        return new SuccessResult(Messages<Menu>.GenericMessage.TUpdated);
    }
}