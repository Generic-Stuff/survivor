using UnityEngine;

public class BulletSpawner : MonoBehaviour
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
        
    }
}
