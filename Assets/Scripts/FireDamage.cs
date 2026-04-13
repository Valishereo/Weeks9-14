using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float damage = 10f;
    public float damageDelay = 0.1f;

    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) //when fire gets in contact with enemy then
        {
            timer += Time.deltaTime;

            if (timer >= damageDelay)
            {
                collision.GetComponent<Enemy>().TakeDamage(damage); //do 5 dmg, each with a bit of delay in between
                timer = 0f;
            }
        }
    }

}
