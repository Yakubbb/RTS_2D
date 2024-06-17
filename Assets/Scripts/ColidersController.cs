using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColidersController : MonoBehaviour
{
    public UnitBody enemy;
    private UnitBody.Team team;
    void Awake(){
        this.team = GetComponentInParent<UnitBody>().Side;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.enemy != null)
        {
            return;
        }
        if (collision.gameObject.layer != 6)
        {
            return;
        }
        var enemy = collision.gameObject.GetComponent<UnitBody>();
        if (enemy == null | enemy.Side == this.team | enemy.IsDead)
        {
            if (enemy == this.enemy)
            {
                this.enemy = null;
            }
            return;
        }
        this.enemy = enemy;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            return;
        }
        var enemy = collision.gameObject.GetComponent<UnitBody>();
        if (this.enemy == enemy)
        {
            this.enemy = null;
        }
    }
}
