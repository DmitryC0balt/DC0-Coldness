using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.ScriptableObjects;


namespace Scripts.Inventory
{
    public class ArgumentInventory
    {
        private List<Argument> _argumentList;
        public IReadOnlyList<Argument> argumentList => _argumentList;


        public event Action<Argument> OnArgumentAdded;
        public event Action<Argument> OnArgumentRemoved;


        public ArgumentInventory()
        {
            _argumentList = new List<Argument>();
        }


        public void AddArgument(Argument argument)
        {
            _argumentList.Add(argument);
            OnArgumentAdded?.Invoke(argument);
        }


        public void RemoveArgument(Argument argument)
        {
            _argumentList.Remove(argument);
            OnArgumentRemoved?.Invoke(argument);
        }


        public Argument GetArgument(string argumentId)
        {
            return _argumentList.First(argument => argument.id == argumentId);
        }        
    }
}