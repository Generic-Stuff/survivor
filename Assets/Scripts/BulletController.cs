using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float bulletSpeed = 5;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        AutoDestroy();
    }
    public void Shoot(Vector2 direction)
    {
        rigidBody.linearVelocity = direction.normalized * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            transform.parent = collision.transform;
            rigidBody.linearVelocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 1);
        }
        if (collision.CompareTag("Wall"))
        {
            rigidBody.linearVelocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 1);
        }

    }
    private void AutoDestroy()
    {

        Destroy(gameObject, 0.5f);

    }
}
