using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmorRotator : MonoBehaviour
{
    public RotationHandler head;
    public RotationHandler body;
    public SpriteRenderer weaponHide;
    Weapon weapon;
    Helmet helmet;
    BodyArmor armor;
    UnitBody unitBody;
    void HandleWidth(Vector3 direction)
    {
        if (direction.x < 0)
        {
            if (head != null)
            {
                head.LookRight();
            }
            if (body != null)
            {
                body.LookRight();
            }
            if (armor != null)
            {
                armor.LookRight();
            }
            if (helmet != null)
            {
                helmet.LookRight();
            }
            if (weapon != null)
            {
                if (armor != null)
                {
                    weapon.spriteRenderer.sortingOrder = armor.SpriteRenderer.sortingOrder + 1;
                }
                else
                {
                    weapon.spriteRenderer.sortingOrder = weaponHide.sortingOrder + 1;
                }
            }
        }
        else if (direction.x > 0)
        {
            if (head != null)
            {
                head.LookLeft();
            }
            if (body != null)
            {
                body.LookLeft();
            }
            if (armor != null)
            {
                armor.LookLeft();
            }
            if (helmet != null)
            {
                helmet.LookLeft();
            }
            if (weapon != null)
            {
                if (armor != null)
                {
                    weapon.spriteRenderer.sortingOrder = armor.SpriteRenderer.sortingOrder + 1;
                }
                else
                {
                    weapon.spriteRenderer.sortingOrder = weaponHide.sortingOrder + 1;
                }
            }

        }
    }
    void HandleHeight(Vector3 direction)
    {
        if (direction.y < 0 && Math.Abs(direction.x)<0.4f)
        {
            if (head != null)
            {
                head.LookBehind();
            }
            if (body != null)
            {
                body.LookBehind();
            }
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

                weapon.spriteRenderer.sortingOrder = weaponHide.sortingOrder - 1;

            }
        }
        else if (direction.y > 0 && Math.Abs(direction.x)<0.4f)
        {
            if (head != null)
            {
                head.LookFront();
            }
            if (body != null)
            {
                body.LookFront();
            }
            if (armor != null)
            {
                armor.LookFront();
            }
            if (helmet != null)
            {
                helmet.LookFront();
            }
            if (weapon != null)
            {
                if (armor != null)
                {
                    weapon.spriteRenderer.sortingOrder = armor.SpriteRenderer.sortingOrder + 1;
                }
                else
                {
                    weapon.spriteRenderer.sortingOrder = weaponHide.sortingOrder + 1;
                }
            }

        }
    }


    void Start()
    {
        unitBody = GetComponentInChildren<UnitBody>();
    }
    void Update()
    {
        armor = unitBody.UnitInventory.armor;
        helmet = unitBody.UnitInventory.helmet;
        weapon = unitBody.UnitInventory.weapon;
        Vector3 direction = (unitBody.transform.position - unitBody.LookingTarget).normalized;
        Debug.Log(direction);
        HandleWidth(direction);
        HandleHeight(direction);
    }
}