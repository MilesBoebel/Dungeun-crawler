using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable {

    public float Objecthealth;


    public void TakeDamage(float Objectdamage)
    {
        Objecthealth -= Objectdamage;
        if (Objecthealth <= 0) 
        {
            Destroy(gameObject);
        }
    }
}