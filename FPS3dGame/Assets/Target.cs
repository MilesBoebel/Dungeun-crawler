using UnityEngine;

public class Target : MonoBehaviour {

    public float Objecthealth = 50f;

    public void TakeDamage (float amount)
    {
        Objecthealth -= amount;
        if (Objecthealth <= 0f)
        {
            ObjectDie();
        }
    }

    void ObjectDie ()
    {
        Destroy(gameObject);
    }
}