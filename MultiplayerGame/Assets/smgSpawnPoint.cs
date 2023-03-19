using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class smgSpawnPoint : MonoBehaviourPunCallbacks

{
    public Rigidbody Projectile;
    //public float speed = 20;
    public float shootForce;
    public Camera fpsCam;
    public Transform attackPoint;
    public GameObject pauseMenu;
    public float  spread;
    public float fireRate = .05F;
    public float nextFire = 0.0F;
    public int smgAmmo = 100;
    public float reloadIntervalSmg = 3.0f;
    public TMPro.TMP_Text ammoTotal;
    // Start is called before the first frame update
    void Start()
    {   
        if(photonView.IsMine)
        {
        ammoTotal.text = smgAmmo.ToString() + " / 100";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(smgAmmo);
         if(photonView.IsMine)
        {
        if(pauseMenu.activeSelf == false)
        {  
        if (Input.GetMouseButton(0)&& Time.time > nextFire)  //fix this
        {
            nextFire =  Time.time +  fireRate;
            if(smgAmmo >= 1)
            {
                Shoot();
            }
            /*else
            {
                StartCoroutine(reload(reloadIntervalSmg));
            }*/
            //Rigidbody instantiatedProjectile = Instantiate(Projectile,transform.position,transform.rotation) as Rigidbody;
            //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0,0,speed));
        }
        }
        if(smgAmmo== 0)
        {
            StartCoroutine(reload(reloadIntervalSmg));
        }
        /*else{
            StartCoroutine(reload(reloadIntervalSmg));
        }*/
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
        //this.smgAmmo = subtractAmmo(this.smgAmmo);
        //string spammmm = spamm.ToString();
        //ammoForHud.text = spammmm;
        smgAmmo--;
        ammoTotal.text = smgAmmo.ToString() + " / 100";
        
        //ammoTotal.text = smgAmmo.ToString();
    }
    private IEnumerator reload(float reloadIntervalSmg)
    {
        yield return new WaitForSeconds(reloadIntervalSmg);
        if(photonView.IsMine)
        {
        smgAmmo = 100;
        ammoTotal.text = smgAmmo.ToString() + " / 100";
        }
    }

    /*
    public int subtractAmmo(int ammoAmount)
    {
        ammoAmount--;
        return ammoAmount;
    }
    public int getSMGAmmo()
    {
        return this.smgAmmo;
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ZombiePrefab")
        {
             // do damage here, for example:
             collision.gameObject.GetComponent<zombieMovement>().TakeDamage(5);
        }
    }
}
