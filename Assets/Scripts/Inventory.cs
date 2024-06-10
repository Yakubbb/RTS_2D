using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Helmet helmet;
    public Helmet toTake;
    public float posOnHead =1.1f;
    void TakeHelmet(Helmet takenHelmet ){
        if(this.helmet != null){
            DestroyImmediate(helmet.gameObject,true);
        }
        Instantiate(takenHelmet.gameObject, new Vector3(this.transform.position.x,this.transform.position.y+posOnHead,this.transform.position.z),Quaternion.identity,this.transform);
        this.helmet = takenHelmet;

    }
    void TakeArmor(GameObject Armor ){

    }
    void Start()
    {
            TakeHelmet(this.toTake);
        
    }
    void Update()
    {
        
    }
}
