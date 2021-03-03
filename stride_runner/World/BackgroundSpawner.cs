using System;
using System.Collections.Generic;
using System.Text;
using Source.Player;
using Stride.Core.Serialization;
using Stride.Engine;
using Stride.Rendering;

namespace Source.World
{
    public class BackgroundSpawner : SyncScript
    {
        public LookAheadComponent LookAheadComponent;
        public Entity Cube;

        public override void Start()
        {
            // ToDo Get Lookahead Component
        }

        public override void Update()
        {
            // ToDo Spawn blocks ahead of player
            // ToDo reuse Spawned blocks when out of sight
        }

        private void CreateCube()
        {
            var clone = Cube.Clone();
        }
    }
}
