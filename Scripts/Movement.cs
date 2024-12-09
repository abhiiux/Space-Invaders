using UnityEngine;

public class Movement : MonoBehaviour
{
    float moveSpeed = 2f;
    Transform enemy;
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public float speed = 0.2f;
    float repeatTime;
    
    void Awake()
    {
        enemy = GetComponent<Transform>();
    }
    void Start()
    {
        direction = Vector2.left;
    }
    void FixedUpdate()
    {
        if(Time.time >= repeatTime)
        {
            MoveSideWays();
            repeatTime = moveSpeed + Time.time;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Change"))
        {
          enemy.Translate( Vector2.down * speed);
          ChangeDirection();
        }
    }
    private void MoveSideWays()
    {
        enemy.Translate( direction * speed );
    }
    private void ChangeDirection()
    {
        if (direction == Vector2.left)
        {
            direction = Vector2.right;
        }
        else if(direction == Vector2.right)
        {
            direction = Vector2.left;
        }
    }
}
