using Source.Camera;
using Source.Player;
using Stride.Core.Mathematics;
using Stride.Engine;
using System.Collections.Generic;
using System.Linq;

namespace Source.World
{
    public class BackgroundSpawner : SyncScript
    {
        public GameCameraComponent GameCamera;
        public LookAheadComponent LookAheadComponent;
        public Entity Cube;

        private List<PoolItem<Entity>> _entityPool;

        private double _elapsedSeconds;

        public override void Start()
        {
            _entityPool = new List<PoolItem<Entity>>();
        }

        public override void Update()
        {
            // ToDo reuse Spawned blocks when out of sight
            _elapsedSeconds += Game.UpdateTime.Elapsed.TotalSeconds;
            if (_elapsedSeconds > 1)
            {
                Spawn();
                _elapsedSeconds = 0;
            }
        }

        private void Spawn()
        {
            var poolItem = GetFreePoolItem();
            poolItem.IsFree = false;

            var spawnPos = GetSpawnPosition(poolItem.Item);
            poolItem.Item.Transform.Position = spawnPos;
        }

        private Vector3 GetSpawnPosition(Entity entity)
        {
            var screenEdgeX = GameCamera.Position.X + (GameCamera.Width / 2);
            var entityHalfWidth = entity.Get<ModelComponent>().BoundingBox.Extent.X / 2;

            return new Vector3(
                screenEdgeX + entityHalfWidth,
                0,
                -5);
        }

        private PoolItem<Entity> GetFreePoolItem()
        {
            var poolItem = _entityPool.FirstOrDefault(e => e.IsFree);
            return poolItem ?? CreatePoolItem();
        }

        private PoolItem<Entity> CreatePoolItem()
        {
            var clone = Cube.Clone();
            Entity.Scene.Entities.Add(clone);

            var poolItem = new PoolItem<Entity>(clone);
            _entityPool.Add(poolItem);

            return poolItem;
        }
    }
}
