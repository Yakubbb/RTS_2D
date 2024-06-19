using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCommander : MonoBehaviour
{
    public List<UnitBody> AvalibleUnits;
    public int UnitsSpawned;
    public List<UnitBody> Units;
    public Vector3 SpawnPoint;
    public void SpawnUnit(UnitBody unit){
        Instantiate(unit,SpawnPoint,Quaternion.identity);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
