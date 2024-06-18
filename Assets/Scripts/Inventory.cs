using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<Explosive> grenades = new();
    public void ThrowGrenade(Vector3 aim)
    {
        if(grenades.Count < 1){
            return;
        }
        Explosive grenade = grenades.ElementAt(Random.Range(0,grenades.Count));
        float x = aim.x + Random.Range(-1, 1);
        float y = aim.y + Random.Range(-1, 1);
        Instantiate(grenade,this.transform.position,Quaternion.identity).Activate(new Vector3(x,y,0));
        grenades.Remove(grenade);

    }
    public void Drop(GameObject item)
    {
        if (item == null)
        {
            return;
        }
        GameObject droping;
        if (helmet != null && item == helmet.gameObject)
        {
            droping = helmet.gameObject;
            helmet = null;
        }
        else if (armor != null && item == armor.gameObject)
        {
            droping = armor.gameObject;
            armor = null;
        }
        else if (weapon != null && item == weapon.gameObject)
        {
            droping = weapon.gameObject;
            weapon = null;
        }
        else
        {
            return;
        }
        Instantiate(droping, new Vector3(this.transform.position.x + Random.Range(-1.5f, 1.5f), this.transform.position.y + +Random.Range(-1.5f, 1.5f), this.transform.position.z + Random.Range(-2, 2)), Quaternion.identity);
        Destroy(droping);
    }
    public void Equip(GameObject obj, bool dropOld = true)
    {
        if (obj == null)
        {
            return;
        }
        if(obj.GetComponent<Explosive>() != null){
            grenades.Add(obj.GetComponent<Explosive>());
        }
        if (obj.GetComponent<Weapon>() != null)
        {
            if (weapon != null && dropOld) Drop(weapon.gameObject);
            this.weapon = Instantiate(obj, new Vector3(this.transform.position.x, this.transform.position.y + weaponPos, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Weapon>();
        }
        if (obj.GetComponent<Helmet>() != null)
        {
            if (helmet != null && dropOld) Drop(helmet.gameObject);
            this.helmet = Instantiate(obj, new Vector3(this.transform.position.x, this.transform.position.y + obj.GetComponent<Armor>().PosOnUnit, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Helmet>();
        }
        if (obj.GetComponent<BodyArmor>() != null)
        {
            if (armor != null && dropOld) Drop(armor.gameObject);
            this.armor = Instantiate(obj, new Vector3(this.transform.position.x, this.transform.position.y + obj.GetComponent<Armor>().PosOnUnit, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<BodyArmor>();
        }
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
