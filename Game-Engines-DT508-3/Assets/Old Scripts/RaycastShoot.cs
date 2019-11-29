using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

    private AudioSource gunAudio;
    //public GUISkin myOtherSkin;

    //Animator anim;
    bool shoot;

    public int fullAmmo = 9;
    public int currentAmmo = -1;
    public float reloadTime = 1.77f;
    private bool isReloading = false;

    public int gunDamage = 1;
    private float fireRate = 0.35f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
    private LineRenderer laserLine;
    private float nextFire;
    //public ParticleSystem muzzleFlash;
    public int shotPointValue = 10;

    void Start()
    {
        if (currentAmmo == -1)
        {
            currentAmmo = fullAmmo;
        }
        //anim = gameObject.GetComponentInChildren<Animator>();
        shoot = false;
        //gunAudio = GetComponent<AudioSource>();

        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponent<Camera>();
    }


    void Update()
    {
        if(isReloading)
        {
            return;
        }

        if (Input.GetButtonDown("Reload") && currentAmmo < fullAmmo)
            {
            //StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {

            if (currentAmmo <= 0)
            {
                //StartCoroutine(Reload());
                return;
            }
            nextFire = Time.time + fireRate;
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            currentAmmo--;

            shoot = true;


            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                //muzzleFlash.Play();
                laserLine.SetPosition(1, hit.point);
                Debug.Log(hit.transform.name);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if(target != null)
                {
                    target.TakeDamage(gunDamage);
                    GameManagement.AddPoints(shotPointValue);

                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
        else
        {
            shoot = false;
        }

        /*if (shoot == true)
        {
            anim.SetBool("shoot", true);
            gunAudio.Play();
            shoot = false;
        }

        else if (shoot == false)
        {
            anim.SetBool("shoot", false);
        }       */
    }

    /*IEnumerator Reload()
    {
        isReloading = true;
        //Debug.Log("Reload");
        anim.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        anim.SetBool("Reloading", false);
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = fullAmmo;
        isReloading = false;
    }

    /*void OnGUI()
    {
        GUI.skin = myOtherSkin;
        GUIStyle style = myOtherSkin.customStyles[0];

        GUI.Label(new Rect(50, Screen.height - 200, 150, 50), "A M M O :  ");
        GUI.Label(new Rect(200, Screen.height - 200, 130, 50), "" + currentAmmo + "  /  9");

    }*/
}