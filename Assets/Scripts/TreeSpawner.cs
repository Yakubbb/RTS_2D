using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public Sprite[] possibleSprite;
    public SpriteRenderer renderer;
    void Awake()
    {
        renderer.sprite = possibleSprite[Random.Range(0,possibleSprite.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
