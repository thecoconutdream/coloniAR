using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCrown : MonoBehaviour
{

    public GameObject crown;
    // Use this for initialization
    void Start()
    {
        if (CountAction.counter > 0)
        {
            crown.SetActive(true);
        }
    }

}
