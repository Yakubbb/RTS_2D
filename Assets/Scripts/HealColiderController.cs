using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealColiderController : MonoBehaviour
{
    public UnitBody healTarget; 
    void Start()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);
        if (this.healTarget != null)
        {
            return;
        }
        if (collision.gameObject.layer != 6)
        {
            return;
        }
        var healTarget = collision.gameObject.GetComponent<UnitBody>();
        if (healTarget == null | healTarget.IsDead | healTarget.Hp == 100)
        {
             Debug.Log(collision.transform.name + "2");
            if (healTarget == this.healTarget)
            {
                this.healTarget = null;
            }
            return;
        }
        this.healTarget = healTarget;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            return;
        }
        var healTarget = collision.gameObject.GetComponent<UnitBody>();
        if (this.healTarget == healTarget)
        {
            this.healTarget = null;
        }
    }
}
