using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool triggerNextCharacter = false;
    public Dialogue dialogue;
    public AudioClip[] clips;

    void Start()
    {
        TriggerDialogue();
    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, clips, triggerNextCharacter);
    }
}
