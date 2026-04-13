using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); //So bullet prefabs spawns at firePoint's pos

        float direction = GetComponentInParent<SpriteRenderer>().flipX ? -1f : 1f; //please flip I beg

        bullet.GetComponent<Bullet>().direction = new Vector2(direction, 0);

        Debug.Log("Pistol shoot");
    }
}
