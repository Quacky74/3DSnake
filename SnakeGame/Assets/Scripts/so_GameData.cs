using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Scriptable/GameData")]
    public class so_GameData : ScriptableObject
    {
        public string selectedLevel;
        public string playerName;
        public so_CollectableController playerCollectables;

    }
}