using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTRD : MonoBehaviour
{

    Weapon weapon;
    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }
    public void DoPtrd(){
        if(Random.Range(-300f, 100f) > 85){
            GetComponentInParent<UnitBody>().UnitInventory.Drop(weapon.gameObject);
        }
    }
  
    void Update()
    {
        if(weapon.Shooting){
            Debug.Log("abiba");
        }
    }
}
