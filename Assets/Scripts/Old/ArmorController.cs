using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : MonoBehaviour
{

    public Helmet EqHelmet;
    public SpriteRenderer Renderer;
    void Start()
    {
        EqHelmet = GetComponent<Helmet>();
    }
    void Update()
    {

    }
    public void LookRight()
    {
        Renderer.flipX = false;
        Renderer.sprite = EqHelmet.Right;
    }
    public void LookLeft()
    {
        if (EqHelmet.Left = null)
        {
            Renderer.sprite = EqHelmet.Right;
            Renderer.flipX = true;
        }
        else
        {
            Renderer.sprite = EqHelmet.Left;
        }
    }
    public void LookFront()
    {
        Renderer.flipX = false;
        Renderer.sprite = EqHelmet.Front;
    }
    public void LookBehind()
    {
        Renderer.flipX = false;
        Renderer.sprite = EqHelmet.Back;
    }
}
