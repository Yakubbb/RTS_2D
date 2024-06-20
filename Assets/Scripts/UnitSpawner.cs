using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public UnitBody.Team team;
    public GameObject unit;
    public BodyArmor[] armors;
    public Helmet[] helmets;
    public Weapon[] weapons;
    public int Kolvo;
    public int spawned = 0;
    void Start()
    {

    }
    void Spawn()
    {
            float x = Random.Range(this.transform.position.x - 15, this.transform.position.x + 15);
            float y = Random.Range(this.transform.position.y - 15, this.transform.position.y + 15);
            UnitBody newUnit = Instantiate(unit, new Vector3(x, y, 0), Quaternion.identity,this.transform).GetComponentInChildren<UnitBody>();
            newUnit.UnitInventory.Equip(armors[Random.Range(0, armors.Length)].gameObject);
            newUnit.UnitInventory.Equip(helmets[Random.Range(0, helmets.Length)].gameObject);
            newUnit.UnitInventory.Equip(weapons[Random.Range(0, weapons.Length)].gameObject);
            newUnit.UnitTeam = team;
            x = Random.Range(newUnit.transform.position.x - 15, newUnit.transform.position.x + 15);
            y = Random.Range(newUnit.transform.position.y - 15, newUnit.transform.position.y + 15);
            newUnit.GoToPoint = new Vector3(x,y,0);
            newUnit.UnitName = NamesProvider.GetRandomName();
    }
    void Update()
    {
        if(spawned < Kolvo){
            Spawn();
            spawned++;
        }
    }
}
