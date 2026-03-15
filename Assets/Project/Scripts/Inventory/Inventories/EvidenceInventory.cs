using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.ScriptableObjects;
using UnityEngine;

namespace Scripts.Inventory
{
    public class EvidenceInventory
    {
        private List<Evidence> _evidence;

        public Action<Evidence> OnEvidenceAdded;
        public Action<Evidence> OnEvidenceRemoved;

        public EvidenceInventory()
        {
            _evidence = new List<Evidence>();
        }


        public void AddEvidence(Evidence evidence)
        {
            _evidence.Add(evidence);
            OnEvidenceAdded?.Invoke(evidence);
        }


        public void RemoveEvidence(Evidence evidence)
        {
            _evidence.Remove(evidence);
            OnEvidenceRemoved?.Invoke(evidence);
        }


        public Evidence GetEvidence(string id) 
        {
            return _evidence.First(e => e.id == id);
        }


        public IReadOnlyList<Evidence> GetAll()
        {
            return _evidence.AsReadOnly();
        }
    }
}