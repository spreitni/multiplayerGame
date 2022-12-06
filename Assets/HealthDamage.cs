using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamage : MonoBehaviour
{
    public float startHealth;
    private float hp;
    public GameObject diePEffect;
    // Start is called before the first frame update
    void Start()
    {
        hp = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damange)
    {
        hp -= damange;
        if(hp <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        if(diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
