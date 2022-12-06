using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamange : MonoBehaviour

{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name != "Player")
        {
           if(collisionGameObject.GetComponent<HealthDamage>() != null)
           {
            collisionGameObject.GetComponent<HealthDamage>().TakeDamage(damage);
            Debug.Log("taken damage");
           } 
           
        }
    }
}
