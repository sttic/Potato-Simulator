using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/*
 * This script is for when the player is in water
 * This is detected when the player enters a trigger (collider) object occupying the same space
 * Slows the player down, disables jumping and sprinting (fov still changes), and allows the player to float up
 * 
 * The murky underwater overlay is not working-
 * was not able to access the ImageEffects ScreenOverlay scipt for it
 */

public class TriggerSwimming : MonoBehaviour
{
    //the murky underwater overlay isn't working as intended

    public GameObject player;
    //public Camera camera;

    public int swimForce;
    public int waterSpeed;
    public float waterJump;

    private PlayerController pc;
    private Rigidbody rb;
    //private ScreenOverlay SO;

    //original ground movement values
    private float groundSpeed;
    private float groundJumpMoving;
    private float groundJumpStill;
    private float groundSprint;

    public void Start()
    {
        //accessing a variable from another script
        rb = player.GetComponent<Rigidbody>();
        pc = player.GetComponent<PlayerController>();
        //SO = Camera.main.GetComponent<ScreenOverlay>();

        //storing original ground speed and jump values
        groundSpeed = pc.speed;
        groundJumpMoving = pc.movingJumpSpeed;
        groundJumpStill = pc.stillJumpSpeed;

        waterJump = 0.5f * pc.stillJumpSpeed;

        groundSprint = pc.sprintMultiplier;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "potato")
        {
            //slows down the player's movement when in water
            pc.speed = waterSpeed;
            pc.movingJumpSpeed = waterJump;
            pc.stillJumpSpeed = waterJump;

            //disable sprint
            pc.sprintMultiplier = 1;

            //upwards swimming force
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(0, swimForce, 0);
            }

            //murky, underwater overlay
            //SO.enabled = true;
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "potato")
        {
            //returns player to original speed upon exiting
            pc.speed = groundSpeed;
            pc.movingJumpSpeed = groundJumpMoving;
            pc.stillJumpSpeed = groundJumpStill;

            pc.sprintMultiplier = groundSprint;

            //disable murky overlay
            //SO.enabled = false;
        }


    }

}

