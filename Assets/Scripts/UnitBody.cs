using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class UnitBody : MonoBehaviour
{
    public Vector3 LookingTarget;
    public ColidersController Coliders;
    public bool IsSelected;
    public string UnitName = "aboba";
    public enum Team
    {
        usec,
        bear,
        scav,
        aboba,
        skelet
    }
    public int LastTakenDamage;
    public bool IsDead;
    public int Accuracy = 100;
    public int Hp = 100;
    public Team UnitTeam;
    public int Speed;
    public Vector3 GoToPoint;
    public Inventory UnitInventory;
    private Helmet helmet;
    private BodyArmor bodyArmor;
    private Weapon weapon;
    public DecalsSpawner Decals;
    private CircleCollider2D range;
    private PlayerController player;
    private float LastMovement;
    private float EnemySpottedTime;
    private void HandleAi()
    {
        if(player == null){
            return;
        }
        if (this.UnitTeam != player.selectedSide.team)
        {
            if (this.GoToPoint == this.transform.position && Time.time - LastMovement > 10)
            {
                float x = Random.Range(this.transform.position.x - 5, this.transform.position.x + 5);
                float y = Random.Range(this.transform.position.y - 5, this.transform.position.y + 5);
                this.GoToPoint = new Vector3(x, y, 0);
                LastMovement = Time.time - Random.Range(0,3);
            }
        }
    }
    private bool IsArmed()
    {
        return weapon != null;
    }
    private bool HasGrenades()
    {
        return UnitInventory.grenades.Count > 0;
    }
    private void Awake()
    {
        player = FindFirstObjectByType<PlayerController>();
        Decals = FindFirstObjectByType<DecalsSpawner>();
        UnitInventory = GetComponent<Inventory>();
        range = Coliders.GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        UpdateInventory();
        GoToPoint = new Vector3(this.transform.position.x, this.transform.position.y - 1, 0);
    }
    private void Update()
    {
        Coliders.ColiderTeam = this.UnitTeam;
        HandleAi();
        if (IsDead)
        {
            return;
        }
        if (Hp < 1)
        {
            Die();
        }
        UpdateInventory();
        HandleMovement();
        ControllGrenades();
        ControlWeapon();
        if (IsEnemySpotted())
        {
            LookingTarget = Coliders.enemy.transform.position;
        }
        else
        {
            LookingTarget = GoToPoint;
        }

    }
    public void TakeHeal(int amount)
    {
        if (this.Hp + amount > 100)
        {
            this.Hp = 100;
            return;
        }
        this.Hp += amount;
    }
    private void ControllGrenades()
    {
        if (HasGrenades())
        {
            if (IsEnemySpotted())
            {
                if (Coliders.enemy.IsDead) Coliders.enemy = null;
                else
                {
                    Debug.Log(Coliders.enemy.transform.position, Coliders.enemy.gameObject);
                    UnitInventory.ThrowGrenade(Coliders.enemy.transform.position);
                }
            }
        }
    }
    private void ControlWeapon()
    {
        if (!IsArmed())
        {
            return;
        }
        range.radius = this.weapon.Range;
        if (IsEnemySpotted())
        {
            if (Coliders.enemy.IsDead) Coliders.enemy = null;
            else
            {
                Debug.Log("shoot");
                AimAt(Coliders.enemy.transform.position);
                Shoot();
                
            }
        }
        else
        {
            Vector3 direction = (this.transform.position - LookingTarget).normalized;
            this.weapon.GetWeaponInIdleState(direction.x);
        }
    }
    private void UpdateInventory()
    {
        this.helmet = UnitInventory.helmet;
        this.bodyArmor = UnitInventory.armor;
        this.weapon = UnitInventory.weapon;
    }
    private void AimAt(Vector3 aim)
    {
        Vector3 direction = (this.transform.position - aim);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        if (weapon.spriteRenderer == null)
        {
            return;
        }
        if (aim.x < weapon.transform.position.x)

        {
            weapon.MakeWeaponLookLeft();
        }
        else
        {
            weapon.MakeWeaponLookRight();
        }
    }
    public void HandleMovement()
    {
        if (Vector3.Distance(this.transform.position, GoToPoint) < 0.3f)
        {
            GoToPoint = this.transform.position;
            return;
        }
        Vector3 direction = (GoToPoint - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * Speed * Time.deltaTime;
        transform.position = newPosition;
    }
    private bool IsEnemySpotted() { 
        //Debug.Log(this.Coliders.enemy);
        EnemySpottedTime = Time.time;
        return this.Coliders.enemy != null;
    }
    private void Shoot()
    {
        if (weapon.IsReadyToShoot())
        {
            bool IsHit = Random.Range(Accuracy, 100) > 70;
            if (IsHit)
            {
                Coliders.enemy.TakeDamage(weapon.Damage);
            }
        }
    }
    public void Die()
    {
        this.GetComponent<Rigidbody2D>().freezeRotation = false;
        if (Random.Range(0, 10) > 5)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (IsArmed())
        {
            UnitInventory.Drop(weapon.gameObject);
        }
        if (Decals != null)
        {
            Decals.SpawnPool(this.transform.position);
        }
        IsDead = true;
    }
    public void TakeDamage(int damage)
    {
        LastTakenDamage = damage;
        if (bodyArmor != null)
        {
            bodyArmor.TryPenetrate(damage, out LastTakenDamage);
        }
        if (helmet != null)
        {
            helmet.TryPenetrate(damage, out LastTakenDamage);
        }
        if (damage > 20)
        {
            if (Decals != null)
            {
                Decals.SpawnSplash(this.transform.position);
            }
        }
        Hp -= damage;
    }
    public float GetArmorValue()
    {
        float value = 0;
        if (this.helmet != null)
        {
            value += helmet.Hp;
        }
        if (this.bodyArmor != null)
        {
            value += bodyArmor.Hp;
        }
        return value;
    }
}
