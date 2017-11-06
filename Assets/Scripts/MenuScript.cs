using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/*
 * This script is used for the on-screen menus that allow the player to start, end, and view information
 */

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas startMenu;
    public Canvas infoMenu;
    public Button startText;
    public Button infoText;
    public Button quitText;

    //text within the initial menu
    private Text textStart;
    private Text textInfo;
    private Text textQuit;

    //access + change things outside of this object
    public Rigidbody player;
    public GameObject sphere;
    public GameObject focusPoint;

    private PlayerController controller;
    private MouseLook mouseX;
    private MouseLook mouseY;
    private CameraCollision cam;

    //start checking for "I" press to open menu
    private bool iCheck;

    // Use this for initialization
    void Start()
    {
        //initiate menus
        startMenu = this.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        infoMenu = infoMenu.GetComponent<Canvas>();

        startText = startText.GetComponent<Button>();
        infoText = infoText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();

        startMenu.enabled = true;
        quitMenu.enabled = false;
        infoMenu.enabled = false;

        //set main texts
        textStart = startText.GetComponent<Text>();
        textInfo = infoText.GetComponent<Text>();
        textQuit = quitText.GetComponent<Text>();

        //disable player controls
        controller = player.GetComponent<PlayerController>();
        mouseX = sphere.GetComponent<MouseLook>();
        mouseY = focusPoint.GetComponent<MouseLook>();
        cam = Camera.main.GetComponent<CameraCollision>();

        enablePlayerControl(false);
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;

        //disables button actions and text visibility
        enableStart(false);
    }

    public void InfoPress()
    {
        infoMenu.enabled = true;
        enableStart(false);
    }

    public void InfoBackPress()
    {
        infoMenu.enabled = false;
        enableStart(true);
    }

    public void NoPress()
    {
        quitMenu.enabled = false;

        //enables button actions and text visbility
        enableStart(true);
    }

    public void StartLevel()
    {
        enableStart(false);
        infoMenu.enabled = false;
        quitMenu.enabled = false;

        //renames "play" to "resume"
        textStart.text = "resume";

        enablePlayerControl(true);

        //start checking "I" for menu opening
        iCheck = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	
    public void reopenMenu()
    {
        enableStart(true);
        enablePlayerControl(false);

    }
	// Update is called once per frame
	void Update () {
        if(iCheck == true && Input.GetKeyDown(KeyCode.Escape))
        {
            iCheck = false;
            reopenMenu();
        } else if (iCheck == false && Input.GetKeyDown(KeyCode.Escape) && textStart.text.Equals("resume"))
        {
            StartLevel();
            
        }
	}

    void enableStart (bool able)
    {
        if (able == true)
        {
            //enable canvas + text
            startMenu.enabled = true;
            textStart.enabled = true;
            textInfo.enabled = true;
            textQuit.enabled = true;

            //enable button actions
            startText.enabled = true;
            infoText.enabled = true;
            quitText.enabled = true;
        } else
        {
            //disable canvas + text
            startMenu.enabled = false;
            textStart.enabled = false;
            textInfo.enabled = false;
            textQuit.enabled = false;

            //disable button actions
            startText.enabled = false;
            infoText.enabled = false;
            quitText.enabled = false;
        }
    }

    void enablePlayerControl(bool able)
    {
        if (able == true)
        {
            //enable player controls
            controller.enabled = true;
            mouseX.enabled = true;
            mouseY.enabled = true;
            cam.canScroll = true;
        } else
        {
            //disable player controls
            controller.enabled = false;
            mouseX.enabled = false;
            mouseY.enabled = false;
            cam.canScroll = false;
        }
    }
}
