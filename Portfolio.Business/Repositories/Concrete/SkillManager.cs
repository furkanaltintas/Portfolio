using AutoMapper;
using Portfolio.Business.Constants;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Business.ValidationRules.FluentValidation.DtoValidators;
using Portfolio.Core.Aspects.Autofac.Caching;
using Portfolio.Core.Aspects.Autofac.Validation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete.Error;
using Portfolio.Core.Utilities.Results.Concrete.Success;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Concrete;

public class SkillManager : BaseManager, ISkillService
{
    public SkillManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    [ValidationAspect(typeof(SkillCreateDtoValidator))]
    [CacheRemoveAspect($"{nameof(ISkillService)}.Get")]
    public async Task<IResult> CreateSkillAsync(SkillCreateDto skillCreateDto)
    {
        var skill = Mapper.Map<Skill>(skillCreateDto);

        await Repository.GetRepository<Skill>().AddAsync(skill);
        await Repository.SaveAsync();
        return new SuccessResult(Messages<Skill>.GenericMessage.TAdded);
    }

    public async Task<IResult> DeleteSkillAsync(int id)
    {
        var skill = await Repository.GetRepository<Skill>().GetAsync(s => s.Id.Equals(id));

        if (skill is null)
            return new ErrorResult();

        Repository.GetRepository<Skill>().Delete(skill);
        await Repository.SaveAsync();
        return new SuccessResult(Messages<Skill>.GenericMessage.TDeleted);
    }

    // Ön yüz tarafı için yazıldı
    [CacheAspect]
    public async Task<IDataResult<List<SkillGetAllDto>>> GetAllActiveSkillAsync()
    {
        var skills = await Repository.GetRepository<Skill>().GetAllAsync(s => s.IsActive);

        if (skills.Count is 0)
            return new ErrorDataResult<List<SkillGetAllDto>>();

        var skillGetAllDtos = Mapper.Map<List<SkillGetAllDto>>(skills);
        return new SuccessDataResult<List<SkillGetAllDto>>(skillGetAllDtos);
    }

    // Admin tarafı için yazıldı
    [CacheAspect]
    public async Task<IDataResult<List<SkillGetAllDto>>> GetAllSkillAsync()
    {
        var skills = await Repository.GetRepository<Skill>().GetAllAsync();

        if (skills.Count is 0)
            return new ErrorDataResult<List<SkillGetAllDto>>();

        var skillGetAllDtos = Mapper.Map<List<SkillGetAllDto>>(skills);
        return new SuccessDataResult<List<SkillGetAllDto>>(skillGetAllDtos);
    }

    // Admin tarafı için yazıldı
    [CacheAspect]
    public async Task<IDataResult<SkillGetDto>> GetSkillByIdAsync(int id)
    {
        var skill = await Repository.GetRepository<Skill>().GetAsync(s => s.Id.Equals(id));

        if (skill is null)
            return new ErrorDataResult<SkillGetDto>();

        var skillGetDto = Mapper.Map<SkillGetDto>(skill);
        return new SuccessDataResult<SkillGetDto>(skillGetDto);
    }

    public async Task<IResult> UpdateSkillAsync(SkillUpdateDto skillUpdateDto)
    {
        if (skillUpdateDto == null)
            return new ErrorResult();

        var skill = Mapper.Map<Skill>(skillUpdateDto);
        await Repository.GetRepository<Skill>().UpdateAsync(skill);
        return new SuccessResult(Messages<Skill>.GenericMessage.TUpdated);
    }
}