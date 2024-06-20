using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamer : MonoBehaviour
{
    PlayerController player;
    List<UnitBody> enemies;
    public UnitSpawner spawner;
    public GameObject canvas;
    public UnitCommander UnitCommander;
    private Text text;
    void EndGame(string result, Color color){
        canvas.SetActive(true);
        text.text = result;
        text.color = color;
    }
    void Awake()
    {

        player = FindFirstObjectByType<PlayerController>();
        text = canvas.GetComponentInChildren<Text>();
        UnitCommander = FindAnyObjectByType<UnitCommander>();
    }
    void CheckIfGameEnded(){
        if(player == null){
            return;
        }
        if(!UnitCommander.IsAlive){
            EndGame("Вы проиграли", Color.red);
        }
    }
    public void LoadMenu(){
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    void Update()
    {
        CheckIfGameEnded();
    }
}
