using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameDataSo data;
    private float timer;
    public int sideOwner; // 1 o 2, según de qué lado está la pelota

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= data.goalTimeLimit)
        {
            Debug.Log($"Se pasó el tiempo, gol en contra del jugador {sideOwner}");
            timer = 0f;
        }
    }

    public void ResetTimer(int newSideOwner)
    {
        sideOwner = newSideOwner;
        timer = 0f;
    }
}