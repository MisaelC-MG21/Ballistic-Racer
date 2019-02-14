using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RacerSelection : MonoBehaviour
{
    private GameObject[] CharacterList;
    private int index;
    //public static string selectedShip;

    public int playerNumber;

    public Button[] selectionButtons;

    MainMenu mainMenu;

    void Start()
    {

        mainMenu = GetComponentInParent<MainMenu>();
        CharacterList = new GameObject[transform.childCount];

        // Create an array that holds the number of racers.
        // A new place is created for each gameObject that is attached to CharacterList.

        for (int i = 0; i < transform.childCount; i++)
            CharacterList[i] = transform.GetChild(i).gameObject;

        //Deactivate the renders.
        foreach (GameObject go in CharacterList)
        {
            go.SetActive(false);
        }

        // Activate the render for the first index.

        if (CharacterList[0])
            CharacterList[0].SetActive(true);

    }

    private void Update() {
        
        if(mainMenu.oneConfirm) {
            if(MPManager.mpManager.pOne == index && playerNumber != 1) {
                CharacterList[MPManager.mpManager.pOne].SetActive(false);
                index++;
                CharacterList[index].SetActive(true);
            }
        }
        if(mainMenu.twoConfirm) {
            if(MPManager.mpManager.pTwo == index && playerNumber != 2) {
                CharacterList[MPManager.mpManager.pTwo].SetActive(false);
                index++;
                CharacterList[index].SetActive(true);
            }
        }
        if(mainMenu.threeConfirm) {
            if(MPManager.mpManager.pThree == index && playerNumber != 3) {
                CharacterList[MPManager.mpManager.pThree].SetActive(false);
                index++;
                CharacterList[index].SetActive(true);
            }
        }
        if(mainMenu.fourConfirm) {
            if(MPManager.mpManager.pFour == index && playerNumber != 4) {
                CharacterList[MPManager.mpManager.pFour].SetActive(false);
                index++;
                CharacterList[index].SetActive(true);
            }
        }
    }

    public void ToggleLeft()
    {
        // Toggle off current model
        CharacterList[index].SetActive(false);

        index--;
        if(mainMenu.oneConfirm) {
            if(MPManager.mpManager.pOne == index) {
                index--;
            }
        }
        if(mainMenu.twoConfirm) {
            if(MPManager.mpManager.pTwo == index) {
                index--;
            }
        }
        if(mainMenu.threeConfirm) {
            if(MPManager.mpManager.pThree == index) {
                index--;
            }
        }
        if(mainMenu.fourConfirm) {
            if(MPManager.mpManager.pFour == index) {
                index--;
            }
        }
        if (index < 0)
        {
            index = CharacterList.Length - 1;
        }
        //Toggle on current model
        CharacterList[index].SetActive(true);
        
    }

    public void ToggleRight()
    {
        // Toggle off current model
        CharacterList[index].SetActive(false);

        index++;
        if(mainMenu.oneConfirm) {
            if(MPManager.mpManager.pOne == index) {
                index++;
            }
        }
        if(mainMenu.twoConfirm) {
            if(MPManager.mpManager.pTwo == index) {
                index++;
            }
        }
        if(mainMenu.threeConfirm) {
            if(MPManager.mpManager.pThree == index) {
                index++;
            }
        }
        if(mainMenu.fourConfirm) {
            if(MPManager.mpManager.pFour == index) {
                index++;
            }
        }
        if (index == CharacterList.Length)
        {
            index = 0;
        }
        //Toggle on current model
        CharacterList[index].SetActive(true);
    }
    public void Confirm()
    {
        foreach(Button button in selectionButtons) {
            button.interactable = false;
        }
        if(playerNumber == 1) {
            MPManager.mpManager.pOne = index;
            
        }
        if(playerNumber == 2) {
            MPManager.mpManager.pTwo = index;
            
        }
        if(playerNumber == 3) {
            MPManager.mpManager.pThree = index;
            
        }
        if(playerNumber == 4) {
            MPManager.mpManager.pFour = index;
            
        }
        //SceneManager.LoadScene("Track_1");
    }

    public void Back() {
        foreach(Button button in selectionButtons) {
            button.interactable = true;
        }
        CharacterList[index].SetActive(false);
        index = 0;
        CharacterList[index].SetActive(true);
    }
}