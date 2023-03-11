using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject[] traps;
    public GameObject[] spawnPoints;

    private int rand;
    public int randPosition;
    public int startTimeBtwSpawns;
    private float timeBtwSpawns;

    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, traps.Length);
            randPosition = Random.Range(0, spawnPoints.Length);
            Instantiate(traps[rand], spawnPoints[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
