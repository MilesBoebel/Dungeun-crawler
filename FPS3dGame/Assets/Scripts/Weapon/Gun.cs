
using UnityEngine;

public class Gun : MonoBehaviour 
{   
    private InputManager inputManager;

    public Camera fpsCam;

    public float damage = 10f;
    public float range = 100f;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    void Update ()
    {
        if (inputManager.onFoot.Shoot.triggered)
        {
            Shoot(); 
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
