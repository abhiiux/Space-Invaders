using UnityEngine;
public class Shoot : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 0f;
    [SerializeField] bool isDirectionUp = false;
    [SerializeField] bool doubleCheck = false;
    Rigidbody2D bullet;
    Vector2 direction;
    void Awake()
    {
        bullet = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        DecideDirection();
        Fire();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            CheckCollision(col.gameObject,false);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") & doubleCheck)
        {
            CheckCollision(other.gameObject,true);
        }        
    }

    public void Fire()
    {
     bullet.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }
    private void DecideDirection()
    {
     if(isDirectionUp)
     {
        direction = Vector2.up;
     }
     else
     {
        direction = Vector2.down;
     }
    }
    private void CheckCollision(GameObject obj,bool check)
    {
        if(obj.TryGetComponent<Death>(out Death dead))
        {
        if(dead != null)
            {
            dead.Die(check);
            Destroy(this.gameObject);
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            gameManager.HowWins(check);            
            }
        }       
    }
}
