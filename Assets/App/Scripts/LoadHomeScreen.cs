using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHomeScreen : MonoBehaviour
{
    public bool endScene;
    // Start is called before the first frame update
    public void LoadScene()
    {
        if (HafenCounter.hafenCounter == 1 && NordtorCounter.nordtorCounter == 1)
        {
            if (endScene)
            {
                SceneManager.LoadScene("Home");
            }
            else
            {
                SceneManager.LoadScene("Endroom");
            }
        }

        else
        {
            SceneManager.LoadScene("Home");
        }
    }
}
