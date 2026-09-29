using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
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
                    Debug.Log("Hey you finally reached");
                    break;
                }

            default:
                {
                    Debug.Log("SWIM AWAY IMMEDIATELY");
                    break;
                }
                
        }
    }
}
