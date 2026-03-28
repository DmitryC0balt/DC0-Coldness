using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.NPC
{
    public class NpcStateMashine
    {
        private Dictionary<Type, NpcState> _npcStates;
        private NpcState _currentState;


        public NpcStateMashine()
        {
            _npcStates = new Dictionary<Type, NpcState>();
        }


        private void AddState(NpcState state)
        {
            var type = state.GetType();
            _npcStates.Add(type, state);
        }


        private void SetState(NpcState newState)
        {
            if (_currentState == newState)
            {
                return;
            }
            
            _currentState?.OnStateExit();
            _currentState = newState;
            _currentState.OnStateEnter();
        }


        private NpcState GetState<TargetState>()
        {
            var type = typeof(TargetState);

            if (_npcStates.ContainsKey(type))
            {
                return _npcStates[type];
            }

            Debug.Log($"Can't get {type} in NPC's state mashine!");
            return null;
        }


        public void PhysicalProcess()
        {
            _currentState.OnPhysicalProcess();
        }


        public void VisualProcess()
        {
            _currentState.OnVisualProcess();
        }

    }
}