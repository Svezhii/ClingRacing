using UnityEngine;

namespace Infrastructure.AssetManagment
{
    public class AssetsProvider : IAssets
    {
        public GameObject Instatiate(string path, Transform at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at.position, at.rotation);
        }

        public GameObject Instatiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}