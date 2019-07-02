using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    private Queue<string> sentences = new Queue<string>();
    private bool nextCharacter;

    public GameObject weiterButton;

    public Animator animator;

    private Queue<AudioClip> audioClips = new Queue<AudioClip>();
    public AudioSource audioSource;

    public static bool active;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartDialogue(Dialogue dialogue, AudioClip[] clips, bool triggerNextCharacter)
    {
        animator.SetBool("IsOpen", true);

        if (sentences!= null)
        {
            sentences.Clear();
        }

        if (audioClips != null)
        {
            audioClips.Clear();
        }

        nextCharacter = triggerNextCharacter;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (AudioClip clip in clips)
        {
            audioClips.Enqueue(clip);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if (nextCharacter == true)
            {
                FindObjectOfType<playAudio>().EnableNextCharacter();
            }
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        audioSource.clip = audioClips.Dequeue();
        audioSource.Play();
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04F);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        weiterButton.SetActive(true);
    }

    public void DialogueWasActive(bool act)
    {
        active = act;
    }
}
