using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Homescreen : MonoBehaviour
{
    public GameObject endroom;
    public GameObject colonia;
    public GameObject coloniaEndroom;

    // Start is called before the first frame update
    void Start()
    {
        if (LoadHomeScreen.endButton)
        {
            endroom.SetActive(true);

            if (DialogueManager.active == false)
            {
                coloniaEndroom.SetActive(true);
                FindObjectOfType<DialogueManager>().DialogueWasActive(true);
            }
        }
        else
        {
            colonia.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadHafen()
    {
        SceneManager.LoadScene("Hafenstrasse");
    }

    public void LoadNordtor()
    {
        SceneManager.LoadScene("Nordtor");
    }

    public void LoadEndroom()
    {
        SceneManager.LoadScene("Endroom");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
