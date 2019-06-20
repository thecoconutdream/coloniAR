using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCrown : MonoBehaviour
{

    public GameObject crown;
    public GameObject hafen;
    public GameObject nordtor;
    public GameObject closed;
    public GameObject complete;

    public GameObject claudiaWinning;
    public GameObject claudiaHafen;
    public GameObject claudiaNordtor;
    public GameObject ClaudiaClosed;
    public GameObject ClaudiaComplete;

    // Use this for initialization
    void Start()
    {
        if (HafenCounter.hafenCounter == 1 && NordtorCounter.nordtorCounter == 1)
        {
            if (CountActionHafen.counter > 0 && CountActionNordtor.counter > 0)
            {
                nordtor.SetActive(false);
                hafen.SetActive(false);
                closed.SetActive(false);
                complete.SetActive(true);

                ClaudiaComplete.SetActive(false);
                claudiaHafen.SetActive(false);
                claudiaNordtor.SetActive(false);
                ClaudiaClosed.SetActive(false);

                claudiaWinning.SetActive(true);
                crown.SetActive(true);
            }
            else
            {
                nordtor.SetActive(false);
                hafen.SetActive(false);
                closed.SetActive(false);

                claudiaWinning.SetActive(false);
                claudiaHafen.SetActive(false);
                claudiaNordtor.SetActive(false);
                ClaudiaClosed.SetActive(false);

                ClaudiaComplete.SetActive(true);
                complete.SetActive(true);
            }
        }

        else if (HafenCounter.hafenCounter == 1 && NordtorCounter.nordtorCounter == 0)
        {
            if (CountActionHafen.counter > 0)
            {
                nordtor.SetActive(false);
                closed.SetActive(false);

                ClaudiaComplete.SetActive(false);
                claudiaWinning.SetActive(false);
                claudiaNordtor.SetActive(false);
                ClaudiaClosed.SetActive(false);

                claudiaHafen.SetActive(true);
                hafen.SetActive(true);
            }

            else
            {
                hafen.SetActive(false);
                nordtor.SetActive(false);
                complete.SetActive(false);

                ClaudiaComplete.SetActive(false);
                claudiaHafen.SetActive(false);
                claudiaNordtor.SetActive(false);
                claudiaWinning.SetActive(false);

                ClaudiaClosed.SetActive(true);
                closed.SetActive(true);
            }
        }

        else if (HafenCounter.hafenCounter == 0 && NordtorCounter.nordtorCounter == 1)
        {
            if (CountActionNordtor.counter > 0)
            {
                hafen.SetActive(false);
                closed.SetActive(false);

                ClaudiaComplete.SetActive(false);
                claudiaHafen.SetActive(false);
                claudiaWinning.SetActive(false);
                ClaudiaClosed.SetActive(false);

                claudiaNordtor.SetActive(true);
                nordtor.SetActive(true);
            }
            else
            {
                hafen.SetActive(false);
                nordtor.SetActive(false);
                complete.SetActive(false);

                ClaudiaComplete.SetActive(false);
                claudiaHafen.SetActive(false);
                claudiaNordtor.SetActive(false);
                claudiaWinning.SetActive(false);

                ClaudiaClosed.SetActive(true);
                closed.SetActive(true);
            }
        }
    }
}
