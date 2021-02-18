using Stride.Core.Serialization;
using Stride.Core.Serialization.Contents;
using Stride.Engine;
using System.Collections.Generic;
using System.Linq;

namespace Source.Services
{
    public class SceneTransitionService
    {
        private static SceneTransitionService _instance;
        public static SceneTransitionService Instance => _instance ?? (_instance = new SceneTransitionService());

        private readonly IDictionary<SceneId, UrlReference<Scene>> _sceneUrls;

        private Scene _initScene;
        private IContentManager _contentManager;

        public SceneTransitionService()
        {
            _sceneUrls = new Dictionary<SceneId, UrlReference<Scene>>();
        }

        public void Init(
            Scene initScene,
            IContentManager contentManager)
        {
            _initScene = initScene;
            _contentManager = contentManager;
        }

        public void Register(SceneId sceneId, UrlReference<Scene> sceneUrl)
        {
            _sceneUrls.Add(sceneId, sceneUrl);
        }

        public void ToTitle()
        {
            LoadScene(SceneId.Title);
        }

        public void ToGame()
        {
            LoadScene(SceneId.Game);
        }

        private void LoadScene(SceneId sceneId)
        {
            UnloadAll();

            var childScene = _contentManager.Load<Scene>(_sceneUrls[sceneId]);

            _initScene.Children.Add(childScene);
        }

        private void UnloadAll()
        {
            var children = _initScene.Children.ToList();
            _initScene.Children.Clear();

            children.ForEach(e => _contentManager.Unload(e));
        }
    }
}
