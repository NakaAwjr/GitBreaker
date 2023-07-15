using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Players
{
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
                    Debug.Log(_inputDirection);
                    _rigidbody.velocity = _inputDirection * PlayerCore.CurrentPlayerParameter["Speed"] * 0.5f;
                });
        }
    }
}
