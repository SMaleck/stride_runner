using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;
using Stride.Physics;

namespace Source.Player
{
    public class PlayerInputComponent : SyncScript
    {
        // --------------------------- EDITOR FIELDS
        public float Speed;

        private CharacterComponent _characterComponent;

        public override void Start()
        {
            _characterComponent = Entity.Get<CharacterComponent>();
            Enable();
        }

        public override void Update()
        {
            if (!_characterComponent.IsActive)
            {
                return;
            }

            ProcessInput();
        }

        public void Enable()
        {
            _characterComponent.SetVelocity(Vector3.UnitX * Speed);
        }

        private void ProcessInput()
        {
            if (_characterComponent.IsGrounded && Input.IsKeyPressed(Keys.Space))
            {
                _characterComponent.Jump();
            }
        }
    }
}
