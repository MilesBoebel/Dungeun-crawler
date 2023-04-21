using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gun : MonoBehaviour 
{

    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cam;
    public ParticleSystem muzzleflash;
    private string slash;
    
    
    float timeSinceLastShot;

    public Animator animator;
    public AudioSource audioSource;
    public TextMeshProUGUI ammoDisplay;
    

    private void Start() 
    {
        slash = "/";
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
        gunData.currentAmmo = gunData.magSize;
        ammoDisplay.text = gunData.currentAmmo.ToString()+ slash + gunData.magSize;
    }

    void onEnable ()
    {
        gunData.reloading = false;
        animator.SetBool("Reloading", false);
    }

    private void OnDisable() => gunData.reloading = false;

    public void StartReload() 
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload() 
    {
        gunData.reloading = true;

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(gunData.reloadTime - .3f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.3f);

        gunData.currentAmmo = gunData.magSize;
        ammoDisplay.text = gunData.currentAmmo.ToString()+ slash + gunData.magSize;

        gunData.reloading = false;
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void Shoot() 
    {

        if (gunData.currentAmmo > 0) 
        {
            if (CanShoot())
                {
                if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance)){
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.Objectdamage);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                audioSource.Play();
                OnGunShot();
                ammoDisplay.text = gunData.currentAmmo.ToString()+ slash + gunData.magSize;
            }
        }
    }

    private void Update() 
    {

        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);

        if(gunData.currentAmmo <= 0)
        {
            StartReload();
        }
    }

    private void OnGunShot() 
    { 
        muzzleflash.Play();
    }
}
