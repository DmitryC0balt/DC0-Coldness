using UnityEngine;

namespace Scripts.SceneStates
{
    public abstract class SceneState
    {
        public abstract void OnStateEnter();
        public abstract void OnStateExit();
    }
}