using UnityEngine;
using System.Collections;

/*
 * This script activates an explosion upon entering a trigger space
 * 
 * This is currently not in use
 */

public class TriggerExplosion : MonoBehaviour
{

    public GameObject explosion;
    private Detonator detonatorScript;
    private bool used = false;

    void Start()
    {
        //accessing a variable from another script
        detonatorScript = explosion.GetComponent<Detonator>();
        detonatorScript.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (used == false)
        {
            //the script explodes as it is enabled. The "explodeOnStart" is true
            detonatorScript.enabled = true;
            used = true;
        }
        
    }

}

