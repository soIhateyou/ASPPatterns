namespace ASPPatterns.Chap2.Service
{
    public class NullObjectCache : ICacheStorage
    {
        public void Remove(string key)
        {
        }

        public void Store(string key, object data)
        {
        }

        public T Retrieve<T>(string key)
        {
            return default(T);
        }
    }
}
