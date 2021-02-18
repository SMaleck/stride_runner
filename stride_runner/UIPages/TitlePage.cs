using Source.Services;
using Stride.UI;
using Stride.UI.Controls;
using Stride.UI.Events;

namespace Source.UIPages
{
    public class TitlePage : AbstractUiPageScript
    {
        private bool _isLoading;

        public override void Init()
        {
            var startButton = Page.RootElement.FindVisualChildOfType<Button>("bttn_start");
            startButton.Click += delegate (object sender, RoutedEventArgs e)
            {
                LoadGame();
            };
        }

        public override void Update()
        {
            if (Input.HasPressedKeys)
            {
                LoadGame();
            }
        }

        protected void LoadGame()
        {
            if (!_isLoading)
            {
                _isLoading = true;
                SceneTransitionService.Instance.ToGame();
            }
        }
    }
}
