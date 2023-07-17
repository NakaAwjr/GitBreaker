using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Enemies
{
    public class EnemyCollision : BaseEnemyComponent
    {
        [SerializeField]
        private EnemyMover _enemyMover;

        private bool _canAttack;
        public bool CanAttack => _canAttack;
        
        protected override void OnInitialize()
        {
            _canAttack = false;
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag != "Player")
            {
                _enemyMover.Move(Vector3.zero);
                return;
            }

            if (Vector2.Distance(transform.position, other.transform.position) < 1.5f)
            {
                _enemyMover.Move(Vector3.zero);
                _enemyMover.LookTarget(other.transform.position - transform.position);
                _canAttack = true;
                return;
            }

            _canAttack = false;
            
            _enemyMover.Move(other.transform.position - transform.position);
        }
    }
}
