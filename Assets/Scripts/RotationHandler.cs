using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    public Sprite Left;
    public Sprite Right;
    public Sprite Front;
    public Sprite Back;
    public SpriteRenderer SpriteRenderer;
    public void LookRight()
    {
        SpriteRenderer.flipX = false;
        SpriteRenderer.sprite = Right;
    }
    public void LookLeft()
    {
        if (Left == null)
        {
            SpriteRenderer.sprite = Right;
            SpriteRenderer.flipX = true;
        }
        else
        {
            SpriteRenderer.sprite = Left;
        }
    }
    public void LookFront()
    {
        SpriteRenderer.flipX = false;
        SpriteRenderer.sprite = Front;
    }
    public void LookBehind()
    {
        SpriteRenderer.flipX = false;
        SpriteRenderer.sprite = Back;
    }

    void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }
}
