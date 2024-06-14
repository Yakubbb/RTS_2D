using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalsSpawner : MonoBehaviour
{
    public  BloodPool pool;
    public BloodSplash splash;
    public void SpawnSplash(Vector3 pos)
    {
        Vector3 v3 = pos;
        v3.y += Random.Range(-0.235f, 0.289f);
        v3.x += Random.Range(-0.235f, 0.289f);
        Instantiate(this.splash, v3, Quaternion.identity,this.transform).gameObject.layer = 8;
    }
    public void SpawnPool(Vector3 pos)
    {
        Vector3 v3 = pos;
        v3.y -= 0.289f;
        var pool = Instantiate(this.pool, v3, Quaternion.identity,this.transform);
        pool.SpawnBloodPool();
        pool.gameObject.layer = 8;

    }
    void Start()
    {

    }

    void Update()
    {

    }
}
