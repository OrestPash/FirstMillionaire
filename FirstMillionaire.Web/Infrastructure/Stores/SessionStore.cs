using System.Web;

namespace FirstMillionaire.Web.Infrastructure.Stores
{
    public class SessionStore : ISessionStore
    {       
        public T Get<T>(string key)
        {
            return (T) HttpContext.Current.Session[key];
        }

        public void Set<T>(string key, T value)
        {
            HttpContext.Current.Session[key] = value;
        }
    }
}