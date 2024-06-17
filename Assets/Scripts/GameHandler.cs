using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    List<(UnitBody.Team team, UnitBody unit)> UnitsInGame = new();
    void Awake()
    {
        foreach (var i in FindObjectsByType<UnitBody>(FindObjectsSortMode.None))
        {
            AddUnit(i);
        }
    }
    void Start()
    {
    }
    public void AddUnit(UnitBody unit)
    {
        this.UnitsInGame.Add((unit.Side, unit));
        Debug.Log(unit + " | " + unit.Side, unit.gameObject);
    }
    void Update()
    {


    }
}
