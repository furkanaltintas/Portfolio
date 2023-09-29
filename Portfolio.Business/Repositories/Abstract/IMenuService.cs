using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface IMenuService
{
    Task<IDataResult<List<MenuGetAllDto>>> GetAllByIsActiveMenuAsync();
    Task<IDataResult<List<MenuGetAllDto>>> GetAllMenuAsync();
    Task<IDataResult<MenuGetDto>> GetMenuAsync(string menuName);
    Task<IDataResult<T>> GetMenuByIdTypeEntity<T>(int id);


    Task<IResult> MenuCreateAsync(MenuCreateDto menuCreateDto);
    Task<IResult> MenuUpdateAsync(MenuUpdateDto menuUpdateDto);
    Task<List<string>> MenuQueueAsync();



    Task<IResult> MenuDeleteAsync(int id);
    Task<IResult> MenuUnDeleteAsync(int id);
}