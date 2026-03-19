using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.MonoCash.Tier1
{
    public class MonoCashObserver : IDisposable
    {
        private bool _isInitialized;

        private List<MonoCashListener> _listenersList;

        
        public MonoCashObserver(uint capacity = 10)
        {
            _listenersList = new List<MonoCashListener>((int)capacity);
        }


        public void Dispose()
        {
            _listenersList.Clear();
            _listenersList = null;
        }


        public void AddListener(MonoCashListener listener)
        {
            if (_isInitialized)
            {
                Debug.Log($"Can't add listener {nameof(listener)} after initialization!");
                return;
            }


            _listenersList.Add(listener);
        }


        public void OnInitialization()
        {
            _isInitialized = true;
            //Новые добавления после инициалзиации запрещены

            foreach (var listener in _listenersList)
            {
                listener.OnInitialization();
            }
        }


        public void OnProcess()
        {
            foreach (var listener in _listenersList)
            {
                listener.OnProcess();
            }
        }


        public void OnFixedProcess()
        {
            foreach (var listener in _listenersList)
            {
                listener.OnFixedProcess();
            }
        }


        public void OnPostProcess()
        {
            foreach (var listener in _listenersList)
            {
                listener.OnPostProcess();
            }
        }
    }
}