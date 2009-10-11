using System;
using System.Linq;
using System.Linq.Expressions;
namespace lunchhunters.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void InsertOnSubmit(T entity);
        void DeleteOnSubmit(T entity);
        [Obsolete("Units of Work should be managed externally to the Repository.")]
        void SubmitChanges();
    }
    public interface IRepository
    {
        IQueryable GetAll();
        void InsertOnSubmit(object entity);
        void DeleteOnSubmit(object entity);
        [Obsolete("Units of Work should be managed externally to the Repository.")]
        void SubmitChanges();
    }
    //public class Repository<T> : IRepository<T>, IRepository where T : class
    //{
    //    readonly DataContext dataContext;
    //    public Repository(IDataContextProvider dataContextProvider)
    //    {
    //        dataContext = dataContextProvider.DataContext;
    //    }
        
    //    public virtual IQueryable<T> GetAll()
    //    {
    //        return dataContext.GetTable<T>();
    //    }
    //    public virtual void InsertOnSubmit(T entity)
    //    {
    //        GetTable().InsertOnSubmit(entity);
    //    }
    //    public virtual void DeleteOnSubmit(T entity)
    //    {
    //        GetTable().DeleteOnSubmit(entity);
    //    }
    //    public virtual void SubmitChanges()
    //    {
    //        dataContext.SubmitChanges();
    //    }
        
    //    IQueryable IRepository.GetAll()
    //    {
    //        return GetAll();
    //    }
    //    void IRepository.InsertOnSubmit(object entity)
    //    {
    //        InsertOnSubmit((T)entity);
    //    }
    //    void IRepository.DeleteOnSubmit(object entity)
    //    {
    //        DeleteOnSubmit((T)entity);
    //    }
        
    //}
}