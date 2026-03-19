using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.ScriptableObjects;
using UnityEngine;

namespace Scripts.Inventory
{
    public class RecordInventory
    {
        private readonly List<CharacterRecord> _characterRecordList;

        public event Action<CharacterRecord> OnCharacterRecordAdded;
        public event Action<Record> OnRecordAdded;


        public RecordInventory()
        {
            _characterRecordList = new List<CharacterRecord>();
        }


        public void AddCharacter(CharacterRecord characterRecord)
        {
            characterRecord.factsList = new List<Record>();

            _characterRecordList.Add(characterRecord);
            OnCharacterRecordAdded?.Invoke(characterRecord);
        }


        public void AddRecord(Record record)
        {
            CharacterRecord characterRecord = _characterRecordList.First(character => character.id == record.character.id);

            if (characterRecord != null)
            {
                characterRecord.factsList.Add(record);
                OnRecordAdded?.Invoke(record);
                return;
            }

            record.character.factsList = new List<Record>
            {
                record
            };

            _characterRecordList.Add(record.character);
            OnCharacterRecordAdded(record.character);
            
        }
    }
}