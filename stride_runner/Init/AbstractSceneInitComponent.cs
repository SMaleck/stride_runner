using Stride.Engine;

namespace Source.Init
{
    public abstract class AbstractSceneInitComponent : SyncScript
    {
        public sealed override void Start()
        {
            Init();
        }

        public sealed override void Update()
        {
        }

        protected abstract void Init();
    }
}
