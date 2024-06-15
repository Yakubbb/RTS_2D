using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Ammo
    {
        NATO556,
        NATO76251,
        SOVI76239
    }
    public string Name;
    public int Damage;
    public int FireRate;
    public int Range;
    public Ammo AmmoType;
    public Sprite Model;
    public SpriteRenderer spriteRenderer;
    public float LastShoot = 0;
    public float DefaultAngle;
    public GameObject shootingPoint = null;
    private int interval;
    public bool IsReadyToShoot()
    {
        if (Time.time - LastShoot > interval)
        {
            if (shootingPoint != null)
            {
                shootingPoint.SetActive(true);
            }
            LastShoot = Time.time;
            return true;
        }
        return false;
    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        interval = 60 / FireRate;
    }
    void Update()
    {
        if (Time.time - LastShoot > 1)
        {
            if (shootingPoint != null)
            {
                shootingPoint.SetActive(false);
            }
        }

    }
}
