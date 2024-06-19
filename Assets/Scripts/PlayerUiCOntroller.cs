using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerUiCOntroller : MonoBehaviour
{
    public GameObject UnitInfoPanel;
    public Text Name;
    public Text Weapon;
    public Text Armor;
    public Text Helmet;
    private CameraController camera;
    private bool UnitSelected;
    private Canvas cnv;
    void Start()
    {
        cnv = GetComponentInChildren<Canvas>();
        camera = GetComponentInParent<CameraController>();
    }

    void HandleUnitInfoDIsplay()
    {
        if (UnitSelected)
        {
            UnitInfoPanel.SetActive(true);
            Name.text = camera.selectedUnit.UnitName;
            Weapon.text = camera.selectedUnit.UnitInventory.weapon != null ? camera.selectedUnit.UnitInventory.weapon.Name : "Без оружия";
            Armor.text = camera.selectedUnit.UnitInventory.armor != null ? camera.selectedUnit.UnitInventory.armor.Name : "Без брони";
            Helmet.text = camera.selectedUnit.UnitInventory.helmet != null ? camera.selectedUnit.UnitInventory.helmet.Name : "Без шлема";
        }
        else
        {
            UnitInfoPanel.SetActive(false);
        }
    }
    void Update()
    {
        UnitSelected = camera.HasSelectedUnit;
        HandleUnitInfoDIsplay();
    }
}
