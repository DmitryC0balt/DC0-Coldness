using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GUI
{
    public class GuiScreenContainer : IDisposable
    {
        private Dictionary<Type, GuiScreen> _guiScreenDictionary;
        private bool _isInitialized = false;



        public GuiScreenContainer() => _guiScreenDictionary = new Dictionary<Type, GuiScreen>();

        public void Initialization() => _isInitialized = true;


        public void AddScreen(GuiScreen screen)
        {
            if (_isInitialized)
            {
                Debug.Log($"GUI Container is already initialized, can't add {nameof(screen)}!");
                return;
            }

            var type = screen.GetType();

            if (_guiScreenDictionary.ContainsKey(type))
            {
                Debug.Log($"Can't add {nameof(screen)}, this element is already added in GUI container!");
                return;
            }

            _guiScreenDictionary.Add(type, screen);
        }


        public void Dispose()
        {
            _guiScreenDictionary.Clear();
            _guiScreenDictionary = null;
        }


        public void ShowScreen<TargetScreen>(bool hideAll) where TargetScreen : GuiScreen
        {
            if (hideAll)
            {
                HideAllScreens();
            }

            if (_guiScreenDictionary.TryGetValue(typeof(TargetScreen), out var screen))
            {
                screen.Show();
                return;
            }

            Debug.Log($"Can't find {typeof(TargetScreen)} for show!");
        }


        private void HideAllScreens()
        {
            foreach (var screen in _guiScreenDictionary)
            {
                screen.Value.Hide();
            }
        }
    }
}