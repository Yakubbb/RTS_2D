using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Armor : MonoBehaviour
{
    public float PosOnUnit;
    public Sprite Left;
    public Sprite Right;
    public Sprite Front;
    public Sprite Back;
    public SpriteRenderer SpriteRenderer;
    public string Name;
    public int Hp;
    public int ArmorClass;
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
    public void TryPenetrate(int inputDamage, out int outputDamage)
    {
        if (Hp <= inputDamage)
        {
            outputDamage = inputDamage - Hp;
            Hp = 0;
        }
        else
        {
            outputDamage = inputDamage / Random.Range(1, 10) - Hp;
            Hp -= outputDamage;
        }
    }
}
