using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
