using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalDetect : MonoBehaviour
{
    public float targetDist = 0f;
    public Text distText;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        distText.text = "Target Distance: " + targetDist.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private float DistanceCalc()
    {
        targetDist = ;
        return;
    }*/
}
