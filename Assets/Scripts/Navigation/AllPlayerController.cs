using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerController : MonoBehaviour
{
    private LayerMask clickablesLayer;
    private Ray shootRay;
    private RaycastHit destination;
    private Ray myRayPlayer;
    private bool playerOneSelected;
    private bool playerTwoSelected;
    private bool playerThreeSelected;
    private bool playerFourSelected;
    private bool playerFiveSelected;
    private MeshRenderer renderer;
    public PlayControl _playControl;
    public PlayControlTwo _playControlTwo;
    public PlayControlThree _playControlThree;
    public PlayControlFour _playControlFour;
    public PlayControlFive _playControlFive;

    public void start()
    {
        playerOneSelected = false;
        playerTwoSelected = false;
        playerThreeSelected = false;
        playerFourSelected = false;
        playerFiveSelected = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray selectingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(selectingRay, out hit, 100))
            {
                if(hit.collider.CompareTag("PlayerOne") && playerOneSelected)
                {
                    Debug.Log("Player One is now deselcted");
                    _playControl.deselectPlayer();
                    playerOneSelected = false;
                }
                else if (hit.collider.CompareTag("PlayerOne") && !playerOneSelected)
                {
                    _playControl.setPlayer();
                    playerOneSelected = true;
                }
                if (hit.collider.CompareTag("PlayerTwo") && playerTwoSelected)
                {
                    Debug.Log("Player Two is now deselcted");
                    _playControlTwo.deselectPlayer();
                    playerTwoSelected = false;
                }
                else if (hit.collider.CompareTag("PlayerTwo") && !playerTwoSelected)
                {
                    _playControlTwo.setPlayer();
                    playerTwoSelected = true;
                }
                if (hit.collider.CompareTag("PlayerThree") && playerThreeSelected)
                {
                    Debug.Log("Player Three is now deselected");
                    _playControlThree.deselectPlayer();
                    playerThreeSelected = false;
                }
                else if (hit.collider.CompareTag("PlayerThree") && !playerThreeSelected)
                {
                    _playControlThree.setPlayer();
                    playerThreeSelected = true;
                }
                if (hit.collider.CompareTag("PlayerFour") && playerFourSelected)
                {
                    Debug.Log("Player Four is now deselected");
                    _playControlFour.deselectPlayer();
                    playerFourSelected = false;
                    Debug.Log("player Two is now " + playerThreeSelected);
                }
                else if (hit.collider.CompareTag("PlayerFour") && !playerFourSelected)
                {
                    _playControlFour.setPlayer();
                    playerFourSelected = true;
                }
                if (hit.collider.CompareTag("PlayerFive") && playerFiveSelected)
                {
                    Debug.Log("Player Five is now deselected");
                    _playControlFive.deselectPlayer();
                    playerFiveSelected = false;
                }
                else if (hit.collider.CompareTag("PlayerFive") && !playerFiveSelected)
                {
                    _playControlFive.setPlayer();
                    playerFiveSelected = true;
                }
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Ray selectingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(selectingRay, out hit, 100))
            {
                if (hit.collider.CompareTag("Floor") && playerOneSelected)
                {
                    _playControl.movePlayer(hit);
                }
                if (hit.collider.CompareTag("Floor") && playerTwoSelected)
                {
                    _playControlTwo.movePlayer(hit);
                }
                if (hit.collider.CompareTag("Floor") && playerThreeSelected)
                {
                    _playControlThree.movePlayer(hit);
                }
                if (hit.collider.CompareTag("Floor") && playerFourSelected)
                {
                    _playControlFour.movePlayer(hit);
                }
                if (hit.collider.CompareTag("Floor") && playerFiveSelected)
                {
                    _playControlFive.movePlayer(hit);
                }
            }
        }
    }
}
