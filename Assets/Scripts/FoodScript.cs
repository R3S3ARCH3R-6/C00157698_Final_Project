using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ...
/// </summary>
public class FoodScript : MonoBehaviour
{
    AudioSource chomp;  //this is the sound made when the player eats the food
    float riseTime = 2.0f;
    float deltaTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //accesses the audio's source, a component attached to the object
        chomp = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BobMove();
        //transform.localEulerAngles += new Vector3(0, 5.0f, 0);
        //insert bobbing feature here
    }

    /// <summary>
    /// 
    /// </summary>
    void BobMove()
    {
        if(deltaTime <= 1.0 && deltaTime > 0)
        {
            transform.position += new Vector3(0, 0.01f, 0f);
            deltaTime -= Time.deltaTime;
        }
        else if(deltaTime > 1.0)
        {
            transform.position += new Vector3(0, -0.01f, 0f);
            deltaTime -= Time.deltaTime;
        }
        else
        {
            deltaTime = riseTime;
        }

    }

    /// <summary>
    /// if the player...
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Disable all Renderers and Colliders within the fruit object
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allColliders) c.enabled = false;

            StartCoroutine(PlayAndDestroy(chomp.clip.length));
        }
    }

    /// <summary>
    /// used to play the audio after the fruit is eaten
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    private IEnumerator PlayAndDestroy(float waitTime)
    {
        chomp.Play();
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

}
