using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerUiCOntroller : MonoBehaviour
{
    public TMPro.TMP_Dropdown Ars;
    public TMPro.TMP_Dropdown Pistols;
    public TMPro.TMP_Dropdown Rifles;
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
    public void HandleUnitInfoDIsplay()

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
    public void HandlePlayerInfo()
    {
        if (player != null)
        {
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
    public void SpawnAr()
    {
        switch (Ars.value)
        {
            case 0:
                player.selectedSide.SpawnLowAR(player.SpawnPoint,Random.Range(10,30),NamesProvider.GetRandomName());
                break;
            case 1:
                player.selectedSide.SpawnMidAR(player.SpawnPoint,Random.Range(36,65),NamesProvider.GetRandomName());
                break;
            case 2:
                player.selectedSide.SpawnHighAR(player.SpawnPoint,Random.Range(64,110),NamesProvider.GetRandomName());
                break;
        }
    }
    public void SpawnPistol()
    {
        switch (Pistols.value)
        {
            case 0:
                player.selectedSide.SpawnLowPistol(player.SpawnPoint,Random.Range(10,30),NamesProvider.GetRandomName());
                break;
            case 1:
                player.selectedSide.SpawnMidPistol(player.SpawnPoint,Random.Range(36,65),NamesProvider.GetRandomName());
                break;
            case 2:
                player.selectedSide.SpawnHighPistol(player.SpawnPoint,Random.Range(64,110),NamesProvider.GetRandomName());
                break;
        }

    }
    public void SpawnRifle()
    {
        switch (Rifles.value)
        {
            case 0:
                player.selectedSide.SpawnLowSniper(player.SpawnPoint,Random.Range(10,30),NamesProvider.GetRandomName());
                break;
            case 1:
                player.selectedSide.SpawnMidSniper(player.SpawnPoint,Random.Range(36,65),NamesProvider.GetRandomName());
                break;
            case 2:
                player.selectedSide.SpawnHighSniper(player.SpawnPoint,Random.Range(64,110),NamesProvider.GetRandomName());
                break;
        }

    }
}
