using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform target;
    public Camera mainCamera;
    void Start()
    {
    
        if (target == null)
        {
            target = transform;
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

    }
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            ViewMovement();
        }
    }
    private void ViewMovement()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3 lookAtDirection = mouseWorldPosition - target.position;
        target.right = lookAtDirection;
        
        // Flip
        if (lookAtDirection.x < 0)
        {
            target.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            target.localScale = new Vector3(1, 1, 1);
        }
        
    }
}
