using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCommander : MonoBehaviour
{
    public bool IsAlive;
    private UnitBody body;
    void Awake()
    {
        body = GetComponentInChildren<UnitBody>();
    }

    void Update()
    {
        IsAlive = !body.IsDead;
    }
}
