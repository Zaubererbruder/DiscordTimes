using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels.Spawners
{
    public class AIPawnFactory : IPawnFactory, IOnStartableModel
    {
        private int _team = 1;
        private LevelMap _map;
        private int _x, _y;

        public AIPawnFactory(LevelMap map)
        {
            _map = map;
        }

        public event Action<Pawn> PawnSpawned;

        public void SetPosition(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void SetTeam(int teamNumber)
        {
            _team = teamNumber;
        }

        public Pawn Create()
        {
            var pawn = new Pawn(_team);

            var transform = new PawnTransform(_map.Graph, _x, _y);
            pawn.AttachComponent(transform);

            var movement = new PawnPathMovement();
            movement.SetSpeed(5);
            pawn.AttachComponent(movement);

            _map.AddPawnToMap(pawn);
            PawnSpawned?.Invoke(pawn);

            return pawn;
        }

        public void OnStart()
        {
            Create();
        }
    }
}
