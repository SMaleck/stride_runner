using System;
using System.Collections.Generic;
using System.Text;
using Source.Services;
using Stride.Core.Serialization;
using Stride.Engine;
using Stride.Input;
using Stride.UI.Controls;
using Stride.UI.Events;

namespace Source.UIPages
{
    public class TitlePage : SyncScript
    {
        public Button _startButton;
        public UrlReference<Scene> GameSceneUrl { get; set; }

        private bool _isLoading;

        public override void Update()
        {
            if (Input.HasPressedKeys && !_isLoading)
            {
                _isLoading = true;
                SceneTransitionService.Instance.ToGame();
            }
        }
    }
}
