using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public int Delay;
    public float LastSpawn;
    public BasicUnit.Team team;
    public GameObject unit;

    public GameObject[] armors;
    public GameObject[] helmets;

    void Start()
    {

    }
    void Spawn()
    {
        if (Time.time - LastSpawn < Delay)
        {
            return;
        }
        float x = Random.Range(this.transform.position.x - 10, this.transform.position.x + 10);
        float y = Random.Range(this.transform.position.y - 10, this.transform.position.y + 10);
        BasicUnit newUnit = Instantiate(unit, new Vector3(x, y, 0), Quaternion.identity).GetComponent<BasicUnit>();
        newUnit.Side = team;
        newUnit.UnitInventory.TakeArmor(armors[Random.Range(0, armors.Length - 1)].GetComponent<BodyArmor>());
        newUnit.UnitInventory.TakeHelmet(helmets[Random.Range(0, helmets.Length - 1)].GetComponent<Helmet>());
        LastSpawn = Time.time;
    }
    void Update()
    {
        Spawn();
    }
}
