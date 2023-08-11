using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public float levelHeight = 1000;
    public GameObject obstacle;
    public GameObject coin;
    public GameObject shield;
    public GameObject speedUp;
    public GameObject levelTrigger;
    // Start is called before the first frame update
    void Start()
    {
        // prefab start_amount end_amount starting_y distance
        Spawner(obstacle, 5*((int)levelHeight), 10*((int)levelHeight), 10, 30);
        Spawner(coin,15*((int)levelHeight), 30*((int)levelHeight), 5, 5);
        Spawner(speedUp, 3*((int)levelHeight), 6*((int)levelHeight), 40, 70);
        Spawner(shield, 3*((int)levelHeight), 6*((int)levelHeight), 80, 70);
        Instantiate(levelTrigger, new Vector3(0, levelHeight + 3, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Spawner(GameObject prefab, int amountStart, int amountEnd, int y_start, int distance) {
        int randomAmount = Random.Range(amountStart, amountEnd);
        int randomy = Random.Range(y_start, y_start+distance);
        while (randomy < levelHeight) {
            int randomx = Random.Range(0, 6);
            randomy += Random.Range(distance-5,distance+5);
            Instantiate(prefab, new Vector3(randomx, randomy, 0), Quaternion.identity);
        }
    }
}
