using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePreset : MonoBehaviour
{
    private GameObject getRandomUnit(GameObject[] mas)
    {
        if (mas.Length == 0)
        {
            return null;
        }
        return mas[Random.Range(0,mas.Length)];
    }
    public GameObject[] NoobUnitsWithPistol;
    public GameObject[] NoobUnitsWithAR;
    public GameObject[] NoobUnitsWithSniper;

    public GameObject[] NormalUnitsWithPistol;
    public GameObject[] NormalUnitsWithAR;
    public GameObject[] NormalUnitsWithSniper;

    public GameObject[] ProsbUnitsWithPistol;
    public GameObject[] ProsbUnitsWithAR;
    public GameObject[] ProsbUnitsWithSniper;


}
