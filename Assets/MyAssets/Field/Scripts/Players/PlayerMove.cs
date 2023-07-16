using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Players
{
    /// <summary>
    /// プレイヤーの動き
    /// </summary>
    public class PlayerMove : BasePlayerComponent
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private Vector3 _inputDirection;
        
        public void Move(Vector3 velocity)
        {
            _inputDirection = velocity;
        }

        protected override void OnInitialize()
        {
            this.FixedUpdateAsObservable()
                .Subscribe(_ =>
                {
                    if (_inputDirection * PlayerCore.CurrentPlayerParameter["Speed"] != null)
                    {
                        _rigidbody.velocity = _inputDirection * PlayerCore.CurrentPlayerParameter["Speed"] * 0.5f;
                        if (_inputDirection != Vector3.zero)
                        {
                            transform.rotation = Quaternion.Euler(0, 0,
                                VectorToAngle(new Vector2(_inputDirection.x, _inputDirection.y)) - 90f);
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
