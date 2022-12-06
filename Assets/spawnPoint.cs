using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class spawnPoint : MonoBehaviourPunCallbacks
{
    public Rigidbody Projectile;
    //public float speed = 20;
    public float shootForce;
    public float timeBetweenShooting, reloadTime, TimeBetwenShots;
    public int magSize, BulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft,bulletsShot;
    public GameObject pauseMenu;
    public Camera fpsCam;
    public Transform attackPoint;
    public float  spread;
    public TMPro.TMP_Text ammoTotal;
    public int pistolAmmo = 12;
    bool shooting, readyToShoot, Reloading;
    public float reloadIntervalPistol = 1.0f;
    // Start is called before the first frame update
    void Start()
    {   if(photonView.IsMine)
        {
        ammoTotal.text = pistolAmmo.ToString() + " / 12 ";
        }
    }

    // Update is called once per frame
    void Awake()
    {
        bulletsLeft = magSize;
        readyToShoot = true;
    }
    void Update()
    {
         if(photonView.IsMine)
        {   
        if(pauseMenu.activeSelf == false)
        {
        if (Input.GetMouseButtonDown(0))
        {
            if(pistolAmmo >= 1)
            {
                Shoot();
            }
            /*else{
                StartCoroutine(reload(reloadIntervalPistol));
            }*/
            
            //Rigidbody instantiatedProjectile = Instantiate(Projectile,transform.position,transform.rotation) as Rigidbody;
            //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0,0,speed));
        }
        }
        if(pistolAmmo == 0)
        {
            StartCoroutine(reload(reloadIntervalPistol));
        }
        } 
    }




    private void Shoot()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
        Rigidbody instantiatedProjectile = Instantiate(Projectile,attackPoint.position,Quaternion.identity) as Rigidbody;
        instantiatedProjectile.transform.forward = directionWithSpread.normalized;
        instantiatedProjectile.AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        pistolAmmo--;
        ammoTotal.text = pistolAmmo.ToString() + " / 12 ";
    }
    private IEnumerator reload(float reloadIntervalPistol)
    {
        yield return new WaitForSeconds(reloadIntervalPistol);
        if(photonView.IsMine)
        {
            pistolAmmo = 12;
            ammoTotal.text = pistolAmmo.ToString() + " / 12 ";
        }
    }




}
