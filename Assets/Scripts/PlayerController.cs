using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;


    private Transform transformP;
    public Camera cam;
    private Vector3 relativePosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        transformP = GetComponent<Transform>();
        
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on this GameObject.");
            enabled = false; // Disable the script if no Rigidbody2D is present
        }
    }

    void Update()
    {
        //Movements

        Movement();

        // Animations 

        Animations();

        // View of player
        
        View();

    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D in FixedUpdate for physics calculations
        rb.linearVelocity = moveInput * moveSpeed;
    }
    void Movement()
    {
        // Get input from the horizontal and vertical axes
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize the input vector to prevent faster diagonal movement
        moveInput.Normalize();
    }
    void Animations()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {

            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);

            animator.SetFloat("Speed", 1);

        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

    }
    void View()
    {

        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldMousePosition = cam.ScreenToWorldPoint(mousePosition);

        relativePosition = worldMousePosition - transformP.position;

        string direction = "";
        float angle = Mathf.Atan2(relativePosition.y, relativePosition.x) * Mathf.Rad2Deg;

        if (angle >= -22.5f && angle <= 22.5f)
        {
            // derecha
            direction = "Derecha";
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Shoot");
            }
        }
        else if (angle > 22.5f && angle < 67.5f)
        {
            // arriba-derecha
            direction = "Arriba-Derecha";

        }
        else if (angle >= 67.5f && angle <= 112.5f)
        {
            // arriba
            direction = "Arriba";
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 1);
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Shoot");
            }
        }
        else if (angle > 112.5f && angle < 157.5f)
        {
            // arriba-izquierda
            direction = "Arriba-Izquierda";
        }
        else if (angle >= 157.5f || angle <= -157.5f)
        {
            // izquierda
            direction = "Izquierda";
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Shoot");
            }
        }
        else if (angle < -22.5f && angle > -67.5f)
        {
            // abajo-derecha
            direction = "Abajo-Derecha";
        }
        else if (angle <= -67.5f && angle >= -112.5f)
        {
            // abajo
            direction = "Abajo";
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", -1);
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Shoot");
            }
        }
        else if (angle < -112.5f && angle > -157.5f)
        {
            // abajo-izquierda
            direction = "Abajo-Izquierda";
        }

        Debug.Log("Dirección del mouse: " + direction);


    }

}
