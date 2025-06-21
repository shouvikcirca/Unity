using UnityEngine;

public class CollisiionHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject destroyedVFX;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Debug.Log(string.Format("Collided with {0}", other.gameObject.name));
    }


}
