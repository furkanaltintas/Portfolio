using AutoMapper;
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

public class ContactManager : BaseManager, IContactService
{
    public ContactManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    [CacheRemoveAspect("IContactService.Get")]
    public async Task<IResult> CreateContactAsync(ContactCreateDto contactCreateDto)
    {
        if (contactCreateDto is null)
            return new ErrorResult();

        var contact = Mapper.Map<Contact>(contactCreateDto);
        await Repository.GetRepository<Contact>().AddAsync(contact);
        await Repository.SaveAsync();

        return new SuccessResult(Messages<Contact>.GenericMessage.TAdded);
    }

    public async Task<IResult> DeleteContactAsync(int id)
    {
        var contact = await Repository.GetRepository<Contact>().GetAsync(c => c.Id.Equals(id));

        if (contact is null)
            return new ErrorResult($"");

        Repository.GetRepository<Contact>().Delete(contact);
        await Repository.SaveAsync();
        return new SuccessResult(Messages<Contact>.GenericMessage.TDeleted);
    }

    [CacheAspect]
    public async Task<IDataResult<List<ContactGetAllDto>>> GetAllContactAsync()
    {
        var contacts = await Repository
            .GetRepository<Contact>()
            .GetAllAsync();

        //var contacts = await Repository
        //    .GetRepository<Contact>()
        //    .GetAll()
        //    .ToListAsync();


        if (contacts.Count is 0)
            return new ErrorDataResult<List<ContactGetAllDto>>($"Mesaj bulunmamaktadır");


        var contactGetAllDtos = Mapper.Map<List<ContactGetAllDto>>(contacts);
        return new SuccessDataResult<List<ContactGetAllDto>>(contactGetAllDtos);
    }

    public async Task<bool> HasContactAsync()
    {
        var menu = await Repository
            .GetRepository<Menu>()
            .GetAsync(c => c.ComponentName.ToLower().Equals("Contact"));


        return menu.IsActive;
    }
}