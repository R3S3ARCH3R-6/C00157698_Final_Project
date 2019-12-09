﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference:
//https://forum.unity.com/threads/how-can-i-make-a-enemy-shoot-script.211639/
//https://learn.unity.com/tutorial/quaternions#5c8945d0edbc2a14103553dc

[RequireComponent(typeof(AudioSource))]
public class EnemyShoot : MonoBehaviour
{
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;   //what is being fired from the gun

    //Enter the Speed of the Bullet from the Component Inspector.
    public float BulletForce = 100.0f;  //value of the force being applied to the bullet

    //Destroy time (time the bullet lasts onscreen)
    public float destroyTime = 3.0f;    //(bullet gets destroyed after 3 seconds)
    public bool shoot = false;

    AudioSource gunfire;
    private ParticleSystem gunEffect;

    private bool RT_used = false;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        gunfire = GetComponent<AudioSource>();
        //gunEffect = GameObject.Find("Bullet").GetComponent<ParticleSystem>();
        gunEffect = GetComponent<ParticleSystem>();
    }

    public void FireBullet()
    {
        Vector3 aim = transform.position - player.transform.position;
        transform.rotation = Quaternion.LookRotation(aim);
        
        //create a bullet instance
        GameObject currentBullet = Instantiate(Bullet, this.transform.position, new Quaternion(90.0f, 0f, 0f, 100f)) as GameObject;
        //fix scale
        currentBullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        //currentBullet.transform.rotation = new Quaternion(90f, 0f, 0f, 100f);

        //add force to shoot
        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);
        //StartCoroutine(ReloadDelay(reloadTime));
        gunfire.Play();
        gunEffect.Play();
        //Destroy it after a certain time
        Destroy(currentBullet, destroyTime);
    }

}
