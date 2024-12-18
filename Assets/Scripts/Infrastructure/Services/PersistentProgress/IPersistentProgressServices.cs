using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressServices : IService
    {
        PlayerProgress Progress { get; set; }
    }
}