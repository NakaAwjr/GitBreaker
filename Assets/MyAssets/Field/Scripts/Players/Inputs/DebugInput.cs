using UnityEngine;
using UniRx;
using UniRx.Triggers;
namespace Assets.MyAssets.Field.Scripts.Players.Inputs
{
    public class DebugInput : MonoBehaviour, IInputProvider
    {
        private ReactiveProperty<Vector3> _moveDirection = new ReactiveProperty<Vector3>();
        private ReactiveProperty<bool> _onItemButtonPushed = new BoolReactiveProperty();
        private ReactiveProperty<bool> _onNormalAttackButtonPushed = new BoolReactiveProperty();
        private ReactiveProperty<bool> _onSpecialAttackButtonPushed = new BoolReactiveProperty();

        public IReadOnlyReactiveProperty<Vector3> MoveDirection { get { return _moveDirection; } }
        public IReadOnlyReactiveProperty<bool> OnItemButtonPushed { get { return _onItemButtonPushed; } }
        public IReadOnlyReactiveProperty<bool> OnNormalAttackButtonPushed { get { return _onNormalAttackButtonPushed; } }
        public IReadOnlyReactiveProperty<bool> OnSpecialAttackButtonPushed { get { return _onSpecialAttackButtonPushed; } }

        private void Awake()
        {
            this.UpdateAsObservable()
                .Select(_ =>
                {
                    Vector3 inputDirection = Vector3.zero;
                    if (Input.GetKey(KeyCode.W))
                    {
                        inputDirection += Vector3.forward;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        inputDirection += Vector3.back;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        inputDirection += Vector3.left;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        inputDirection += Vector3.right;
                    }
                        
                    return inputDirection.normalized;
                })
                .Subscribe(x => _moveDirection.SetValueAndForceNotify(x));

            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.P))
                .DistinctUntilChanged()
                .Subscribe(x => _onItemButtonPushed.Value = x);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.N))
                .DistinctUntilChanged()
                .Subscribe(x => _onNormalAttackButtonPushed.Value = x);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.X))
                .DistinctUntilChanged()
                .Subscribe(x => _onSpecialAttackButtonPushed.Value = x);
        }
    }
}