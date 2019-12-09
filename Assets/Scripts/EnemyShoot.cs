using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyShoot : MonoBehaviour
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

    private float shootTime = 0.5f;
    private float reloadTime = 0.5f;

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
        if(shootTime > 0)
        {
            FireBullet();
            shootTime -= Time.deltaTime;
        }
        shootTime = reloadTime;
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
