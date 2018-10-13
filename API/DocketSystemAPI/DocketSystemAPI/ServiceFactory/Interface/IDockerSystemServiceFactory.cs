namespace DocketSystemAPI.ServiceFactory
{
    public interface IDockerSystemServiceFactory
    {
        T GetClient<T>();
    }
}