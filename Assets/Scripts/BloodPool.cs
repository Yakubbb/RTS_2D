using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPool : MonoBehaviour
{
    public GameObject Particles;
    public SpriteRenderer Renderer;
    public Sprite[] Sprites;
    public float SpawnTime;
    public bool ItsProcessing = false;
    public void SpawnBloodPool()
    {
        ItsProcessing = true;
        Particles = Instantiate(Particles,this.transform.position,Quaternion.identity);
    }
    void HandlePool()
    {
        if (ItsProcessing)
        {
            Vector3 newScale = this.transform.localScale;
            if (newScale.x <= 1)
            {
                newScale.x += 0.0001f;
            }
            if (newScale.y <= 1)
            {
                newScale.y += 0.0001f;
            }
            this.transform.localScale = newScale;
            if(newScale.x >= 1 && newScale.y>=1){
                ItsProcessing = false;
                Destroy(Particles);
            }
        }
    }
    void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();
        Renderer.sprite = Sprites[Random.Range(0, Sprites.Length)];
        this.transform.localScale = Vector3.zero;
    }
    void Update()
    {
        HandlePool();
    }
}
