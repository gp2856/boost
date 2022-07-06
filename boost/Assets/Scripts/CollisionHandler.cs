using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This object is friendly");
                break;
            case "Finish":
                Debug.Log("You finished the level");
                break;
            default:
                Debug.Log("Sorry you crashed into something");
                break;
        }
    }
}
