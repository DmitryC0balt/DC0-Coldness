using System.Collections;
using UnityEngine;

namespace Scripts.EntryPoint
{
    public class SplashEntryPoint : SceneEntryPoint
    {
        public override void OnSceneEnter()
        {
            StartCoroutine(CloseSplashScene());
        }

        public override void OnSceneExit()
        {
           
        }


        public IEnumerator CloseSplashScene()
        {
            yield return new WaitForSeconds(2);
            _instance.HideSplashScene();
        }
    }
}

