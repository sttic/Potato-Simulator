using UnityEngine;
using System.Collections;

/*
 * This script makes a certain barrel with an explosion object explode
 * Scipt not in effect- problem with explosion asset (shaders?)
 */

public class ExplodingBarrel : MonoBehaviour
{

    public GameObject explosion;
    private Detonator detonatorScript;
    private bool used = false;

    private float nextUsage;
    private int delay = 2;

    void Start()
    {
        //accessing a variable from another script
        detonatorScript = explosion.GetComponent<Detonator>();
        detonatorScript.enabled = false;

        
    }

    void FixedUpdate()
    {
        //detect if the barrel is on its side and hasn't already exploded
        if ((transform.rotation.eulerAngles.x > 85 || transform.rotation.eulerAngles.x < -85
            || transform.rotation.eulerAngles.z > 85 || transform.rotation.eulerAngles.z < -85) 
            && used == false)
        {
            //the script explodes as it is enabled. The "explodeOnStart" is true
            detonatorScript.enabled = true;

            used = true;
        }


    }

}
