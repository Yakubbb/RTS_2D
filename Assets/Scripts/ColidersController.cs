using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColidersController : MonoBehaviour
{
    public UnitBody enemy;
    public UnitBody unit;
    public UnitBody.Team ColiderTeam;
    void Awake(){
        this.ColiderTeam = unit.UnitTeam;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.ColiderTeam = unit.UnitTeam;
        if (this.enemy != null)
        {
            return;
        }
        if (collision.gameObject.layer != 6)
        {
            //Debug.Log(collision.gameObject,this);
            return;
        }
        var enemy = collision.gameObject.GetComponent<UnitBody>();
        if (enemy == null | enemy.UnitTeam == this.ColiderTeam | enemy.IsDead)
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
        this.ColiderTeam = unit.UnitTeam;
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
    void Update(){
        //Debug.Log(this.ColiderTeam);
    }
}
