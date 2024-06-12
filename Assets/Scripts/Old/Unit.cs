using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Team
    {
        usec,
        bear,
        scav
    }
    public String Name;
    public Team Side;
    public int EnemyLayer;
    public int Hp;
    public int Moral;
    private Vector2 targetPosition;
    public float moveSpeed = 5f;
    public Weapon MainWeapon;
    public Helmet Helmet;
    Unit EnemyTarget;

    public bool IsArmed = false;
    public bool IsArmored = false;

    public void HandleRotation()
    {
    }
    public void ChangeHelmet(Helmet newHelmet)
    {
        if (newHelmet == null)
        {
            return;
        }
        IsArmored = true;
        Helmet = newHelmet;
    }
    public void ChangeWeapon(Weapon newWeapon)
    {
        if (newWeapon == null)
        {
            return;
        }
        IsArmed = true;
        MainWeapon = newWeapon;
        //GetComponent<CircleCollider2D>().radius = MainWeapon.Distance;
    }
    void Start()
    {
        ChangeWeapon(GetComponentInChildren<Weapon>());
        ChangeHelmet(GetComponentInChildren<Helmet>());
        targetPosition = new Vector2(this.transform.position.x + 16, this.transform.position.y - 41);
        MoveTo(targetPosition);
    }

    void Update()
    {
        MoveTo(targetPosition);
        HandleRotation();
        HandleAttack(EnemyTarget);
    }

    public void MoveTo(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        Vector2 newPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer != 6)
        {
            return;
        }
        var enemy = collision.gameObject.GetComponent<Unit>();
        if (enemy == null | enemy.Side == this.Side)
        {
            return;
        }
        EnemyTarget = enemy;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            return;
        }
        var enemy = collision.gameObject.GetComponent<Unit>();
        if(enemy == EnemyTarget){
            EnemyTarget = null;
        }
    }
    public void HandleAttack(Unit enemy)
    {
        if (EnemyTarget == null)
        {
            return;
        }
        if(!IsArmed){
            Debug.Log($"убегаю от {enemy.Side} {enemy.Name}",this);
            return;
        }
        if (EnemyTarget != enemy)
        {
            EnemyTarget = enemy;
        }
        //MainWeapon.Shoot(enemy);
    }
}
