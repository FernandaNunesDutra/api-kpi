
namespace AppKpi.dependencyservice
{
    public interface IMessageService
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
