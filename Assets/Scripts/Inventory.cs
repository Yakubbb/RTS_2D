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
    public void Drop(GameObject item)
    {
        if (item == null)
        {
            return;
        }
        GameObject droping;
        if (item == helmet.gameObject)
        {
            droping = helmet.gameObject;
            helmet = null;
        }
        else if (item == armor.gameObject)
        {
            droping = helmet.gameObject;
            armor = null;
        }
        else if (item == weapon.gameObject)
        {
            droping = weapon.gameObject;
            weapon = null;
        }
        else
        {
            return;
        }
        Instantiate(droping, new Vector3(this.transform.position.x + Random.Range(-2, 2), this.transform.position.y + +Random.Range(-2, 2), this.transform.position.z + Random.Range(-2, 2)), Quaternion.identity);
        Destroy(droping);
    }
    public void Equip(GameObject obj, bool dropOld = true)
    {
        if (obj == null)
        {
            return;
        }
        if (obj.GetComponent<Weapon>() != null)
        {
            if (dropOld) Drop(weapon.gameObject);
            this.weapon = Instantiate(obj, new Vector3(this.transform.position.x, this.transform.position.y + weaponPos, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Weapon>();
        }
        if (obj.GetComponent<Helmet>() != null)
        {
            if (dropOld) Drop(helmet.gameObject);
            this.helmet = Instantiate(obj, new Vector3(this.transform.position.x, this.transform.position.y + posOnHead, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Helmet>();
        }
        if (obj.GetComponent<BodyArmor>() != null)
        {
            if (dropOld) Drop(armor.gameObject);
            this.armor = Instantiate(obj, new Vector3(this.transform.position.x, this.transform.position.y + posOnBody, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<BodyArmor>();
        }
    }
    public void DropWeapon()
    {
        if (weapon == null)
        {
            return;
        }
        Instantiate(weapon.gameObject, new Vector3(this.transform.position.x + Random.Range(-2, 2), this.transform.position.y + +Random.Range(-2, 2), this.transform.position.z + Random.Range(-2, 2)), Quaternion.identity);
        Destroy(weapon.gameObject);
        weapon = null;
    }
    void EquipStartLoadut()
    {
        if (helmet != null)
        {
            this.Equip(helmet.gameObject, false);
        }
        if (weapon != null)
        {
            this.Equip(weapon.gameObject, false);
        }
        if (armor != null)
        {
            this.Equip(armor.gameObject, false);
        }
    }
    void Awake()
    {
        EquipStartLoadut();
    }
    void Update()
    {

    }
}
