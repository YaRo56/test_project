using UnityEngine;

namespace BHSCamp
{
    public class PlayerAttack : AttackBase
    {
        [SerializeField] private int _damage;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Projectile _bullet;
        [SerializeField] private Transform _projectileParent;
        
        public override void BeginAttack()
        {
            if (IsAttacking) return;
            
            base.BeginAttack(); // вызываем метод BeginAttack() у родительского класса
            Projectile projectile = Instantiate(
                _bullet,
                _shootPoint.position,
                Quaternion.identity,
                _projectileParent
            );
            projectile.SetDirection(GetForwardVector());
            projectile.SetDamage(_damage);
        }

        private Vector2 GetForwardVector()
        {
            return new Vector2(
                transform.localScale.x,
                0
            ).normalized;
        }
    }
}