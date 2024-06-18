using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public string Name;
    public int Timer;
    public int Range;
    private bool isActivated;
    private Vector3 aim;
    public void Activate(Vector3 aim)
    {
        isActivated = true;
        this.aim = aim; 
    }
    private void HandleThrowing()
    {
        if (aim == null || !isActivated)
        {
            return;
        }
        if (Vector3.Distance(this.transform.position, aim) < 2)
        {
            aim = this.transform.position;
            return;
        }
        Vector3 direction = (new Vector3(aim.x, aim.y, 0) - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * 6 * Time.deltaTime;
        this.transform.position = newPosition;
    }
    void Start()
    {

    }
    void Update()
    {
        HandleThrowing();
    }
}
