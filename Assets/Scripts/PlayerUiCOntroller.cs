using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerUiCOntroller : MonoBehaviour
{
    public Canvas specialUnitCanvas;
    public GameObject[] buildingsObjects;
    public TMPro.TMP_Dropdown buildings;
    public TMPro.TMP_Dropdown Ars;
    public TMPro.TMP_Dropdown Pistols;
    public TMPro.TMP_Dropdown Rifles;
    public PlayerController player;
    public Text PlayerLvl;
    public Text PlayerMoney;
    public Text UnitCount;
    public GameObject UnitInfoPanel;
    public Text Name;
    public Text Weapon;
    public Text Armor;
    public Text Helmet;
    private CameraController camera;
    private bool UnitSelected;
    private Canvas cnv;

    private Color armorDefColor;
    private Color helmetDefColor;
    private Color weaponDefColor;
    private Building currentBuilding;
    private void HandleSpecialUnitInfo(){
        if(currentBuilding == null || currentBuilding.UnitsLast < 1){
            specialUnitCanvas.enabled = false;
        }
        else{
            specialUnitCanvas.enabled = true;
        }
    }
    public void SpawnBuilding(){
        if(currentBuilding != null){
            Destroy(currentBuilding.gameObject);
            currentBuilding = null;
        }
        currentBuilding = Instantiate(buildingsObjects[buildings.value],player.BuildingSpawnPoint,Quaternion.identity).GetComponent<Building>();
    }
    void Awake()
    {
        player = GetComponentInParent<PlayerController>();
        cnv = GetComponentInChildren<Canvas>();
        camera = GetComponentInParent<CameraController>();

        armorDefColor =  Armor.color;
        helmetDefColor = Helmet.color;
        weaponDefColor = Weapon.color;
    }
    public void HandleUnitInfoDIsplay()

    {
        if (UnitSelected)
        {
            UnitInfoPanel.SetActive(true);
            Name.text = camera.selectedUnit.UnitName;
            if (camera.selectedUnit.UnitInventory.weapon != null)
            {
                Weapon.text = camera.selectedUnit.UnitInventory.weapon.Name;
            }
            else
            {
                Weapon.text =  "Безоружный";
            }
            if (camera.selectedUnit.UnitInventory.armor != null)
            {
                Armor.text = camera.selectedUnit.UnitInventory.armor.Name;
            }
            else
            {
                Armor.text = "Брони нет";
            }
            if (camera.selectedUnit.UnitInventory.helmet != null)
            {
                Helmet.text = camera.selectedUnit.UnitInventory.helmet.Name;
            }
            else
            {
                Helmet.text = "Шлема нет";
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
            UnitCount.text = player.UnitsKolvo.ToString();
            PlayerLvl.text = player.Lvl.ToString();
            PlayerMoney.text = player.Money.ToString();
        }
    }
    void Update()
    {
        UnitSelected = camera.HasSelectedUnit;
        HandlePlayerInfo();
        HandleUnitInfoDIsplay();
        HandleSpecialUnitInfo();
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
    public void SpawnUnitFromBuilding(){
        if(currentBuilding == null || currentBuilding.UnitsLast < 1){
            return;
        }
        UnitBody newUnit = Instantiate(currentBuilding.GetSpecialUnit(), player.SpawnPoint, Quaternion.identity).GetComponentInChildren<UnitBody>();
        newUnit.UnitTeam = player.selectedSide.team;
        newUnit.UnitName = NamesProvider.GetRandomName();
    }
}
