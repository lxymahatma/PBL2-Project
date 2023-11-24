using UnityEngine;

namespace Scripts
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
                return;
            }

            Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {
            Instance = default;
        }

        public void DestroySingleton()
        {
            Instance = default;
            Destroy(gameObject);
        }
    }
}