using UnityEngine;

namespace Scripts.NewPlayer
{
    public class PlayerAttack
    {
        private Transform _firePoint;
        private int _atkValue;
        private float _currentSpread;

        public PlayerAttack(PlayerAttackSetup playerAttackSetup)
        {
            _firePoint = playerAttackSetup.firePoint;
            _atkValue = playerAttackSetup.atkValue;
        }


        public void SetAngleSpread(float angle)
        {
            _currentSpread = angle;
        }


        private float CalculateSpread()
        {
            var spread = Random.Range(0, _currentSpread);
            return spread;
        }


        public void PerformAttack()
        {
            var spread = CalculateSpread();

        }
    }
}