using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Armor : RotationHandler
{
    public float PosOnUnit;
    public string Name;
    public int Hp;
    public int ArmorClass;
    public void TryPenetrate(int inputDamage, out int outputDamage)
    {
        if (Hp <= inputDamage)
        {
            outputDamage = inputDamage - Hp;
            Hp = 0;
        }
        else
        {
            outputDamage = inputDamage / Random.Range(1, 10) - Hp;
            Hp -= outputDamage;
        }
    }
}
