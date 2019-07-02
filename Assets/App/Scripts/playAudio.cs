using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{

    public GameObject Information;
    public GameObject CurrentCharacter;
    public GameObject NextCharacter;

    void OnTriggerStay(Collider collider)
    {
        Information.SetActive(true);
    }

    public void EnableNextCharacter()
    {
        NextCharacter.SetActive(true);
        CurrentCharacter.SetActive(false);
    }
}
