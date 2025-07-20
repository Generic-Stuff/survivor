using UnityEngine;
using Game.Utils;
using Game.Utils.GenericLogs;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Transform transformP;

    public Camera cam;
    public float moveSpeed = 5f;


    private Vector2 moveInput;
    private Vector3 relativePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transformP = GetComponent<Transform>();

        if (rb == null)
        {
            Debug.LogError(GenericLogMessages.RightBodyNotFound);
            enabled = false;
        }
    }

    void Update()
    {
        Movement();
        Animations();
        View();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
    void Movement()
    {
        moveInput.x = Input.GetAxisRaw(PlayerConstants.AnimHorizontal);
        moveInput.y = Input.GetAxisRaw(PlayerConstants.AnimVertical);

        moveInput.Normalize();
    }
    void Animations()
    {
        float horizontal = Input.GetAxisRaw(PlayerConstants.AnimHorizontal);
        float vertical = Input.GetAxisRaw(PlayerConstants.AnimVertical);

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat(PlayerConstants.AnimHorizontal, horizontal);
            animator.SetFloat(PlayerConstants.AnimVertical, vertical);
            animator.SetFloat(PlayerConstants.Speed, 1);

        }
        else
        {
            animator.SetFloat(PlayerConstants.Speed, 0);
        }

    }
    void View()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = cam.ScreenToWorldPoint(mousePosition);

        float angle = Mathf.Atan2(relativePosition.y, relativePosition.x) * Mathf.Rad2Deg;
        // Currently, we are not using this variable
        string direction;
        
        relativePosition = worldMousePosition - transformP.position;

        if (angle >= PlayerConstants.NegativeRightAngle && angle <= PlayerConstants.PositiveRightAngle)
        {
            direction = PlayerConstants.Right;
            animator.SetFloat(PlayerConstants.AnimHorizontal, 1);
            animator.SetFloat(PlayerConstants.AnimVertical, 0);
            if (Input.GetMouseButtonDown(0))
                animator.SetTrigger(PlayerConstants.AnimShoot);
        }
        else if (angle > PlayerConstants.PositiveRightAngle && angle < PlayerConstants.UpRightLessAngle)
        {
            direction = PlayerConstants.UpRight;
        }
        else if (angle >= PlayerConstants.UpAngle && angle <= PlayerConstants.UpAngleSecondary)
        {
            direction = PlayerConstants.Up;
            animator.SetFloat(PlayerConstants.AnimHorizontal, 0);
            animator.SetFloat(PlayerConstants.AnimVertical, 1);
            if (Input.GetMouseButtonDown(0))
                animator.SetTrigger(PlayerConstants.AnimShoot);
        }
        else if (angle > PlayerConstants.UpAngleSecondary && angle < PlayerConstants.PositiveLeftAngle)
        {
            direction = PlayerConstants.UpLeft;
        }
        else if (angle >= PlayerConstants.PositiveLeftAngle || angle <= PlayerConstants.NegativeLeftAngle)
        {
            direction = PlayerConstants.Left;
            animator.SetFloat(PlayerConstants.AnimHorizontal, -1);
            animator.SetFloat(PlayerConstants.AnimVertical, 0);
            if (Input.GetMouseButtonDown(0))
                animator.SetTrigger(PlayerConstants.AnimShoot);
        }
        else if (angle < PlayerConstants.DownRightGreaterAngle && angle > PlayerConstants.DownRightLessAngle)
        {
            direction = PlayerConstants.DownRight;
        }
        else if (angle <= PlayerConstants.DownAngleUpper && angle >= PlayerConstants.DownAngleLower)
        {
            direction = PlayerConstants.Down;
            animator.SetFloat(PlayerConstants.AnimHorizontal, 0);
            animator.SetFloat(PlayerConstants.AnimVertical, -1);
            if (Input.GetMouseButtonDown(0))
                animator.SetTrigger(PlayerConstants.AnimShoot);
        }
        else if (angle < PlayerConstants.DownLeftGreaterAngle && angle > PlayerConstants.DownLeftLessAngle)
        {
            direction = PlayerConstants.DownLeft;
        }
    }
}
