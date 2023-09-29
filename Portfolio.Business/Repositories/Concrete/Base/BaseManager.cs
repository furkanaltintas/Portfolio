using AutoMapper;
using Portfolio.DataAccess.Abstract;

namespace Portfolio.Business.Repositories.Concrete.Base;

public class BaseManager
{
    public BaseManager(IRepository repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    protected IRepository Repository { get; }
    protected IMapper Mapper { get; }
}