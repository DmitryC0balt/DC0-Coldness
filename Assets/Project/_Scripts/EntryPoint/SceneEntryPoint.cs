using UnityEngine;


namespace Scripts.EntryPoint
{
    public abstract class SceneEntryPoint : MonoBehaviour
    {
        protected GameEntryPoint _instance;

        private void Start()
        {
            _instance = GameEntryPoint.GetInstance();
            OnSceneEnter();
        }


        private void OnDestroy() => OnSceneExit();


        public abstract void OnSceneEnter();
        public abstract void OnSceneExit();


        protected virtual void OnInitialization() {}
        protected virtual void OnProcess() {}
        protected virtual void OnFixedProcess() {}
        protected virtual void OnPostProcess() {}
    }
}