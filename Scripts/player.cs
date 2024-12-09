using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    SpawnBullet spawnBullet;
    Vector2 direction;
    bool isFiring = true;
    bool isMoving = false;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnBullet = GetComponent<SpawnBullet>();
    }
    void Update()
    {
        if(isMoving)
        {    
            if(rb != null)
            {
             rb.velocity = direction * speed * Time.deltaTime;
            }
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if(isFiring)
        {
            if(context.started)
            {
              spawnBullet.Paste();
            }
        }
        isFiring = false;
        Invoke(nameof(DelayForFire),2f);
    }
    public void Run(InputAction.CallbackContext input)
    {
          direction = input.ReadValue<Vector2>();
        if(input.performed)
        {
          isMoving = true;
        }
        else if (input.canceled)
        {
            isMoving = false;
        }
    }
    private void DelayForFire()
    {
        isFiring = true;
    }
}