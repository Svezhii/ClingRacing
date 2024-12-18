using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.AssetManagment
{
    public interface IAssets : IService
    {
        GameObject Instatiate(string path, Transform at);
        GameObject Instatiate(string path);
    }
}