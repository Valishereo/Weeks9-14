using UnityEngine;
using System.Collections;

public class FireWeapon : Weapon
{
    public float damage = 1f;
    public float range = 2f;

    public GameObject fireEffect;

    private Coroutine fireCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Shoot() //activates fire when player pressed spacebar/left click
    {
        if (fireCoroutine == null)
        {
            fireEffect.SetActive(true);
            fireCoroutine = StartCoroutine(FireRoutine());
        }

        Debug.Log("Fire weapon shooting");

    }

    public void StopFire() //to stop fire when the player stops pressing spacebar/left click
    {
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
            fireEffect.SetActive(false);
        }
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            Debug.Log("Fire active...");

            yield return new WaitForSeconds(0.2f); //wait time for fire
        }
    }

}