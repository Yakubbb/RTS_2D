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
    public Vector3 BuildingSpawnPoint = new Vector3(-20, 0,0);
    public Vector3 SpawnPoint = new Vector3(0,0,0);
    private float LastTimeMoney;
    public bool TakeMoney(int amount){
        if(amount > Money){
            return false;
        }
        else{
            Money -= amount;
            return true;
        }
    }
    void GiveMomey(){
        if(Time.time - LastTimeMoney > 10){
            LastTimeMoney = Time.time;
            Money+=100;
        }
        Debug.Log(Settings.HasBlood);
    }
    void Start()
    {
        
    }
    void Update()
    {
        GiveMomey();
        UnitsKolvo = FindObjectsByType<UnitBody>(FindObjectsSortMode.None).Count(u=>u.UnitTeam == selectedSide.team);
        Lvl = UnitsKolvo/3;
        
    }
}
