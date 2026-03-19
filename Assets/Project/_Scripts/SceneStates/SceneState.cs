using System.Collections;
using UnityEngine;

namespace Scripts.SceneStates
{
    public abstract class SceneState
    {
        public bool needAccept{ get; private set;}
        public SceneState(bool needSceneAccept) => needAccept = needSceneAccept;
        public abstract AsyncOperation OnStateEnter();
        public abstract void OnStateExit();
    }
}