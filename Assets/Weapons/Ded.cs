using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ded : MonoBehaviour
{
    public AudioSource[] pharw;
    private float lastUpdate;
    void Awake(){
        GetComponent<UnitBody>().UnitName = "Босс развилки";
    }
    void Update()
    {
        
        if (Time.time - lastUpdate > 6)
        {
            int a = Random.Range(0, 100);
            if (a > 90)
            {
                Debug.Log("смех");
                pharw[Random.Range(0, pharw.Length)].Play();
                lastUpdate = Time.time;
            }
        }
    }
}
