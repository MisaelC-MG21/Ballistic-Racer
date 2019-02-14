using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public enum MenuStates { MainMenu, Credits, PlayerSelect, TrackSelect, ShipSelect };
    public MenuStates currentState;
    public GameObject mainUI;
    public GameObject creditUI;
    public GameObject playerSelectUI;
    public GameObject trackSelectUI;
   // public GameObject shipSelectUI;
    //AudioSource audioData;
    public string level;

    public GameObject onePCam;
    public GameObject twoPCam;
    public GameObject threePCam;
    public GameObject fourPCam;

    public Text[] pOneText;
    public Text[] pTwoText;
    public Text[] pThreeText;
    public Text pFourText;

    [HideInInspector] public bool oneConfirm, twoConfirm, threeConfirm, fourConfirm;

    bool oneKeyboard, twoKeyboard, threeKeyboard, fourKeyboard;

    void Start()
    {
        MPManagerReset();
       // audioData = GetComponent<AudioSource>();
        //audioData.Play(0);
        Debug.Log("started");
    }

    private void Update() {
        switch(currentState) {
            case MenuStates.MainMenu:
            mainUI.SetActive(true);
            creditUI.SetActive(false);
            playerSelectUI.SetActive(false);
            break;
            case MenuStates.Credits:
            mainUI.SetActive(false);
            creditUI.SetActive(true);
            break;
            case MenuStates.PlayerSelect:
            mainUI.SetActive(false);
            //shipSelectUI.SetActive(false);
            playerSelectUI.SetActive(true);
            trackSelectUI.SetActive(false);
            break;
            case MenuStates.TrackSelect:
            trackSelectUI.SetActive(true);
            playerSelectUI.SetActive(false);
            break;
            case MenuStates.ShipSelect:
            trackSelectUI.SetActive(false);
            break;
        }
        if(MPManager.mpManager.oneP) {
            if(oneConfirm) {
                MPManager.mpManager.Save();
                SceneManager.LoadScene(level);
            }
        }
        if(MPManager.mpManager.twoP) {
            if(oneConfirm && twoConfirm) {
                MPManager.mpManager.Save();
                SceneManager.LoadScene(level);
            }
        }
        if(MPManager.mpManager.threeP) {
            if(oneConfirm && twoConfirm && threeConfirm) {
                MPManager.mpManager.Save();
                SceneManager.LoadScene(level);
            }
        }
        if(MPManager.mpManager.fourP) {
            if(oneConfirm && twoConfirm && threeConfirm && fourConfirm) {
                MPManager.mpManager.Save();
                SceneManager.LoadScene(level);
            }
        }

        foreach(Text text in pOneText) {
            if(oneKeyboard) {
                text.text = "Keyboard";
            } else {
                text.text = "Controller";
            }
        }
        foreach(Text text in pTwoText) {
            if(twoKeyboard) {
                text.text = "Keyboard";
            } else {
                text.text = "Controller";
            }
        }
        foreach(Text text in pThreeText) {
            if(threeKeyboard) {
                text.text = "Keyboard";
            } else {
                text.text = "Controller";
            }
        }

        if(fourKeyboard) {
            pFourText.text = "Keyboard";
        } else {
            pFourText.text = "Controller";
        }

        

        MPManager.mpManager.pOneKeyboard = oneKeyboard;
        MPManager.mpManager.pTwoKeyboard = twoKeyboard;
        MPManager.mpManager.pThreeKeyboard = threeKeyboard;
        MPManager.mpManager.pFourKeyboard = fourKeyboard;

    }

    public void SetKeybaord(float controller) {
        if(controller == 1) {
            oneKeyboard = !oneKeyboard;
            twoKeyboard = false;
            threeKeyboard = false;
            fourKeyboard = false;
        }

        if(controller == 2) {
            twoKeyboard = !twoKeyboard;
            oneKeyboard = false;
            threeKeyboard = false;
            fourKeyboard = false;
        }

        if(controller == 3) {
            threeKeyboard = !threeKeyboard;
            twoKeyboard = false;
            oneKeyboard = false;
            fourKeyboard = false;
        }

        if(controller == 4) {
            fourKeyboard = !fourKeyboard;
            twoKeyboard = false;
            threeKeyboard = false;
            oneKeyboard = false;
        }
    }

    public void Confirm(float playerNumber) {
        if(playerNumber == 1) {
            oneConfirm = true;
        }
        if(playerNumber == 2) {
            twoConfirm = true;
        }
        if(playerNumber == 3) {
            threeConfirm = true;
        }
        if(playerNumber == 4) {
            fourConfirm = true;
        }
    }

    public void Play()
    {
        currentState = MenuStates.PlayerSelect;
    }

    public void PlayersSelected() {
        currentState = MenuStates.ShipSelect;
        if(MPManager.mpManager.oneP) {
            onePCam.SetActive(true);
        }
        if(MPManager.mpManager.twoP) {
            twoPCam.SetActive(true);
        }
        if(MPManager.mpManager.threeP) {
            threePCam.SetActive(true);
        }
        if(MPManager.mpManager.fourP) {
            fourPCam.SetActive(true);
        }
    }

    public void TrackSelect() {
        currentState = MenuStates.TrackSelect;
    }

    public void OnePlayer() {
        MPManager.mpManager.oneP = true;
        
    }
    public void TwoPlayer() {
        MPManager.mpManager.twoP = true;
        
        
    }
    public void ThreePlayer() {
        MPManager.mpManager.threeP = true;
        
        
    }
    public void FourPlayer() {
        MPManager.mpManager.fourP = true;
        
        
    }

    public void Credits()
    {
        currentState = MenuStates.Credits;
    }

    public void Back()
    {
        if(currentState == MenuStates.Credits) {
            currentState = MenuStates.MainMenu;
        }
        if(currentState == MenuStates.PlayerSelect) {
            currentState = MenuStates.MainMenu;
        }
        if(currentState == MenuStates.TrackSelect) {
            currentState = MenuStates.PlayerSelect;
            onePCam.SetActive(false);
            twoPCam.SetActive(false);
            threePCam.SetActive(false);
            fourPCam.SetActive(false);

            MPManager.mpManager.oneP = false;
            MPManager.mpManager.twoP = false;
            MPManager.mpManager.threeP = false;
            MPManager.mpManager.fourP = false;

            
        }
        if(currentState == MenuStates.ShipSelect) {
            currentState = MenuStates.TrackSelect;
            onePCam.SetActive(false);
            twoPCam.SetActive(false);
            threePCam.SetActive(false);
            fourPCam.SetActive(false);

            oneConfirm = false;
            twoConfirm = false;
            threeConfirm = false;
            fourConfirm = false;
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    void MPManagerReset() {
        MPManager.mpManager.oneP = false;
        MPManager.mpManager.twoP = false;
        MPManager.mpManager.threeP = false;
        MPManager.mpManager.fourP = false;

        MPManager.mpManager.pOne = 0;
        MPManager.mpManager.pTwo = 0;
        MPManager.mpManager.pThree = 0;
        MPManager.mpManager.pFour = 0;

        MPManager.mpManager.Save();
    }
}
