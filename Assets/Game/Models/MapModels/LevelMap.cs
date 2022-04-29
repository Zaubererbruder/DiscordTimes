using Assets.Game.Core.Time;
using Assets.Game.Models.MapModels.PawnModels;
using System.Collections.Generic;

namespace Assets.Game.Models.MapModels
{
    public class LevelMap
    {
        private LevelData _levelData;
        private List<Pawn> _pawns = new List<Pawn>();
        private List<IOnStartableModel> _onStarables = new List<IOnStartableModel>();
        private List<IUpdateableModel> _updateables = new List<IUpdateableModel>();

        public GameTime Gametime => _levelData.Gametime;

        public IReadOnlyList<Pawn> Pawns => _pawns;

        public LevelMap(LevelData leveldata)
        {
            _levelData = leveldata;
            foreach (var mapcell in _levelData.MapData.Map)
            {
                if (mapcell != null)
                    if (mapcell.Pawn != null)
                    {
                        _pawns.Add(mapcell.Pawn);
                    }
            }

        }

        public void Start()
        {
            _onStarables.ForEach((onstartable) => onstartable.OnStart());
        }

        public void Update(float deltaTime)
        {
            _pawns.ForEach((pawn) => pawn.Update(deltaTime));
            _levelData.Gametime.Update(deltaTime);
        }

        //public void AddPawnToMap(Pawn pawn) 
        //{
        //    _pawns.Add(pawn);
        //}

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
