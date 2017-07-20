namespace FirstMillionaire.Web.Infrastructure.Stores
{
    public interface ISessionStore
    {
        T Get<T>(string key);

        void Set<T>(string key, T value);
    }
}