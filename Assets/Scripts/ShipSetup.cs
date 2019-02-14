using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSetup : MonoBehaviour {

    public GameObject onePCamera;

    public GameObject onePCanvas;
    public GameObject twoPCanvas;
    public GameObject threePCanvas;
    public GameObject fourPCanvas;

    public GameObject onePMiniMap;
    public GameObject MPMiniMap;

    public bool firstRace;

    GameObject[] startPositions;

    public static bool raceStarted;

    [System.Serializable]
    public class TwoPlayer {
        public GameObject pOneCamera;
        public GameObject pTwoCamera;
    }
    public TwoPlayer twoPlayers;

    [System.Serializable]
    public class ThreePlayer {
        public GameObject pOneCamera;
        public GameObject pTwoCamera;
        public GameObject pThreeCamera;
    }
    public ThreePlayer threePlayers;

    [System.Serializable]
    public class FourPlayer {
        public GameObject pOneCamera;
        public GameObject pTwoCamera;
        public GameObject pThreeCamera;
        public GameObject pFourCamera;
    }
    public FourPlayer fourPlayers;

    public PlayerInput[] ships;

	// Use this for initialization
	void Awake () {
        startPositions = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++) {
            startPositions[i] = transform.GetChild(i).gameObject;
        }
        SetShips();
        SetPlayers();
        
	}

    private void Start() {
        StartCoroutine(WaitedStart());
    }

    IEnumerator WaitedStart() {
        yield return new WaitForSeconds(3);
        raceStarted = true;
    }

   

    void SetShips() {
        foreach(PlayerInput players in ships) {
            if(firstRace) {
                for(int i = 0; i < startPositions.Length; i++) {
                    if(players.shipID == i) {
                        players.transform.position = startPositions[i].transform.position;
                        players.transform.rotation = startPositions[i].transform.rotation;
                    }
                }
            }
            if(MPManager.mpManager.oneP) {
                if(players.shipID == MPManager.mpManager.pOne) {
                    players.controllerNumber = 1;
                } else {
                    players.controllerNumber = 0;
                }
            }
            if(MPManager.mpManager.twoP) {
                if(players.shipID == MPManager.mpManager.pOne) {
                    players.controllerNumber = 1;
                } else if(players.shipID == MPManager.mpManager.pTwo) {
                    players.controllerNumber = 2;
                } else {
                    players.controllerNumber = 0;
                }
            }
            if(MPManager.mpManager.threeP) {
                if(players.shipID == MPManager.mpManager.pOne) {
                    players.controllerNumber = 1;
                } else if(players.shipID == MPManager.mpManager.pTwo) {
                    players.controllerNumber = 2;
                } else if(players.shipID == MPManager.mpManager.pThree) {
                    players.controllerNumber = 3;
                } else {
                    players.controllerNumber = 0;
                }
            }
            if(MPManager.mpManager.fourP) {
                if(players.shipID == MPManager.mpManager.pOne) {
                    players.controllerNumber = 1;
                } else if(players.shipID == MPManager.mpManager.pTwo) {
                    players.controllerNumber = 2;
                } else if(players.shipID == MPManager.mpManager.pThree) {
                    players.controllerNumber = 3;
                } else if(players.shipID == MPManager.mpManager.pFour) {
                    players.controllerNumber = 4;
                } else {
                    players.controllerNumber = 0;
                }
            }
        }
    }

    void SetPlayers() {
        if(MPManager.mpManager.oneP) {
            Instantiate(onePMiniMap);
            GameObject cameraOne = Instantiate(onePCamera);

            Instantiate(onePCanvas);

            foreach(PlayerInput players in ships) {
                if(players.controllerNumber == 1) {
                    CameraRig cameraRig = cameraOne.GetComponent<CameraRig>();

                    cameraRig.target = players.gameObject.transform;
                    cameraRig.cameraPoints[2] = players.transform.Find("Front_Cam_Point");
                    cameraRig.inputs = players;

                    PlayerHealth playerHealth = players.GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = players.GetComponentInChildren<CheckTrigger>();

                    players.GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/1_Player_Canvas(Clone)/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/1_Player_Canvas(Clone)/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/1_Player_Canvas(Clone)/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/1_Player_Canvas(Clone)/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/1_Player_Canvas(Clone)/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/1_Player_Canvas(Clone)/Finish");
                }
            }
        }
        if(MPManager.mpManager.twoP) {
            Instantiate(MPMiniMap);
            GameObject cameraOne = Instantiate(twoPlayers.pOneCamera);
            GameObject cameraTwo = Instantiate(twoPlayers.pTwoCamera);

            Instantiate(twoPCanvas);

            for(int i = 0; i < ships.Length; i++) {
                if(ships[i].controllerNumber == 1) {
                    cameraOne.GetComponent<CameraRig>().target = ships[i].gameObject.transform;
                    cameraOne.GetComponent<CameraRig>().cameraPoints[2] = ships[i].transform.Find("Front_Cam_Point");
                    cameraOne.GetComponent<CameraRig>().inputs = ships[i];

                    PlayerHealth playerHealth = ships[i].GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = ships[i].GetComponentInChildren<CheckTrigger>();

                    ships[i].GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/2_Player_Canvas(Clone)/Player_1/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/2_Player_Canvas(Clone)/Player_1/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/2_Player_Canvas(Clone)/Player_1/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/2_Player_Canvas(Clone)/Player_1/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/2_Player_Canvas(Clone)/Player_1/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/2_Player_Canvas(Clone)/Player_1/Finish");
                }
                if(ships[i].controllerNumber == 2) {
                    cameraTwo.GetComponent<CameraRig>().target = ships[i].gameObject.transform;
                    cameraTwo.GetComponent<CameraRig>().cameraPoints[2] = ships[i].transform.Find("Front_Cam_Point");
                    cameraTwo.GetComponent<CameraRig>().inputs = ships[i];

                    PlayerHealth playerHealth = ships[i].GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = ships[i].GetComponentInChildren<CheckTrigger>();

                    ships[i].GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/2_Player_Canvas(Clone)/Player_2/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/2_Player_Canvas(Clone)/Player_2/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/2_Player_Canvas(Clone)/Player_2/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/2_Player_Canvas(Clone)/Player_2/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/2_Player_Canvas(Clone)/Player_2/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/2_Player_Canvas(Clone)/Player_2/Finish");
                }
                
            }


            
        }
        if(MPManager.mpManager.threeP) {
            Instantiate(MPMiniMap);
            GameObject cameraOne = Instantiate(threePlayers.pOneCamera);
            GameObject cameraTwo = Instantiate(threePlayers.pTwoCamera);
            GameObject cameraThree = Instantiate(threePlayers.pThreeCamera);

            Instantiate(threePCanvas);

            for(int i = 0; i < ships.Length; i++) {
                if(ships[i].controllerNumber == 1) {
                    cameraOne.GetComponent<CameraRig>().target = ships[i].gameObject.transform;
                    cameraOne.GetComponent<CameraRig>().cameraPoints[2] = ships[i].transform.Find("Front_Cam_Point");
                    cameraOne.GetComponent<CameraRig>().inputs = ships[i];

                    PlayerHealth playerHealth = ships[i].GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = ships[i].GetComponentInChildren<CheckTrigger>();

                    ships[i].GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/3_Player_Canvas(Clone)/Player_1/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/3_Player_Canvas(Clone)/Player_1/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/3_Player_Canvas(Clone)/Player_1/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/3_Player_Canvas(Clone)/Player_1/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/3_Player_Canvas(Clone)/Player_1/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/3_Player_Canvas(Clone)/Player_1/Finish");
                }
                if(ships[i].controllerNumber == 2) {
                    cameraTwo.GetComponent<CameraRig>().target = ships[i].gameObject.transform;
                    cameraTwo.GetComponent<CameraRig>().cameraPoints[2] = ships[i].transform.Find("Front_Cam_Point");
                    cameraTwo.GetComponent<CameraRig>().inputs = ships[i];

                    PlayerHealth playerHealth = ships[i].GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = ships[i].GetComponentInChildren<CheckTrigger>();

                    ships[i].GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/3_Player_Canvas(Clone)/Player_2/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/3_Player_Canvas(Clone)/Player_2/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/3_Player_Canvas(Clone)/Player_2/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/3_Player_Canvas(Clone)/Player_2/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/3_Player_Canvas(Clone)/Player_2/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/3_Player_Canvas(Clone)/Player_2/Finish");
                }
                if(ships[i].controllerNumber == 3) {
                    cameraThree.GetComponent<CameraRig>().target = ships[i].gameObject.transform;
                    cameraThree.GetComponent<CameraRig>().cameraPoints[2] = ships[i].transform.Find("Front_Cam_Point");
                    cameraThree.GetComponent<CameraRig>().inputs = ships[i];

                    PlayerHealth playerHealth = ships[i].GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = ships[i].GetComponentInChildren<CheckTrigger>();

                    ships[i].GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/3_Player_Canvas(Clone)/Player_3/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/3_Player_Canvas(Clone)/Player_3/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/3_Player_Canvas(Clone)/Player_3/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/3_Player_Canvas(Clone)/Player_3/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/3_Player_Canvas(Clone)/Player_3/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/3_Player_Canvas(Clone)/Player_3/Finish");
                }
            }

            foreach(PlayerInput players in ships) {
                
                
                
            }

            
        }
        if(MPManager.mpManager.fourP) {
            Instantiate(MPMiniMap);
            GameObject cameraOne = Instantiate(fourPlayers.pOneCamera);
            GameObject cameraTwo = Instantiate(fourPlayers.pTwoCamera);
            GameObject cameraThree = Instantiate(fourPlayers.pThreeCamera);
            GameObject cameraFour = Instantiate(fourPlayers.pFourCamera);

            Instantiate(fourPCanvas);

            foreach(PlayerInput players in ships) {
                if(players.controllerNumber == 1) {
                    cameraOne.GetComponent<CameraRig>().target = players.gameObject.transform;
                    cameraOne.GetComponent<CameraRig>().cameraPoints[2] = players.transform.Find("Front_Cam_Point");
                    cameraOne.GetComponent<CameraRig>().inputs = players;

                    PlayerHealth playerHealth = players.GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = players.GetComponentInChildren<CheckTrigger>();

                    players.GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/4_Player_Canvas(Clone)/Player_1/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/4_Player_Canvas(Clone)/Player_1/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/4_Player_Canvas(Clone)/Player_1/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/4_Player_Canvas(Clone)/Player_1/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/4_Player_Canvas(Clone)/Player_1/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/4_Player_Canvas(Clone)/Player_1/Finish");
                }
                if(players.controllerNumber == 2) {
                    cameraTwo.GetComponent<CameraRig>().target = players.gameObject.transform;
                    cameraTwo.GetComponent<CameraRig>().cameraPoints[2] = players.transform.Find("Front_Cam_Point");
                    cameraTwo.GetComponent<CameraRig>().inputs = players;

                    PlayerHealth playerHealth = players.GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = players.GetComponentInChildren<CheckTrigger>();

                    players.GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/4_Player_Canvas(Clone)/Player_2/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/4_Player_Canvas(Clone)/Player_2/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/4_Player_Canvas(Clone)/Player_2/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/4_Player_Canvas(Clone)/Player_2/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/4_Player_Canvas(Clone)/Player_2/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/4_Player_Canvas(Clone)/Player_2/Finish");
                }
                if(players.controllerNumber == 3) {
                    cameraThree.GetComponent<CameraRig>().target = players.gameObject.transform;
                    cameraThree.GetComponent<CameraRig>().cameraPoints[2] = players.transform.Find("Front_Cam_Point");
                    cameraThree.GetComponent<CameraRig>().inputs = players;

                    PlayerHealth playerHealth = players.GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = players.GetComponentInChildren<CheckTrigger>();

                    players.GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/4_Player_Canvas(Clone)/Player_3/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/4_Player_Canvas(Clone)/Player_3/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/4_Player_Canvas(Clone)/Player_3/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/4_Player_Canvas(Clone)/Player_3/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/4_Player_Canvas(Clone)/Player_3/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/4_Player_Canvas(Clone)/Player_3/Finish");
                }
                if(players.controllerNumber == 4) {
                    cameraFour.GetComponent<CameraRig>().target = players.gameObject.transform;
                    cameraFour.GetComponent<CameraRig>().cameraPoints[2] = players.transform.Find("Front_Cam_Point");
                    cameraFour.GetComponent<CameraRig>().inputs = players;

                    PlayerHealth playerHealth = players.GetComponentInChildren<PlayerHealth>();
                    CheckTrigger check = players.GetComponentInChildren<CheckTrigger>();

                    players.GetComponent<UltCharge>().ultimateSlider = GameObject.Find("/4_Player_Canvas(Clone)/Player_4/Ult_Slider").GetComponent<Slider>();
                    playerHealth.healthSlider = GameObject.Find("/4_Player_Canvas(Clone)/Player_4/Health_Slider").GetComponent<Slider>();
                    playerHealth.damageImage = GameObject.Find("/4_Player_Canvas(Clone)/Player_4/Damage_Image").GetComponent<Image>();
                    check.lapNumber = GameObject.Find("/4_Player_Canvas(Clone)/Player_4/Lap").GetComponent<Text>();
                    check.racePosition = GameObject.Find("/4_Player_Canvas(Clone)/Player_4/Position").GetComponent<Text>();
                    check.finish = GameObject.Find("/4_Player_Canvas(Clone)/Player_4/Finish");
                }
            }

            
        }
    }
}
