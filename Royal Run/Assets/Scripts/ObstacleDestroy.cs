using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
