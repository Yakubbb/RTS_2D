using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Helmet helmet;
    public BodyArmor armor;
    public Weapon weapon;
    public float posOnHead = 1.1f;
    public float posOnBody = 1;
    public float weaponPos = 0;
    public void TakeObject(GameObject obj)
    {

    }
    public void Equip(GameObject obj){
        if( obj.GetComponent<Helmet>()){
            if(helmet != null){
                Destroy(helmet.gameObject);
                helmet = null;
            }
            helmet = Instantiate(obj, new Vector3(this.transform.position.x, this.transform.position.y + posOnHead, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Helmet>();
        }
        else if(obj.GetComponent<Helmet>()){
            
        }
    }
    void Start()
    {
        if (helmet != null)
        {
            helmet = Instantiate(helmet, new Vector3(this.transform.position.x, this.transform.position.y + posOnHead, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Helmet>();
        }
        if (armor != null)
        {
           armor= Instantiate(armor, new Vector3(this.transform.position.x, this.transform.position.y + posOnBody, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<BodyArmor>();
        }
        if (weapon != null)
        {
            weapon = Instantiate(weapon, new Vector3(this.transform.position.x, this.transform.position.y + weaponPos, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Weapon>();
        }

    }
    void Update()
    {

    }
}
