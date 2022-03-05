using Assets.Game.Core.Pathfinding;
using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels.Spawners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Models.MapModels
{
    public class LevelMap
    {
        private MapCell[,] _map;
        private GridGraph _graph;
        private GameTime _gameTime;
        private List<Pawn> _pawns = new List<Pawn>();
        private List<IOnStartableModel> _onStarables = new List<IOnStartableModel>();
        private List<IUpdateableModel> _updateables = new List<IUpdateableModel>();
        private IPawnFactory _pawnBuilder;

        public MapCell this[int x, int y]
        {
            get { return _map[x, y]; }
            set { _map[x, y] = value; }
        }

        public GridGraph Graph => _graph;
        public GameTime GameTime => _gameTime;

        public IReadOnlyList<Pawn> Pawns => _pawns;

        public LevelMap(MapCell[,] map)
        {
            _gameTime = new GameTime(3600);
            _map = map;
            _graph = new GridGraph(_map.GetLength(0), _map.GetLength(1));
            foreach(var mapCell in _map)
            {
                if (mapCell == null)
                    continue;

                _graph.AddNode(mapCell.X, mapCell.Y, mapCell.Cost);
            }
            _pawnBuilder = new PlayerPawnFactory(this);
        }

        public void Start()
        {
            OnStart();
        }

        private void OnStart()
        {
            _onStarables.ForEach((onstartable) => onstartable.OnStart());
        }

        public void Update(float deltaTime)
        {
            _gameTime.Update(deltaTime);
            _pawns.ForEach((pawn) => pawn?.Update(deltaTime));
            _updateables.ForEach((upd) => upd.Update(deltaTime));
        }

        public void AddPawnToMap(Pawn pawn) 
        {
            _pawns.Add(pawn);
        }

        public void AddUpdateableModel(IUpdateableModel updModel)
        {
            _updateables.Add(updModel);
        }

        public void AddOnstartableModel(IOnStartableModel onstrtModel)
        {
            _onStarables.Add(onstrtModel);
        }

    }
}
