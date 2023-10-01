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

public class TestimonialManager : BaseManager, ITestimonialService
{
    public TestimonialManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    [CacheRemoveAspect("ITestimonialService.Get")]
    public async Task<IResult> DeleteTestimonialAsync(int id)
    {
        var testimonial = await Repository.GetRepository<Testimonial>().GetAsync(t => t.Id.Equals(id));

        if (testimonial is null)
            return new ErrorResult();

        Repository.GetRepository<Testimonial>().Delete(testimonial);
        await Repository.SaveAsync();
        return new SuccessResult(Messages<Testimonial>.GenericMessage.TDeleted);
    }

    // Ön yüz tarafı için yazıldı
    [CacheAspect]
    public async Task<IDataResult<List<TestimonialGetAllDto>>> GetAllActiveTestimonialAsync()
    {
        var testimonials = await Repository.GetRepository<Testimonial>().GetAllAsync(s => s.IsActive);

        if (testimonials.Count is 0)
            return new ErrorDataResult<List<TestimonialGetAllDto>>();

        var testimonialGetAllDtos = Mapper.Map<List<TestimonialGetAllDto>>(testimonials);
        return new SuccessDataResult<List<TestimonialGetAllDto>>(testimonialGetAllDtos);
    }

    // Admin tarafı için yazıldı
    [CacheAspect]
    public async Task<IDataResult<List<TestimonialGetAllDto>>> GetAllTestimonialAsync()
    {
        var testimonials = await Repository.GetRepository<Testimonial>().GetAllAsync();

        if (testimonials.Count is 0)
            return new ErrorDataResult<List<TestimonialGetAllDto>>($"Referans bulunmamaktadır.");

        var testimonialGetAllDtos = Mapper.Map<List<TestimonialGetAllDto>>(testimonials);
        return new SuccessDataResult<List<TestimonialGetAllDto>>(testimonialGetAllDtos);
    }
}
