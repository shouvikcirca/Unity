using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] float checkpointTimeExtension = 5f;

    GameManager gameManager;

    const string playerString = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            gameManager.IncreaseTime(checkpointTimeExtension);
        }
    }

}
