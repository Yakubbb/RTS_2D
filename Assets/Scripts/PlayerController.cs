using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SidePreset selectedSide;
    public int Lvl;
    public int Money;
    public int UnitsKolvo;
    public Vector3 SpawnPoint = new Vector3(30,20,0);
    void Start()
    {
        
    }
    void Update()
    {
        UnitsKolvo = FindObjectsByType<UnitBody>(FindObjectsSortMode.None).Count(u=>u.UnitTeam == selectedSide.team);
        
    }
}
