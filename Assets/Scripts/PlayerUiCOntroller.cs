using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerUiCOntroller : MonoBehaviour
{
    public PlayerController player;
    public Text PlayerLvl;
    public Text PlayerMoney;



    public GameObject UnitInfoPanel;
    public Text Name;
    public Text Weapon;
    public Text Armor;
    public Text Helmet;
    private CameraController camera;
    private bool UnitSelected;
    private Canvas cnv;
    void Awake()
    {
        player = GetComponentInParent<PlayerController>();
        cnv = GetComponentInChildren<Canvas>();
        camera = GetComponentInParent<CameraController>();
    }
    void HandleUnitInfoDIsplay()

    {
        if (UnitSelected)
        {
            UnitInfoPanel.SetActive(true);
            Name.text = camera.selectedUnit.UnitName;
            if (camera.selectedUnit.UnitInventory.weapon != null)
            {
                Weapon.color = Color.green;
                Weapon.text = "~" + camera.selectedUnit.UnitInventory.weapon.Name;
            }
            else
            {
                Weapon.color = Color.red;
                Weapon.text = "~" + "No weapon";
            }
            if (camera.selectedUnit.UnitInventory.weapon != null)
            {
                Armor.color = Color.green;
                Armor.text = "~" + camera.selectedUnit.UnitInventory.armor.Name;
            }
            else
            {
                Armor.color = Color.red;
                Armor.text = "~" + "No armor";
            }
            if (camera.selectedUnit.UnitInventory.helmet != null)
            {
                Helmet.color = Color.green;
                Helmet.text = "~" + camera.selectedUnit.UnitInventory.helmet.Name;
            }
            else
            {
                Helmet.color = Color.red;
                Helmet.text = "~" + "No helmet";
            }
        }
        else
        {
            UnitInfoPanel.SetActive(false);
        }
    }
    public void HandlePlayerInfo(){
        if(player != null){
            PlayerLvl.text = player.Lvl.ToString();
            PlayerMoney.text = player.Money.ToString();
        }
    }
    void Update()
    {
        UnitSelected = camera.HasSelectedUnit;
        HandlePlayerInfo();
        HandleUnitInfoDIsplay();
    }
}
