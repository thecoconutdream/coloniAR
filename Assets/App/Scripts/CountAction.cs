using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountAction : MonoBehaviour
{

    public static int counter = 0;

    void OnTriggerStay(Collider collider)
    {
        counter += 1;
    }
}
