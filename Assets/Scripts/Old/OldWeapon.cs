using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWeapon : MonoBehaviour
{
    public String Name;
    public int Damage;
    public int Distance;
    public int FireRate;
    SpriteRenderer gunModel;
    private void AimAt(Vector3 aim)
    {
        Vector3 direction = (aim - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
        if (aim.x < this.transform.position.x)
        {
            gunModel.flipY = true;
        }
        else
        {
            gunModel.flipY = false;
        }
    }
    void Start()
    {
        gunModel = GetComponent<SpriteRenderer>();
    }
    public void Shoot(Unit enemy)
    {
        AimAt(enemy.transform.position);
    }
    void Update()
    {

    }
}
