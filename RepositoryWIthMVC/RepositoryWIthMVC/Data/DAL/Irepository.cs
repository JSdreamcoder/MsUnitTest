namespace RepositoryWIthMVC.Data
{
    public interface IRepository<T> where T : class
    {
        //Create
        void Add(T entity);
        //Read
        T Get(int id);
        T Get(Func<T, bool> firstFuction);
        ICollection<T> GetAll();
        ICollection<T> GetList(Func<T,bool> whereFuction);

        //Update
        void Update(T entity);
        //Delete
        void Delete(T entity);

        void Save();
    }
}
