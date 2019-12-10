using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //needed for changing scenes

/// <summary>
/// ...
/// </summary>
public class SuperFruitScript : MonoBehaviour
{
    public Text superClock;

    float superTime = 20.0f;
    float superReset = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        superClock.text = "SUPER MODE ACTIVE!";
        superClock.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //superTime = 20.0f;
        if (superTime > 0)
        {
            //superOn = true;
            superClock.enabled = true;
            superTime -= Time.deltaTime;
            superClock.text = "SUPER MODE ACTIVE! "; //+ Mathf.Round(superTime).ToString() + "s";
        }
        else
        {
            superClock.enabled = false;
            superTime = superReset;
            //superOn = false;
        }
    }
}
