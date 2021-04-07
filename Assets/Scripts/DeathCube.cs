using UnityEngine;

public class DeathCube : MonoBehaviour
{

    public GameObject respawnPoint;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            other.transform.position = respawnPoint.transform.position;

        }
    }

}
