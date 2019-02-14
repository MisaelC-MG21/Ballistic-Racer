using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static int numOfPlayers;
    public bool onePlayer, twoPlayer, threePlayer, fourPlayer;

    public void SetNumOfPlayersOne()
    {
        numOfPlayers = 1;
    }

    public void SetNumOfPlayersTwo()
    {
        numOfPlayers = 2;
    }

    public void SetNumOfPlayersThree()
    {
        numOfPlayers = 3;
    }

    public void SetNumOfPlayersFour()
    {
        numOfPlayers = 4;
    }
}
