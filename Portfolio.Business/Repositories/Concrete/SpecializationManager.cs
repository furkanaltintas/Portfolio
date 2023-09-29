using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Business.Constants;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete.Error;
using Portfolio.Core.Utilities.Results.Concrete.Success;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Concrete;

public class SpecializationManager : BaseManager, ISpecializationService
{
    public SpecializationManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IResult> CreateSpecializationAsync(SpecializationCreateDto serviceCreateDto)
    {
        if (serviceCreateDto is null)
            return new ErrorResult();

        var service = Mapper.Map<Specialization>(serviceCreateDto);
        await Repository.GetRepository<Specialization>().AddAsync(service);
        await Repository.SaveAsync();

        return new SuccessResult(Messages<Specialization>.GenericMessage.TAdded);
    }

    public async Task<IResult> DeleteSpecializationAsync(int id)
    {
        var service = await Repository
            .GetRepository<Specialization>()
            .GetAsync(s => s.Id.Equals(id));

        if (service is null)
            return new ErrorResult();

        Repository.GetRepository<Specialization>().Delete(service);
        await Repository.SaveAsync();
        return new SuccessResult(Messages<Specialization>.GenericMessage.TDeleted);
    }

    public async Task<IDataResult<List<SpecializationGetAllDto>>> GetAllActiveSpecializationAsync()
    {
        var services = await Repository
            .GetRepository<Specialization>()
            .Query()
            .Where(s => s.IsActive)
            .ToListAsync();

        //var services = await Repository
        //    .GetRepository<Specialization>()
        //    .GetAll(s => s.IsActive)
        //    .ToListAsync();

        if (services.Count is 0)
            return new ErrorDataResult<List<SpecializationGetAllDto>>();

        var serviceGetAllDtos = Mapper.Map<List<SpecializationGetAllDto>>(services);
        return new SuccessDataResult<List<SpecializationGetAllDto>>(serviceGetAllDtos);
    }

    public async Task<IDataResult<List<SpecializationGetAllDto>>> GetAllSpecializationAsync()
    {
        var services = await Repository
            .GetRepository<Specialization>()
            .GetAllAsync();

        if (services.Count is 0)
            return new ErrorDataResult<List<SpecializationGetAllDto>>();

        var serviceGetAllDtos = Mapper.Map<List<SpecializationGetAllDto>>(services);
        return new SuccessDataResult<List<SpecializationGetAllDto>>(serviceGetAllDtos);
    }

    public async Task<IResult> UpdateSpecializationAsync(SpecializationUpdateDto serviceUpdateDto)
    {
        if (serviceUpdateDto == null)
            return new ErrorResult();

        var service = Mapper.Map<Specialization>(serviceUpdateDto);
        await Repository.GetRepository<Specialization>().UpdateAsync(service);
        return new SuccessResult(Messages<Specialization>.GenericMessage.TUpdated);
    }
}