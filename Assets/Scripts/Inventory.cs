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
    public void TakeHelmet(Helmet takenHelmet)
    {
        if (this.helmet != null)
        {
            DropHelmet();
        }
        this.helmet = Instantiate(takenHelmet.gameObject, new Vector3(this.transform.position.x, this.transform.position.y + posOnHead, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Helmet>();
    }
    public void TakeWeapon(Weapon takedWeapon)
    {
        if (this.weapon != null)
        {
            Destroy(weapon.gameObject);
        }
        this.weapon = Instantiate(takedWeapon.gameObject, new Vector3(this.transform.position.x, this.transform.position.y + posOnHead, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Weapon>();
    }
    public void TakeArmor(Armor takenArmor)
    {
        DropArmor();
        this.armor = Instantiate(takenArmor.gameObject, new Vector3(this.transform.position.x, this.transform.position.y + posOnHead, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<BodyArmor>();
    }
    public void DropHelmet()
    {
        if (helmet == null)
        {
            return;
        }
        Instantiate(helmet.gameObject, new Vector3(this.transform.position.x + Random.Range(-2, 2), this.transform.position.y + +Random.Range(-2, 2), this.transform.position.z + Random.Range(-2, 2)), Quaternion.identity);
        Destroy(Instantiate(helmet.gameObject));
        helmet = null;
    }
    public void DropArmor()
    {
        if (armor == null)
        {
            return;
        }
        Instantiate(armor.gameObject, new Vector3(this.transform.position.x + Random.Range(-2, 2), this.transform.position.y + +Random.Range(-2, 2), this.transform.position.z + Random.Range(-2, 2)), Quaternion.identity);
        Destroy(Instantiate(armor.gameObject));
        armor = null;
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
    void Start()
    {
        if (helmet != null)
        {
            helmet = Instantiate(helmet, new Vector3(this.transform.position.x, this.transform.position.y + posOnHead, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<Helmet>();
        }
        if (armor != null)
        {
            armor = Instantiate(armor, new Vector3(this.transform.position.x, this.transform.position.y + posOnBody, this.transform.position.z), Quaternion.identity, this.transform).GetComponent<BodyArmor>();
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
