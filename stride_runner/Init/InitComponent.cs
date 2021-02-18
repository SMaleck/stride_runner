using Source.Services;
using Stride.Core.Serialization;
using Stride.Engine;

namespace Source.Init
{
    public class InitComponent : SyncScript
    {
        public UrlReference<Scene> TitleSceneUrl { get; set; }
        public UrlReference<Scene> GameSceneUrl { get; set; }

        public override void Start()
        {
            SceneTransitionService.Instance.Init(
                SceneSystem.SceneInstance.RootScene,
                Content);

            SceneTransitionService.Instance.Register(SceneId.Title, TitleSceneUrl);
            SceneTransitionService.Instance.Register(SceneId.Game, GameSceneUrl);

            SceneTransitionService.Instance.ToTitle();
        }

        public override void Update()
        {
        }
    }
}
