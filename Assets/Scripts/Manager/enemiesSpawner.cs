using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public int range;
    public int rate;
    public int delay;
    float countdown;

    public void Spawn()
    {
        for(int i = 0; i < rate; i ++)
        {
            Instantiate(
                enemies[Random.Range(0, enemies.Count)],
                new Vector3(Random.Range(-range, range+1), Random.Range(-range, range+1), 0),
                Quaternion.identity
            );
        }
    }

    void Update()
    {
        if(countdown <= 0)
        {
            Spawn();
            countdown = delay;
            return;
        }

        countdown -= Time.deltaTime;
    }
}
