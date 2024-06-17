using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public int Delay;
    public float LastSpawn;
    public UnitBody.Team team;
    public GameObject unit;
    public BodyArmor[] armors;
    public Helmet[] helmets;
    public Weapon[] weapons;
    void Start()
    {

    }
    void Spawn()
    {
        if (Time.time - LastSpawn > Delay)
        {
            Debug.Log(Time.time - LastSpawn);
            float x = Random.Range(this.transform.position.x - 10, this.transform.position.x + 10);
            float y = Random.Range(this.transform.position.y - 10, this.transform.position.y + 10);
            UnitBody newUnit = Instantiate(unit, new Vector3(x, y, 0), Quaternion.identity,this.transform).GetComponent<UnitBody>();
            newUnit.UnitInventory.Equip(armors[Random.Range(0, armors.Length)].gameObject);
            newUnit.UnitInventory.Equip(helmets[Random.Range(0, helmets.Length)].gameObject);
            newUnit.UnitInventory.Equip(weapons[Random.Range(0, weapons.Length)].gameObject);
            newUnit.Side = team;
            LastSpawn = Time.time;
        }
        /*
        float x = Random.Range(this.transform.position.x - 10, this.transform.position.x + 10);
        float y = Random.Range(this.transform.position.y - 10, this.transform.position.y + 10);
        BasicUnit newUnit = Instantiate(unit, new Vector3(x, y, 0), Quaternion.identity).GetComponent<BasicUnit>();
        newUnit.Side = team;
        newUnit.UnitInventory.TakeArmor(armors[Random.Range(0, armors.Length - 1)].GetComponent<BodyArmor>());
        newUnit.UnitInventory.TakeHelmet(helmets[Random.Range(0, helmets.Length - 1)].GetComponent<Helmet>());
        */
    }
    void Update()
    {
        Spawn();
    }
}
