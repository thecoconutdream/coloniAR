﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Homescreen : MonoBehaviour
{
    public GameObject hafenstrasse;
    public GameObject nordtor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is a touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if finger is over a UI element 
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if(EventSystem.current.currentSelectedGameObject == hafenstrasse)
                {
                    SceneManager.LoadScene("Hafenstrasse");
                }
                else if (EventSystem.current.currentSelectedGameObject == nordtor)
                {
                    SceneManager.LoadScene("Test");
                }
                Debug.Log("UI is touched");
                //so when the user touched the UI(buttons) call your UI methods 
            }
        }

    }
}
