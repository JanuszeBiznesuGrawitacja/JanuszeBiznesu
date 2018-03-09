using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerManager : MonoBehaviour {

    public GameObject player1, player2;
    bool changePlayer = false;

    void Awake()
    {
        player1.GetComponent<Platformer2DUserControl>().enabled = true;
        player2.GetComponent<Platformer2DUserControl>().enabled = false;
        player1.GetComponent<PlatformerCharacter2D>().enabled = true;
        player2.GetComponent<PlatformerCharacter2D>().enabled = false;
        player1.GetComponent<Animator>().enabled = true;
        player2.GetComponent<Animator>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) changePlayer = !changePlayer;
        ChangePlayer(changePlayer);

    }

    void ChangePlayer(bool change)
    {
        if(change)
        {
            player1.GetComponent<Platformer2DUserControl>().enabled = false;
            player2.GetComponent<Platformer2DUserControl>().enabled = true;
            player1.GetComponent<PlatformerCharacter2D>().enabled = false;
            player2.GetComponent<PlatformerCharacter2D>().enabled = true;
            player1.GetComponent<Animator>().enabled = false;
            player2.GetComponent<Animator>().enabled = true;
        }
        else
        {
            player1.GetComponent<Platformer2DUserControl>().enabled = true;
            player2.GetComponent<Platformer2DUserControl>().enabled = false;
            player1.GetComponent<PlatformerCharacter2D>().enabled = true;
            player2.GetComponent<PlatformerCharacter2D>().enabled = false;
            player1.GetComponent<Animator>().enabled = true;
            player2.GetComponent<Animator>().enabled = false;
        }
    }



}
