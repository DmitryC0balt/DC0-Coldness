using System.Collections;
using UnityEngine;

namespace Scripts.EntryPoint
{
    public class GameOverEntryPoint : SceneEntryPoint
    {
        [SerializeField] private float _gameOverLabelMinSize;
        [SerializeField] private float _gameOverLabelMaxSize;

        public override void OnSceneEnter()
        {

        }


        public override void OnSceneExit()
        {
            
        }


        private IEnumerator ChangeGameOverLabelSize()
        {
            yield return null;
        }
    }
}