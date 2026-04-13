using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 1f;

    public Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime); //so the bullet moves foward after being spawned
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) //when it hits enemy it reduces health
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject); //bullet gets destroyed after touching enemy
        }
    }

}
