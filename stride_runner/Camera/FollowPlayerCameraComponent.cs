using Stride.Core.Mathematics;
using Stride.Engine;

namespace Source.Camera
{
    public class FollowPlayerCameraComponent : SyncScript
    {
        public TransformComponent FollowTarget;

        private TransformComponent _transform;

        public override void Start()
        {
            _transform = Entity.Get<TransformComponent>();
        }

        public override void Update()
        {
            if (FollowTarget != null)
            {
                _transform.Position = new Vector3(
                    FollowTarget.Position.X,
                    _transform.Position.Y,
                    _transform.Position.Z);
            }
        }
    }
}
