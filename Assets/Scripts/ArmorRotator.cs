using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorRotator : MonoBehaviour
{
    public SpriteRenderer body;
    Weapon weapon;
    Helmet helmet;
    BodyArmor armor;
    UnitBody unitBody;
    void HandleWidth(Vector3 direction)
    {
        if (direction.x < 0)
        {
            if (armor != null)
            {
                armor.LookRight();
            }
            if (helmet != null)
            {
                helmet.LookRight();
            }
        }
        else if (direction.x > 0)
        {
            if (armor != null)
            {
                armor.LookLeft();
            }
            if (helmet != null)
            {
                helmet.LookLeft();
            }
        }
    }
    void HandleHeight(Vector3 direction)
    {
        if (direction.y < -0.46f)
        {
            if (armor != null)
            {
                armor.LookBehind();
            }
            if (helmet != null)
            {
                helmet.LookBehind();
            }
            if (weapon != null)
            {
                weapon.spriteRenderer.sortingOrder = body.sortingOrder-1;
            }
        }
        else if (direction.y > 0.46f)
        {
            if (armor != null)
            {
                armor.LookFront();
            }
            if (helmet != null)
            {
                helmet.LookFront();
            }
            weapon.spriteRenderer.sortingOrder = body.sortingOrder+1;
        }
    }


    void Start()
    {
        unitBody = GetComponentInChildren<UnitBody>();
        Debug.Log(unitBody.UnitInventory);
        armor = unitBody.UnitInventory.armor;
        helmet = unitBody.UnitInventory.helmet;
        weapon = unitBody.UnitInventory.weapon;
    }
    void Update()
    {
        Vector3 direction = (unitBody.transform.position - unitBody.GoToPoint).normalized;
        Debug.Log(direction);
        HandleWidth(direction);
        HandleHeight(direction);
    }
}