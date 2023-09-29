using AutoMapper;
using Portfolio.Business.Constants;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete.Error;
using Portfolio.Core.Utilities.Results.Concrete.Success;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Concrete
{
    public class ResumeManager : BaseManager, IResumeService
    {
        public ResumeManager(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IResult> CreateResumeAsync(ResumeCreateDto resumeCreateDto)
        {
            if (resumeCreateDto is null)
                return new ErrorResult();

            var resume = Mapper.Map<Resume>(resumeCreateDto);

            await Repository.GetRepository<Resume>().AddAsync(resume);
            await Repository.SaveAsync();
            return new SuccessResult(Messages<Resume>.GenericMessage.TAdded);
        }

        public async Task<IResult> DeleteResumeAsync(int id)
        {
            var resume = await Repository.GetRepository<Resume>().GetAsync(s => s.Id.Equals(id));

            if (resume is null)
                return new ErrorResult();

            Repository.GetRepository<Resume>().Delete(resume);
            await Repository.SaveAsync();
            return new SuccessResult(Messages<Resume>.GenericMessage.TDeleted);
        }

        public async Task<IDataResult<List<ResumeGetAllDto>>> GetAllActiveResumeAsync()
        {
            var resumes = await Repository.GetRepository<Resume>().GetAllAsync(r => r.IsActive);

            if (resumes.Count is 0)
                return new ErrorDataResult<List<ResumeGetAllDto>>();

            var resumeGetAllDtos = Mapper.Map<List<ResumeGetAllDto>>(resumes);
            return new SuccessDataResult<List<ResumeGetAllDto>>(resumeGetAllDtos);
        }

        public async Task<IDataResult<List<ResumeGetAllDto>>> GetAllResumeAsync()
        {
            var resumes = await Repository.GetRepository<Resume>().GetAllAsync();

            if (resumes.Count is 0)
                return new ErrorDataResult<List<ResumeGetAllDto>>();

            var resumeGetAllDtos = Mapper.Map<List<ResumeGetAllDto>>(resumes);
            return new SuccessDataResult<List<ResumeGetAllDto>>(resumeGetAllDtos);
        }

        public async Task<IDataResult<ResumeGetDto>> GetResumeByIdAsync(int id)
        {
            var resume = await Repository.GetRepository<Resume>().GetAsync(r => r.Id.Equals(id));

            if (resume is null)
                return new ErrorDataResult<ResumeGetDto>();

            var resumeGetDto = Mapper.Map<ResumeGetDto>(resume);
            return new SuccessDataResult<ResumeGetDto>(resumeGetDto);
        }

        public async Task<IResult> UpdateResumeAsync(ResumeUpdateDto resumeUpdateDto)
        {
            if (resumeUpdateDto == null)
                return new ErrorResult();

            var resume = Mapper.Map<Resume>(resumeUpdateDto);
            await Repository.GetRepository<Resume>().UpdateAsync(resume);
            return new SuccessResult(Messages<Resume>.GenericMessage.TUpdated);
        }
    }
}
