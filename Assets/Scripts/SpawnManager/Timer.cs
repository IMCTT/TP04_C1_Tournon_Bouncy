using UnityEngine;

// Warning: este script no está puesto en ninguna de las dos escenas ni en ningún prefab: es código muerto. Lo que hace (el límite de tiempo por lado) ya lo resuelve Ball.PityTimer.
// Borralo, o quedate con este y sacá el pitytimer de Ball, que es donde mejor estaría: un script para el tiempo y otro para la pelota.
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