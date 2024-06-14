using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplash : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Sprite[] Sprites;
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = Sprites[Random.Range(0, Sprites.Length)];
    }
}
