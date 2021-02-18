using Stride.Engine;

namespace Source.UIPages
{
    public abstract class AbstractUiPageScript : SyncScript
    {
        protected UIPage Page;

        public sealed override void Start()
        {
            Page = Entity.Get<UIComponent>().Page;

            Init();
        }

        public virtual void Init() { }

        public abstract override void Update();
    }
}
