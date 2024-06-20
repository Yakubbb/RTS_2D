using System;
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
    [Range(1f, 750f)]
    public float FireRate;
    public int Range;
    public Ammo AmmoType;
    private Sprite Model;
    public SpriteRenderer spriteRenderer;
    public float LastShoot = 0;
    public float DefaultAngle;
    private float localScaleY;
    private ParticleSystem muzzleFire;
    public bool IsReadyToShoot()
    {
        if (Time.time - LastShoot > 60f / FireRate)
        {
            muzzleFire.Play();
            LastShoot = Time.time;
            return true;
        }
        return false;
    }
    public void GetWeaponInIdleState(float x)
    {
        if( Math.Abs(x) < 0.3){
            return;
        }
        if (x > 0)
        {
            MakeWeaponLookLeft();
            this.transform.rotation = Quaternion.Euler(0, 0, this.DefaultAngle);
        }
        else
        {
            MakeWeaponLookRight();
            this.transform.rotation = Quaternion.Euler(0, 0, 100f + this.DefaultAngle);
        }

    }
    public void MakeWeaponLookLeft()
    {
        var vec3 = this.transform.localScale;
        vec3.y = this.localScaleY;
        this.transform.localScale = vec3;
    }
    public void MakeWeaponLookRight()
    {
        var vec3 = this.transform.localScale;
        vec3.y = -this.localScaleY;
        this.transform.localScale = vec3;
    }
    void Awake()
    {

        muzzleFire = GetComponentInChildren<ParticleSystem>();
        muzzleFire.Stop();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Model = spriteRenderer.sprite;
        localScaleY = Math.Abs(this.transform.localScale.y);
    }
    void Start()
    {
    }
    void Update()
    {
    }
}
