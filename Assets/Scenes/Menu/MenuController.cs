using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public GameObject settings;
    public GameObject maps;
    public GameObject main;
    public GameObject BloodObject;
    public AudioMixer mixer;
    public void HandleBlood(bool value){
        BloodObject.SetActive(value);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void OpenSetting()
    {
        main.SetActive(false);
        maps.SetActive(false);
        settings.SetActive(true);
    }
    public void BackToMain()
    {
        main.SetActive(true);
        maps.SetActive(false);
        settings.SetActive(false);
    }
    public void OpenMaps()
    {
        main.SetActive(false);
        maps.SetActive(true);
        settings.SetActive(false);
    }
    void Start()
    {
        BackToMain();
    }
    void Update()
    {


    }
}
