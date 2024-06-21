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
    void EndGame(string result, Color color)
    {
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
    void CheckIfGameEnded()
    {
        if (player == null)
        {
            return;
        }
        if (FindObjectsByType<UnitBody>(FindObjectsSortMode.None).Where(u => u.UnitTeam == player.selectedSide.team).Count(u => !u.IsDead) < 1)
        {
            EndGame("Вы проиграли", Color.red);
        }
        if (FindObjectsByType<UnitBody>(FindObjectsSortMode.None).Where(u => u.UnitTeam != player.selectedSide.team).Count(u => !u.IsDead) < 1)
        {
            EndGame("Вы выиграли", Color.green);
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
        CheckIfGameEnded();
    }
}
