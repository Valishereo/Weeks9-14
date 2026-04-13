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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //So bullet prefabs spawns at firePoint's pos

        Debug.Log("Pistol shoot");
    }
}
