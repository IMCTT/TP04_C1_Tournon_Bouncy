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
        destroyTime = Random.Range(3, 7);
        randomPosY = Random.Range(-3, 3.0f);
        randomPosX = Random.Range(-3, 3.0f);


        totalTime += Time.deltaTime;
        
        if (totalTime > timeToSpawn )

        {
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
