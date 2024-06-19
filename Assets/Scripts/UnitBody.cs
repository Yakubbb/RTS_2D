using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class UnitBody : MonoBehaviour
{
    public ColidersController ColidersController;
    public bool IsSelected;
    public string UnitName = "aboba";
    public enum Team
    {
        usec,
        bear,
        scav,
        aboba
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
    private DecalsSpawner decals;
    private CircleCollider2D range;
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
        decals = FindFirstObjectByType<DecalsSpawner>();
        UnitInventory = GetComponent<Inventory>();
        range = ColidersController.GetComponent<CircleCollider2D>();
        ColidersController.ColiderTeam = this.UnitTeam;
    }
    private void Start()
    {
        UpdateInventory();
        GoToPoint = this.transform.position;
    }
    private void Update()
    {
        if (IsDead)
        {
            return;
        }
        if (Hp < 1)
        {
            Die();
        }
        HandleMovement();
        ControllGrenades();
        ControlWeapon();

    }
    private void ControllGrenades()
    {
        if (HasGrenades())
        {
            if (IsEnemySpotted())
            {
                if (ColidersController.enemy.IsDead) ColidersController.enemy = null;
                else
                {
                    Debug.Log(ColidersController.enemy.transform.position,ColidersController.enemy.gameObject);
                    UnitInventory.ThrowGrenade(ColidersController.enemy.transform.position);
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
            if (ColidersController.enemy.IsDead) ColidersController.enemy = null;
            else
            {
                AimAt(ColidersController.enemy.transform.position);
                Shoot();
            }
        }
        else
        {
            this.weapon.GetWeaponInIdleState();
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
        if (Vector3.Distance(this.transform.position, GoToPoint) < 2)
        {
            GoToPoint = this.transform.position;
            return;
        }
        Vector3 direction = (GoToPoint - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * Speed * Time.deltaTime;
        transform.position = newPosition;
    }
    private bool IsEnemySpotted() => this.ColidersController.enemy != null;
    private void Shoot()
    {
        if (weapon.IsReadyToShoot())
        {
            bool IsHit = Random.Range(Accuracy, 100) > 70;
            if (IsHit)
            {
                ColidersController.enemy.TakeDamage(weapon.Damage);
            }
        }
    }
    public void Die()
    {
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
        if (decals != null)
        {
            decals.SpawnPool(this.transform.position);
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
            if (decals != null)
            {
                decals.SpawnSplash(this.transform.position);
            }
        }
        Hp -= damage;
    }
    public float GetArmorValue(){
        float value = 0;
        if(this.helmet != null){
            value+=helmet.Hp;
        }
        if(this.bodyArmor != null){
            value+=bodyArmor.Hp;
        }
        return value;
    }
}
