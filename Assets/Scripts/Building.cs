using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject SpecialUnit;
    public int UnitsLast;
    public GameObject GetSpecialUnit()
    {
        if (UnitsLast > 0)
        {
            UnitsLast--;
            return SpecialUnit;
        }
        else return null;
    }
    void Update(){
        text.text = UnitsLast.ToString();
    }
}
