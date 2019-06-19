using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHomeScreen : MonoBehaviour
{
    public bool endScene;

    public static bool endButton;
    // Start is called before the first frame update
    public void LoadScene()
    {
        if (HafenCounter.hafenCounter == 1 && NordtorCounter.nordtorCounter == 1)
        {
            if (endScene)
            {
                endButton = true;
                SceneManager.LoadScene("Home");
            }
            else
            {
                endButton = true;
                SceneManager.LoadScene("Endroom");
            }
        }

        else
        {
            endButton = true;
            SceneManager.LoadScene("Home");
        }
    }
}
