using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Ballhandler : MonoBehaviour
{

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private float respawnDelay;


    GameObject ballHolder;
    private Rigidbody2D currentBallRigidBody;
    private SpringJoint2D currentBallSpringJoint;



    private Camera mainCamera;
    private bool isDragging;

    void Start()
    {
        mainCamera = Camera.main;
        SpawnNewBall();
    }


    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentBallRigidBody == null)
        {
            return;
        }

        // if (!Touchscreen.current.primaryTouch.press.isPressed)
        if (Touch.activeTouches.Count == 0)
        {

            if (isDragging)
            {
                LaunchBall();
            }

            isDragging = false;

            return;
        }

        isDragging = true;
        currentBallRigidBody.isKinematic = true;

        Vector2 touchPosition = new Vector2();

        foreach (Touch touch in Touch.activeTouches)
        {
            touchPosition += touch.screenPosition;
        }

        touchPosition /= Touch.activeTouches.Count;

        // In screen space coordinates
        // Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

       

        // Conversion to world space coordinates
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        currentBallRigidBody.position = worldPosition;

    }


    private void SpawnNewBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
        ballHolder = ballInstance;
        // Quaternion.identity means we don't care about the rotation and set the default
        currentBallRigidBody = ballInstance.GetComponent<Rigidbody2D>();
        currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();

        currentBallSpringJoint.connectedBody = pivot;

    }


    private void LaunchBall()
    {
        currentBallRigidBody.isKinematic = false;
        // currentBallRigidBody = null;

        Invoke("DetachBall", 0.5f);
        

    }


    private void DetachBall()
    {
        currentBallSpringJoint.enabled = false;
        currentBallSpringJoint = null;
        Destroy(ballHolder);
        Invoke("SpawnNewBall", respawnDelay);

    }
}
