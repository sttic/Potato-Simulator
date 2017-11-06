using UnityEngine;
using System.Collections;

/*
 * This script is used to mimic the movement similar to a trampoline for rigidbodies in a trigger space
 * 
 * This is currently not in use
 */

public class TriggerBounce : MonoBehaviour
{
    public GameObject player;
    public float inelasticCollisionFactor;
    public float minBounce;
    public float jumpForce;

    private Rigidbody rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider other)
    {
        if (rb.velocity.y < 0)
        {
            //adds what would equal to the absolute value of a negative force in the y-axis with additional factors
            rb.AddForce(0, -2 * rb.velocity.y + minBounce - inelasticCollisionFactor, 0, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            //makes it so that the player can gain height by jumping
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

}

