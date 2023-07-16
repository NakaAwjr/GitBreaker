using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;


namespace Assets.MyAssets.Field.Scripts.Enemies
{
    public class EnemyMover : BaseEnemyComponent
    {
        enum EnemyState
        {
            Patrol,
            Chase,
            Attack
        }

        private EnemyState _currentState;

        private List<Transform> _wayPoints;

        private Vector3 _targetVector = Vector3.zero;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        public void Move(Vector3 velocity)
        {
            _targetVector = velocity;
        }

        public void LookTarget(Vector3 direction)
        {
            transform.rotation = Quaternion.Euler(0, 0, VectorToAngle(new Vector2(direction.x,direction.y)) - 90f);
        }

        protected override void OnInitialize()
        {
            _targetVector = Vector3.zero;
            this.FixedUpdateAsObservable()
                .Subscribe(_ =>
                {
                    if (_targetVector * EnemyCore.CurrentEnemyParameter["Speed"] != null)
                    {
                        _rigidbody.velocity = _targetVector * EnemyCore.CurrentEnemyParameter["Speed"] * 0.1f;
                    
                        if (_targetVector != Vector3.zero)
                        {
                            LookTarget(_targetVector);
                        }
                    }
                });
        }
        private static float VectorToAngle(Vector2 vector)
        {
            return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        }

    }
}
