using UnityEngine;
using System.Collections;

/*
 * Keeps the player and other rigidbodies from going too close to the edge of the map
 * This sends the player in the opposite direction faster than the original movement
 * 
 * It's possible for the player to escape under certain circumstances where the player gets send
 * upwards really fast (stacking forces?)
 */

public class TriggerBorder : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;

    private int addX;
    private int addZ;
    private int multY;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void OnTriggerExit(Collider other)
    {
        //checks for the proper sign (-'ve or +'ve) when applying the minimun force for slow-moving potatoes
        if (rb.velocity.x < 0)
        {
            addX = 5;
        } else
        {
            addX = -5;
        }

        if (rb.velocity.y < 0)
        {
            multY = -5;
        } else
        {
            multY = 5;
        }

        if (rb.velocity.z < 0)
        {
            addZ = 5;
        } else
        {
            addZ = -5;
        }

        //pushes the player in the opposite (+ upwards) direction it was leaving the borders with
        rb.AddForce(-5 * rb.velocity.x + addX, multY * rb.velocity.y + 5, -5 * rb.velocity.z + addZ, ForceMode.Impulse);
    }

}

