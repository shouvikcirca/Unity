using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject[] laser;
    [SerializeField] RectTransform crosshair;

    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    ParticleSystem.EmissionModule fire;

    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void MoveCrossHair()
    {
        crosshair.position = Input.mousePosition;
    }

    void Update()
    {
        MoveCrossHair();
        MoveTargetPoint();
        AimLasers();
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject item in laser)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            item.transform.rotation = rotationToTarget;
        }
    }



    public void OnFire(InputValue value)
    {
        Debug.Log("Fired");
        // fire.enabled = value.isPressed;
        foreach (GameObject item in laser)
        {
            fire = item.GetComponent<ParticleSystem>().emission;
            fire.enabled = value.isPressed;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(string.Format("Collided with {0}", other.gameObject.name));
    }




}
