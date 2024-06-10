using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    void Start()
    {
        weapon = GetComponent<Weapon>();
    }
    void Update()
    {
        
    }
}
