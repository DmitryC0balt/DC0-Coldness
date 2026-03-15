using UnityEngine;

namespace Scripts.Player
{
    public class PlayerStats
    {
        public uint magic{ get; private set;}
        public uint logic{ get; private set;}
        public uint alco{ get; private set;}
        public uint cold{ get; private set;}
        public uint agressive{get; private set;}
        private const uint _agressiveCup = 10;


        public PlayerStats()
        {
            
        }


    }
}