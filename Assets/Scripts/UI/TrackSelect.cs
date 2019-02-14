using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSelect : MonoBehaviour
{
    GameObject[] trackList;
    int index;

    MainMenu mainMenu;

    // Use this for initialization
    void Start()
    {
        mainMenu = GetComponentInParent<MainMenu>();
        trackList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            trackList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject track in trackList)
        {
            if (track != trackList[0])
            {
                track.SetActive(false);
            }
        }
    }

    public void Next()
    {
        trackList[index].SetActive(false);

        index++;
        if (index == trackList.Length)
        {
            index = 0;
        }

        trackList[index].SetActive(true);
    }

    public void Previous()
    {
        trackList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = trackList.Length - 1;
        }

        trackList[index].SetActive(true);
    }

    public void Confirm()
    {
        mainMenu.level = trackList[index].name;
    }

    public void Back()
    {
        trackList[index].SetActive(false);
        index = 0;
        trackList[index].SetActive(true);
    }
}
