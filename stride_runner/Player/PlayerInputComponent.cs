using Stride.Engine;
using Stride.Input;
using Stride.Physics;

namespace Source
{
    public class PlayerInputComponent : SyncScript
    {
        private CharacterComponent _characterComponent;

        public override void Start()
        {
            _characterComponent = Entity.Get<CharacterComponent>();
        }

        public override void Update()
        {
            if (!_characterComponent.IsActive)
            {
                return;
            }

            ProcessInput();
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
