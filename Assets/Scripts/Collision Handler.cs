using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float InvokeDelay;
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
            {
                Debug.Log("Here we go!!");
                break;
            }

            case "Fuel":
                {
                    Debug.Log("You arent supposed to be here");
                    break;
                }

            case "Finish":
                {
                    StartLoadSequence();
                    break;
                }

            default:
                {
                   StartCrashSequence();
                   break;
                }
                
        }
    }

    private void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    private void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene",InvokeDelay);
    }

    private void StartLoadSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke ("NextScene",InvokeDelay);
    }
}
