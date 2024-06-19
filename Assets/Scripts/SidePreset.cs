using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePreset : MonoBehaviour
{
    
    public UnitBody.Team team;
    public GameObject[] LowTierArmor;
    public GameObject[] MidTierArmor;
    public GameObject[] HighTierArmor;

    public GameObject[] LowTierPistol;
    public GameObject[] MidTierPistol;
    public GameObject[] HighTierPistol;

    public GameObject[] LowTierRifle;
    public GameObject[] MidTierRifle;
    public GameObject[] HighTierRifle;

    public GameObject[] LowTierAR;
    public GameObject[] MidTierAR;
    public GameObject[] HighTierAR;

    public void Spawn(GameObject[] armor, GameObject[] weapon, GameObject[] helmet)
    {
        
    }
}
