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
        
        protected override void OnInitialize()
        {

        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag != "Player")
            {
                Debug.Log("Playerじゃない！");
                _enemyMover.Move(Vector3.zero);
                return;
            }

            if (Vector2.Distance(transform.position, other.transform.position) < 0.1f)
            {
                Debug.Log("Attack");
                _enemyMover.Move(Vector3.zero);
                _enemyMover.LookTarget(other.transform.position - transform.position);
                return;
            }
            
            _enemyMover.Move(other.transform.position - transform.position);
        }
    }
}
