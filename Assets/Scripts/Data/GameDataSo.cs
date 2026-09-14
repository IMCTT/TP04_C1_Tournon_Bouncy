using UnityEngine;

[CreateAssetMenu(
    fileName = "GameData",
    menuName = "Game/Data/GameData")]

public class GameDataSo : ScriptableObject
{
        public int pointsToWin = 3;
        public float goalTimeLimit = 20f;
        public float initialBallSpeed = 5f;
        public float speedIncreasePerHit = 0.5f;
        public float maxBallSpeed = 15f;
        
    
}
