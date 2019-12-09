using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletScript : MonoBehaviour
{
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;   //what is being fired from the gun

    //Enter the Speed of the Bullet from the Component Inspector.
    public float BulletForce = 100.0f;  //value of the force being applied to the bullet

    //Destroy time (time the bullet lasts onscreen)
    public float destroyTime = 3.0f;    //(bullet gets destroyed after 3 seconds)

    AudioSource gunfire;
    private ParticleSystem gunEffect;

    private bool RT_used = false;

    // Start is called before the first frame update
    void Start()
    {
        gunfire = GetComponent<AudioSource>();
        //gunEffect = GameObject.Find("Bullet").GetComponent<ParticleSystem>();
        gunEffect = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    { 
        //fires the bullet
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
        if (Input.GetAxis("Fire1") != 0)
        {
            if (RT_used == false)
            {
                FireBullet();
            }
            RT_used = true;
        }
        if (Input.GetAxis("Fire1") == 0)
        {
            RT_used = false;
        }
    }

    private void FireBullet()
    {
         
        //create a bullet instance
        GameObject currentBullet = Instantiate(Bullet, this.transform.position, new Quaternion(90.0f, 0f, 0f, 100f)) as GameObject;
        //fix scale
        currentBullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        //currentBullet.transform.rotation = new Quaternion(90f, 0f, 0f, 100f);

        //add force to shoot
        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);
        gunfire.Play();
        gunEffect.Play();
        //Destroy it after a certain time
        Destroy(currentBullet, destroyTime);
    }
}
