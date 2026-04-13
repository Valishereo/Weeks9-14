using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;

    public float speed = 1f;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector3 newPosition = transform.position += (Vector3)direction * speed * Time.deltaTime;

            newPosition.x = Mathf.Clamp(newPosition.x, -10f, 10f); //so it doesn't go out of the borders
            newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);

            transform.position = newPosition;
        }
    }

    public void TakeDamage(float damage) //for enemies to take dmg
    {
        health -= damage;
        Debug.Log("Enemy hit! HP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }

}
