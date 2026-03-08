using System;
using System.Collections.Generic;
using Scripts.SceneStates;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Master
{
    public class SceneMaster
    {
        private Dictionary<Type, SceneState> _sceneStatesDictionary;
        private SceneState _currentState;

        public SceneMaster()
        {
            _sceneStatesDictionary = new Dictionary<Type, SceneState>();
            AddState(new MenuState());
            AddState(new GameState());
        }


        private void AddState(SceneState state)
        {
            var type = state.GetType();
            _sceneStatesDictionary.Add(type, state);
        }


        private void SwitchState<TargetState>() where TargetState : SceneState
        {
            _currentState?.OnStateExit();

            var type = typeof(TargetState);

            if (_sceneStatesDictionary.ContainsKey(type))
            {
                _currentState = _sceneStatesDictionary[type];
                _currentState.OnStateEnter();
                return;
            }

            Debug.Log($"Can't get state {type}!");
        }


        public void SwitchMenuState() => SwitchState<MenuState>();

        public void SwitchGameState() => SwitchState<GameState>();

        public void OpenSettingsScene() => SceneManager.LoadScene("Settings",LoadSceneMode.Additive);

        public void CloseSettingsScene() => SceneManager.UnloadSceneAsync("Settings");
    }
}