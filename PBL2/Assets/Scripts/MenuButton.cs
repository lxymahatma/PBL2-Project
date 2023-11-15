using UnityEngine;

namespace Scripts
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField]
        private LoadType loadType;

        public void OnClick() => SceneManagerExt.LoadMainScene(loadType);
    }
}