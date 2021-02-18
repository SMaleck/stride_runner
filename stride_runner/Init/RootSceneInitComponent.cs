using Source.Services;
using Stride.Core.Serialization;
using Stride.Engine;

namespace Source.Init
{
    public class RootSceneInitComponent : AbstractSceneInitComponent
    {
        public UrlReference<Scene> TitleSceneUrl { get; set; }
        public UrlReference<Scene> GameSceneUrl { get; set; }

        protected override void Init()
        {
            SceneTransitionService.Instance.Init(
                Entity.Scene,
                Content);

            SceneTransitionService.Instance.Register(SceneId.Title, TitleSceneUrl);
            SceneTransitionService.Instance.Register(SceneId.Game, GameSceneUrl);

            SceneTransitionService.Instance.ToTitle();
        }
    }
}
