using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.EntryPoint;
using Scripts.SceneStates;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Master
{
    public class SceneMaster
    {
        private Dictionary<Type, SceneState> _sceneStatesDictionary;
        private SceneState _currentState;
        private GameMaster _gameMaster;
        private const float _persistanceProgressValue = 0.9f;


        public bool IsPauseOpen{ get; private set;}
        public bool IsRecordsOpen{ get; private set;}
        public bool IsInventoryOpen{ get; private set;}
        public bool IsConversationOpen{ get; private set;}


        public SceneMaster(GameMaster gameMaster)
        {
            _gameMaster = gameMaster;
            _sceneStatesDictionary = new Dictionary<Type, SceneState>
            {
                { typeof(MenuState), new MenuState(false) },
                { typeof(GameState), new GameState(true) }
            };            
        }


        private void SwitchState<TargetState>() where TargetState : SceneState
        {
            _gameMaster.StartCoroutine(LoadScene<TargetState>());
        }


        private IEnumerator LoadScene<TargetState>() where TargetState : SceneState
        {
            SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
            yield return null;

            _currentState?.OnStateExit();
    
            var loadingSceneEntryPoint = UnityEngine.Object.FindFirstObjectByType<LoadingSceneEntryPoint>();

            if (loadingSceneEntryPoint != null)
            {
                loadingSceneEntryPoint.ShowLoadingBar(true);
                loadingSceneEntryPoint.SetLoadingBarValue(0);

                var type = typeof(TargetState);

                _currentState = _sceneStatesDictionary[type];
                AsyncOperation asyncSceneLoad = _currentState.OnStateEnter();
                asyncSceneLoad.allowSceneActivation = false;

                while (!asyncSceneLoad.isDone)
                {
                    var progressValue = Mathf.Clamp01(asyncSceneLoad.progress / _persistanceProgressValue);
                    loadingSceneEntryPoint.SetLoadingBarValue(progressValue);


                    if (asyncSceneLoad.progress >= _persistanceProgressValue)
                    {
                        yield return new WaitForSeconds(0.5f);
                        loadingSceneEntryPoint.ShowLoadingBar(false);
                        asyncSceneLoad.allowSceneActivation = true;
                    }

                    yield return null;
                }

            }

            SceneManager.UnloadSceneAsync("Loading");
        }   


        public void SwitchMenuState() => SwitchState<MenuState>();

        public void SwitchGameState() => SwitchState<GameState>();

        public void OpenTargetScene(bool isActive, string targetSceneName)
        {
            if (isActive)
            {
                SceneManager.LoadScene(targetSceneName, LoadSceneMode.Additive);
                return;
            }

            SceneManager.UnloadSceneAsync(targetSceneName);
        }


        public void ShowPause(bool isActive)
        {
            OpenTargetScene(isActive, "Pause");
            IsPauseOpen = isActive;
        }


        public void ShowRecords(bool isActive)
        {
            OpenTargetScene(isActive, "Records");
            IsRecordsOpen = isActive;
        }


        public void ShowInventory(bool isActive)
        {
            OpenTargetScene(isActive, "Inventory");
            IsInventoryOpen = isActive;
        }


        public void ShowConversation(bool isActive)
        {
            OpenTargetScene(isActive, "Conversation");
            IsConversationOpen = isActive;
        }


        public void CloseUiScenes()
        {
            if (IsPauseOpen)
            {
                ShowPause(false);
            }

            if (IsRecordsOpen)
            {
                ShowRecords(false);
            }

            if (IsInventoryOpen)
            {
                ShowInventory(false);
            }

            if (IsConversationOpen)
            {
                ShowConversation(false);
            }
        }

    }
}