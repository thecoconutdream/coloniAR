using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NordtorCounter : MonoBehaviour
{

    public static int nordtorCounter = 0;

    void OnTriggerStay(Collider collider)
    {
        nordtorCounter = 1;
    }
}
