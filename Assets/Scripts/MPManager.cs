//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;

//public class MPManager : MonoBehaviour {
//    public static MPManager mpManager;

//    public bool oneP;
//    public bool twoP;
//    public bool threeP;
//    public bool fourP;

//    public int pOne;
//    public int pTwo;
//    public int pThree;
//    public int pFour;

//    public bool pOneKeyboard;
//    public bool pTwoKeyboard;
//    public bool pThreeKeyboard;
//    public bool pFourKeyboard;

//    private void Awake() {
//        if(mpManager == null) {
//            DontDestroyOnLoad(gameObject);
//            mpManager = this;
//        } else if(mpManager != this) {
//            Destroy(gameObject);
//        }
//    }

//    private void OnEnable() {
//        Load();
//    }

//    public void Save() {
//        BinaryFormatter binaryFormatter = new BinaryFormatter();
//        FileStream file = File.Create(Application.persistentDataPath + "/shipChoice.dat");

//        MPManagerData data = new MPManagerData();
//        data.oneP = oneP;
//        data.twoP = twoP;
//        data.threeP = threeP;
//        data.fourP = fourP;

//        data.pOne = pOne;
//        data.pTwo = pTwo;
//        data.pThree = pThree;
//        data.pFour = pFour;

//        data.pOneKeyboard = pOneKeyboard;
//        data.pTwoKeyboard = pTwoKeyboard;
//        data.pThreeKeyboard = pThreeKeyboard;
//        data.pFourKeyboard = pFourKeyboard;

//        binaryFormatter.Serialize(file, data);
//        file.Close();
//    }

//    public void Load() {
//        if(File.Exists(Application.persistentDataPath + "/shipChoice.dat")) {
//            BinaryFormatter binaryFormatter = new BinaryFormatter();
//            FileStream file = File.Open(Application.persistentDataPath + "/shipChoice.dat", FileMode.Open);
//            MPManagerData data = (MPManagerData)binaryFormatter.Deserialize(file);

//            oneP = data.oneP;
//            twoP = data.twoP;
//            threeP = data.threeP;
//            fourP = data.fourP;

//            pOne = data.pOne;
//            pTwo = data.pTwo;
//            pThree = data.pThree;
//            pFour = data.pFour;

//            pOneKeyboard = data.pOneKeyboard;
//            pTwoKeyboard = data.pTwoKeyboard;
//            pThreeKeyboard = data.pThreeKeyboard;
//            pFourKeyboard = data.pFourKeyboard;
            
//        }
//    }

//}

//[System.Serializable]
//class MPManagerData {
//    public bool oneP;
//    public bool twoP;
//    public bool threeP;
//    public bool fourP;

//    public int pOne;
//    public int pTwo;
//    public int pThree;
//    public int pFour;

//    public bool pOneKeyboard;
//    public bool pTwoKeyboard;
//    public bool pThreeKeyboard;
//    public bool pFourKeyboard;
//}
