using UnityEngine;

public class GameSettings : ScriptableObject
{
    [Header("Reglas del partido")]
    [Tooltip("Puntos necesarios para ganar el partido")]
    public int pointsToWin = 3;

    [Header("Límite de tiempo por posesión")]
    [Tooltip("Segundos que tiene un jugador para convertir el gol antes de que se lo hagan")]
    public float goalTimeLimit = 20f;

    [Header("Velocidad de la pelota")]
    public float initialBallSpeed = 5f;
    public float speedIncreasePerHit = 0.5f;
    public float maxBallSpeed = 15f;
}