using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HafenCounter : MonoBehaviour
{

    public static int hafenCounter = 0;

    void OnTriggerStay(Collider collider)
    {
        hafenCounter = 1;
    }
}

