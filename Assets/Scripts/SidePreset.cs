using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePreset : MonoBehaviour
{
    public GameObject unit;
    public UnitBody.Team team;
    public GameObject[] LowTierArmor;
    public GameObject[] MidTierArmor;
    public GameObject[] HighTierArmor;

    public GameObject[] LowTierHelmet;
    public GameObject[] MidTierHelmet;
    public GameObject[] HighTierHelmet;

    public GameObject[] LowTierPistol;
    public GameObject[] MidTierPistol;
    public GameObject[] HighTierPistol;

    public GameObject[] LowTierRifle;
    public GameObject[] MidTierRifle;
    public GameObject[] HighTierRifle;

    public GameObject[] LowTierAR;
    public GameObject[] MidTierAR;
    public GameObject[] HighTierAR;
    private GameObject GetRandomItem(GameObject[] items)
    {
        return items[Random.Range(0, items.Length)];
    }
    private UnitBody Spawn(string name, int skill, Vector3 position, GameObject[] armor = null, GameObject[] weapon = null, GameObject[] helmet = null)
    {
        UnitBody newUnit = Instantiate(unit, position, Quaternion.identity).GetComponentInChildren<UnitBody>();
        if (armor != null && armor.Length > 0)
        {
            newUnit.UnitInventory.Equip(GetRandomItem(armor).gameObject);
        }
        if (weapon != null && weapon.Length > 0)
        {
            newUnit.UnitInventory.Equip(GetRandomItem(weapon).gameObject);
        }
        if (helmet != null && helmet.Length > 0)
        {
            newUnit.UnitInventory.Equip(GetRandomItem(helmet).gameObject);
        }
        newUnit.UnitTeam = this.team;
        newUnit.UnitName = name;
        newUnit.Accuracy = skill;
        return newUnit;

    }
    public UnitBody SpawnLowPistol(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, LowTierArmor, LowTierPistol, LowTierHelmet);
    public UnitBody SpawnLowAR(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, LowTierArmor, LowTierAR, LowTierHelmet);
    public UnitBody SpawnLowSniper(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, LowTierArmor, LowTierRifle, LowTierHelmet);

    public UnitBody SpawnMidPistol(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, MidTierArmor, MidTierPistol, MidTierHelmet);
    public UnitBody SpawnMidAR(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, MidTierArmor, MidTierAR, MidTierHelmet);
    public UnitBody SpawnMidSniper(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, MidTierArmor, MidTierRifle, MidTierHelmet);

    public UnitBody SpawnHighPistol(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, HighTierArmor, HighTierPistol, HighTierHelmet);
    public UnitBody SpawnHighAR(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, HighTierArmor, HighTierAR, HighTierHelmet);
    public UnitBody SpawnHighSniper(Vector3 pos, int skill, string name) => Spawn(name,skill,pos, HighTierArmor, HighTierRifle, HighTierHelmet);
}
