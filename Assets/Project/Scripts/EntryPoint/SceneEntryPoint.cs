using UnityEngine;


namespace Scripts.EntryPoint
{
    public abstract class SceneEntryPoint : MonoBehaviour
    {
        protected GameEntryPoint _instance;

        private void Awake()
        {
            _instance = GameEntryPoint.GetInstance();
            OnSceneEnter();
        }


        private void OnDisable()
        {
            OnSceneExit();
        }

        public abstract void OnSceneEnter();
        public abstract void OnSceneExit();


        protected virtual void OnSceneSetup() {}


        protected virtual void OnInitialization() {}
        protected virtual void OnProcess() {}
        protected virtual void OnFixedProcess() {}
        protected virtual void OnPostProcess() {}
    }
}