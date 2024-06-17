using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBody : MonoBehaviour
{
    public enum Team
    {
        usec,
        bear,
        scav,
    }
    public bool IsDead;
    public int Accuracy = 100;
    public int Hp = 100;
    public Team Side;
    public int Speed;
    public Vector3 GoToPoint;
    public Inventory UnitInventory;
    private Helmet helmet;
    private BodyArmor bodyArmor;
    private Weapon weapon;
    private DecalsSpawner decals;
    private ColidersController colidersController;
    private CircleCollider2D range;
    private bool IsArmed()
    {
        return weapon != null;
    }
    private void Awake()
    {
        decals = FindFirstObjectByType<DecalsSpawner>();
        UnitInventory = GetComponent<Inventory>();
        colidersController = GetComponentInChildren<ColidersController>();
        range = colidersController.GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        UpdateInventory();
        GoToPoint = new Vector3(this.transform.position.x + 1, this.transform.position.y + 10, this.transform.position.z);
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
        ControlWeapon();

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
            if (colidersController.enemy.IsDead) colidersController.enemy = null;
            else
            {
                AimAt(colidersController.enemy.transform.position);
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
    private bool IsEnemySpotted() => this.colidersController.enemy != null;
    private void Shoot()
    {
        if (weapon.IsReadyToShoot())
        {
            bool IsHit = Random.Range(Accuracy, 100) > 70;
            if (IsHit)
            {
                colidersController.enemy.TakeDamage(weapon.Damage);
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
        int lastDamage = damage;
        if (bodyArmor != null)
        {
            bodyArmor.TryPenetrate(damage, out lastDamage);
        }
        if (helmet != null)
        {
            helmet.TryPenetrate(damage, out lastDamage);
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
}
