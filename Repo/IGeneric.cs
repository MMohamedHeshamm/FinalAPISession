namespace FinalAPISession.Repo
{
    public interface IGeneric<T> where T : class
    {
        // Post 
        Task Add(T entity);

        // Get BY ID 
        Task<T?> GetBYID(int id);

        //Get All 
        Task<IEnumerable<T>> GetAll();

        //Delete
        Task<bool> Delete(int id);

        //put 
        Task Update (T entity);
    }
}
