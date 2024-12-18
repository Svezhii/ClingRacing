using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public class PersistentProgressServices : IPersistentProgressServices
    {
        public PlayerProgress Progress { get; set; }
    }
}