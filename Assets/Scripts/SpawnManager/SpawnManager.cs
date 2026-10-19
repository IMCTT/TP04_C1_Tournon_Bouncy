using Unity.VisualScripting;
using UnityEngine;



//Hacer un sistema de obstáculos que los spawnee en una posición random (x/y 3&-3 (Aproximadamente en el
//centro) y los haga desaparecer entre 3 a 7 segundos después de aparecer

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float timeToSpawn;
    
    float totalTime;
    //bool spawned = false;

    private GameObject obstacle;
    private float destroyTime;
    private float randomPosY;
    private float randomPosX;



    void Start()
    {
        totalTime = 0;
    }
    


    void Update()
    {
        // Warning: Random.Range(3, 7) con los dos argumentos int usa la sobrecarga de enteros, que es EXCLUSIVA en el máximo: devuelve 3, 4, 5 o 6, nunca 7. La consigna pide entre 3 y 7 segundos.
        // Escribilo como Random.Range(3f, 7f). Además, las tres variables random se recalculan en cada frame aunque se usen una vez cada tres segundos: movelas adentro del if.
        destroyTime = Random.Range(3, 7);
        randomPosY = Random.Range(-3, 3.0f);
        randomPosX = Random.Range(-3, 3.0f);


        totalTime += Time.deltaTime;
        
        // Bug: el intervalo de spawn está serializado (timeToSpawn) pero el reseteo de totalTime usa un 3 escrito a mano en la línea 48. Hoy no se nota porque en la escena timeToSpawn también vale 3 y los dos if se disparan en el mismo frame.
        // Si alguien pone timeToSpawn en 2, entre el segundo 2 y el 3 se instancia un obstáculo POR FRAME (unos sesenta por segundo) y el Destroy de abajo solo alcanza al último: el resto queda vivo para siempre.
        // Usá la misma variable en los dos if, y guardá cada obstáculo para destruirlo (o mejor, reusalo con un pool).
        if (totalTime > timeToSpawn )

        {
            // Suggestion: el Vector2 se arma como (randomPosY, randomPosX), o sea que la variable llamada Y va en la X y al revés. Funciona porque las dos se sortean en el mismo rango, pero al leerlo confunde.
            // Dalos vuelta.
            obstacle = Instantiate(obstaclePrefab, new Vector2(randomPosY, randomPosX), Quaternion.identity);

           
        }

        if (totalTime > 3)
        {

            //obstacle.transform.position += new Vector3(5, 5, 0) * Time.deltaTime;

            Destroy(obstacle,destroyTime);

            totalTime = 0;

        }

        


    }
    
}
