using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Con.Kawaiisun.SimpHostile
{
    public class Gun : MonoBehaviour {

        [Header("References")]
        [SerializeField] private GunData gunData;
        [SerializeField] private Transform cam;
        public ParticleSystem muzzleflash;
        
        float timeSinceLastShot;

        public Animator animator;


        private void Start() {
            PlayerShoot.shootInput += Shoot;
            PlayerShoot.reloadInput += StartReload;
        }

        void onEnable ()
        {
            gunData.reloading = false;
            animator.SetBool("Reloading", false);
        }

        private void OnDisable() => gunData.reloading = false;

        public void StartReload() {
            if (!gunData.reloading && this.gameObject.activeSelf)
                StartCoroutine(Reload());
        }

        private IEnumerator Reload() {
            gunData.reloading = true;

            animator.SetBool("Reloading", true);

            yield return new WaitForSeconds(gunData.reloadTime - .3f);
            animator.SetBool("Reloading", false);
            yield return new WaitForSeconds(.3f);

            gunData.currentAmmo = gunData.magSize;

            gunData.reloading = false;
        }

        private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

        private void Shoot() {

            if (gunData.currentAmmo > 0) {
                if (CanShoot())
                    {
                    if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance)){
                        IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                        damageable?.TakeDamage(gunData.Objectdamage);
                    }

                    gunData.currentAmmo--;
                    timeSinceLastShot = 0;
                    OnGunShot();
                }
            }
        }

        private void Update() {

            timeSinceLastShot += Time.deltaTime;

            Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);

            if(gunData.currentAmmo <= 0)
            {
                StartReload();
            }
        }

        private void OnGunShot() { 
            muzzleflash.Play();
        }
    }
}