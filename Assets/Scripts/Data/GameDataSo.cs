using UnityEngine;

[CreateAssetMenu(
    fileName = "GameData",
    menuName = "Game/Data/GameData")]

public class GameDataSo : ScriptableObject
{
        public int pointsToWin = 3;
        public float goalTimeLimit = 20f;
        // Warning: de los cinco campos del ScriptableObject, solo pointsToWin y goalTimeLimit se leen en algún lado. initialBallSpeed, speedIncreasePerHit y maxBallSpeed no los usa nadie: la velocidad real de la pelota sale de Ball.bounce y de GameManager.initialForce, los dos serializados por separado.
        // Movelos de verdad al SO, así los tres valores de la pelota se configuran en un solo lugar. Y pasá los cinco campos a [SerializeField] private con getters.
        public float initialBallSpeed = 5f;
        public float speedIncreasePerHit = 0.5f;
        public float maxBallSpeed = 15f;
        
    
}
