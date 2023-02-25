using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    private float ObjectHealth = 100f;


    public void ObjectDamage(float objectDamage)
    {
        ObjectHealth -= objectDamage;
        if (ObjectHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        Debug.Log(ObjectHealth);
    }
}
