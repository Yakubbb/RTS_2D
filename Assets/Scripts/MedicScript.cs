using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicScript : MonoBehaviour
{
    public SpriteRenderer AidKit;
    public int Skill = 100;
    public int Delay = 3;
    UnitBody mainAi;
    public HealColiderController controller;
    public UnitBody HealTarget;
    private float LastTimeHeal = 0;
    private bool IsHealing;
    void Start()
    {
        mainAi = GetComponent<UnitBody>();
    }
    void Heal()
    {
        if (HealTarget == null)
        {
            IsHealing = false;
            return;
        }
        if (HealTarget.IsDead)
        {
            IsHealing = false;
            return;
        }
        if (HealTarget.UnitTeam != mainAi.UnitTeam)
        {
            IsHealing = false;
            return;
        }
        if (Time.time - LastTimeHeal > Delay)
        {
            IsHealing = true;
            HealTarget.TakeHeal(Random.Range(0, Skill));
            Debug.Log("Отхил", HealTarget);
            if (mainAi.Decals != null)
            {
                HealTarget.Decals.SpawnMedGarbage(HealTarget.transform.position);
            }
            LastTimeHeal = Time.time;
        }
    }
    void ControllAidKitVisual()
    {
        if (AidKit != null)
        {
            if (IsHealing)
            {
                AidKit.enabled = true;
            }
            else
            {
                AidKit.enabled = false;
            }
        }
    }
    void Update()
    {
        if (controller.healTarget != null)
        {
            this.HealTarget = controller.healTarget;
        }
        ControllAidKitVisual();
        Heal();
    }

}
