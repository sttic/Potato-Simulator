using UnityEngine;
using System.Collections;

/*
 * This script is used for the player controlling the movement of the potato
 * Many characteristics can easily be changed in the inspector window with the public variables
 * 
 * A key part of this is how the heirarchy of the player was set up to allow the potato to roll with the camera
 * following without inheriting its rotation. Transformations can not be used for the rolling, forces instead.
 * A sphere (see script "SpherePos") is being constantly set to the potato's position for the camera to use.
 * 
 * Free third-person camera scipts used from the Unity Asset stores and from the standard assets
 */

public class PlayerController : MonoBehaviour {

    public float speed; //used for ease of chaning in the interface
    private float rollSpeed;
    public float sprintMultiplier;
    public float maxSlope;

    public float movingDrag;
    public float stillDrag;

    private float jumpSpeed;
    public float movingJumpSpeed;
    public float stillJumpSpeed;

    private float moveHorizontal;
    private float moveVertical;

    private Rigidbody rb;
    private bool isGrounded;

    public GameObject sphere;
    Vector3 movement = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
   
    /* Update is called once per frame
	void Update () {
	
	}
    */

    //called for physics
    void FixedUpdate ()
    {
        getInput();
        sprint();
        deceleration();
        jump();
        applyMovement();

    }

    //test if the player is on the ground with a slope lesser than 60 degrees
    void OnCollisionStay (Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if(Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
            {
                isGrounded = true;
            }
        }
    }
    void OnCollisionExit ()
    {
        isGrounded = false;
    }


    void getInput ()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        //movement.x = Input.GetAxis("Horizontal");
        //movement.z = Input.GetAxis("Vertical");
    }

    void deceleration()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) //also detect isGrounded?
        {
            rb.drag = stillDrag;
            rb.angularDrag = stillDrag;
            //conteracts that for some reason, the player is able to jump higher when still
            jumpSpeed = stillJumpSpeed;
        }
        else
        {
            rb.drag = movingDrag;
            rb.angularDrag = movingDrag;
            jumpSpeed = movingJumpSpeed;
        }
    }

    void sprint()
    {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
        {
            rollSpeed = speed * sprintMultiplier;
            Camera.main.fieldOfView = 70;
        } else
        {
            rollSpeed = speed;
            Camera.main.fieldOfView = 60;
        }
    }

    void jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            movement = new Vector3(0.0f, jumpSpeed / rollSpeed * (1 + Time.deltaTime), 0.0f);
        }
        else
        {
            movement = new Vector3(moveHorizontal * Time.deltaTime, 0, moveVertical * Time.deltaTime);
            //prevents going faster when moving diagonal, magnitude = (1,0,1) or sqrt(2) instead of 1
            movement.Normalize();
        }
    }

    void applyMovement()
    {
        //makes the player move in relation to where the sphere (non-tilting camera equivalent) looks
        movement = sphere.transform.TransformDirection(movement);

        rb.AddForce(movement * rollSpeed);
    }

}
