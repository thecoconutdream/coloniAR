using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{

    public GameObject Audio;
    public GameObject CurrentCharacter;
    public GameObject NextCharacter;


    void OnTriggerStay(Collider collider)
    {
        Audio.SetActive(true);
        StartCoroutine(hideCharacter());

    }

    IEnumerator hideCharacter()
    {
        yield return new WaitForSeconds(3);

        CurrentCharacter.SetActive(false);
        NextCharacter.SetActive(true);
    }
}
