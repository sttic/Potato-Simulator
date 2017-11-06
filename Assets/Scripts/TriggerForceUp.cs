using UnityEngine;
using System.Collections;

/*
 * This script mimics the behaviour of a typical game jump-pad for rigidbodies
 * 
 * This is currently not in use
 */

public class TriggerForceUp : MonoBehaviour {

    public GameObject player;
    public float forceUp;

    private Rigidbody rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    public void OnTriggerStay (Collider other)
    {
        //adds upwards force onto the player
        rb.AddForce(Vector3.up * forceUp, ForceMode.Acceleration);
    }
}
