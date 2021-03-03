using Stride.Core.Mathematics;
using Stride.Engine;

namespace Source.Camera
{
    public class GameCameraComponent : SyncScript
    {
        // ------------------------------------------- Editor Fields
        public CameraComponent Camera;

        // -------------------------------------------

        public float Width { get; private set; }
        public float Height { get; private set; }
        
        public Vector3 Position => Entity.Transform.Position;

        public override void Start()
        {
            Height = 2 * Camera.OrthographicSize;

            float halfWidth = Camera.AspectRatio * Camera.OrthographicSize;
            Width = 2 * halfWidth;
        }

        public override void Update()
        {
        }
    }
}
