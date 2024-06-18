using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitUi : MonoBehaviour
{
    UnitBody unit;
    public Slider hp;
    public Slider armor;
    public TextMeshPro UnitName;
    public TextMeshPro UnitTeam;
    void Awake()
    {
        unit = GetComponentInParent<UnitBody>();
    }

   
    void Update()
    {
        if(unit.IsDead){
            this.gameObject.SetActive(false);
        }
        UnitTeam.text = unit.UnitTeam.ToString();
        UnitName.text = unit.UnitName;
        hp.value = unit.Hp/100;
        armor.value = unit.GetArmorValue()/100;
    }
}
