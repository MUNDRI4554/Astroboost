using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float InvokeDelay;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;
    
    bool IsControllable = true;
    AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision other) 
    {
        if (IsControllable)
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
        IsControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene",InvokeDelay);
    }

    private void StartLoadSequence()
    {
        IsControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke ("NextScene",InvokeDelay);
    }
}
