using UnityEngine;
using System.Collections;

/*
 * This script constantly sets the position of an invisible, non-interactive sphere to the player
 * See PlayerController.
 */

public class SpherePos : MonoBehaviour {

    public GameObject player;


	// Use this for initialization
	void Start () {
        
    }
	
	/* Update is called once per frame
	void Update () {
	
	}
    */

    void FixedUpdate ()
    {
        transform.position = player.transform.position;
    }
}
