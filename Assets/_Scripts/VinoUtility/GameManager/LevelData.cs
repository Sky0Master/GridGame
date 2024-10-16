using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VinoUtility
{
    [CreateAssetMenu(fileName = "Level Data", menuName = "SO/LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int level;
        public string levelName;
        
        [HideInInspector]
        public string sceneName;
        public SceneAsset sceneAsset;
        public int scoreToWin;

        private void OnValidate() {
            if(sceneAsset != null)
                sceneName = sceneAsset.name;
        }
    }
}