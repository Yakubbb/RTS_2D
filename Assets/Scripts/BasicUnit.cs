using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : MonoBehaviour
{
    public BasicUnit[] avalibleEnemies;
    public enum Team
    {
        usec,
        bear,
        scav
    }
    public int Accuracy = 100;
    public int Hp = 100;
    public string Name;
    public Team Side;
    public int Speed;
    public Vector3 GoToPoint;
    public Inventory UnitInventory;
    BasicUnit enemy;
    public Helmet helmet;
    public BodyArmor bodyArmor;
    public Weapon weapon;
    public bool isDead;
    private bool isInventoryUpdated;

    private CircleCollider2D atackRange;

    bool IsArmed()
    {
        return weapon != null;
    }
    public void Die()
    {
        if(IsArmed()){
        UnitInventory.Drop(weapon.gameObject);
        }
        isDead = true;
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
        Hp -= damage;

    }
    void UpdateInventory()
    {
        this.helmet = UnitInventory.helmet;
        this.bodyArmor = UnitInventory.armor;
        this.weapon = UnitInventory.weapon;
    }
    void Awake()
    {
        atackRange = GetComponent<CircleCollider2D>();
        UnitInventory = GetComponent<Inventory>();
        Debug.Log("ЮНИТ СОЗДАН", this);
    }
    void Start()
    {
        GoToPoint = new Vector3(this.transform.position.x + 1, this.transform.position.y + 10, this.transform.position.z);
        if (IsArmed())
        {
            GetWeaponInIdleState();
        }

    }
    private void HandleRotation(Vector3 rotationPoint)
    {

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
            weapon.spriteRenderer.flipY = false;
        }
        else
        {
            weapon.spriteRenderer.flipY = true;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer != 6)
        {
            return;

        }
        var enemy = collision.gameObject.GetComponent<BasicUnit>();
        if (enemy == null | enemy.Side == this.Side | enemy.isDead)
        {
            if (enemy == this.enemy)
            {
                this.enemy = null;
            }
            return;
        }
        this.enemy = enemy;
        Debug.Log($"вижу врага {this.enemy.Side}");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            return;
        }
        var enemy = collision.gameObject.GetComponent<BasicUnit>();
        if (this.enemy == enemy)
        {
            this.enemy = null;
        }
    }

    void Shoot()
    {
        if (weapon.IsReadyToShoot())
        {
            bool IsHit = Random.Range(Accuracy, 100) > 70;
            if (IsHit)
            {
                enemy.TakeDamage(weapon.Damage);
                Debug.Log("попал по ", enemy);
            }
        }
    }
    void GetWeaponInIdleState()
    {
        this.weapon.transform.rotation = Quaternion.Euler(0, 0, weapon.DefaultAngle);
        this.weapon.spriteRenderer.flipY = false;
    }
    void HandleAttack()
    {
        if (IsArmed())
        {
            if (enemy == null)
            {
                Debug.Log("Врага нет", this);
                GetWeaponInIdleState();
                return;
            }
            AimAt(enemy.transform.position);
            Shoot();
        }
    }

    void Update()
    {
        if (!isInventoryUpdated)
        {
            UpdateInventory();
            isInventoryUpdated = true;
        }
        if (Hp < 1)
        {
            Die();
        }
        if (isDead)
        {
            return;
        }
        HandleMovement();
        HandleAttack();

    }
}
