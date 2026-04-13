using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 directionalInput;

    public Weapon currentWeapon; //to identify what weapon the player is currently using

    public Sprite blueSprite; //for bullets
    public Sprite orangeSprite; //for fire

    public Transform fireEffect;
    public Transform firePoint;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position += (Vector3)directionalInput * speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -10f, 10f);
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);

        transform.position = newPosition;

        if (directionalInput.x > 0)
        {
            spriteRenderer.flipX = false; // flip to the right

            fireEffect.localScale = new Vector3(1, 1, 1); //change facing direction right
            firePoint.localScale = new Vector3(1, 1, 1);

            fireEffect.localPosition = new Vector3(2.2f, 0.2f, 1); //change pos right
            firePoint.localPosition = new Vector3(1, 0.2f, 1);


        }
        else if (directionalInput.x < 0)
        {
            spriteRenderer.flipX = true; //flip to the left

            fireEffect.localScale = new Vector3(-1, 1, 1); //change facing direction left
            firePoint.localScale = new Vector3(-1, 1, 1);

            fireEffect.localPosition = new Vector3(-2.2f, 0.2f, 1); //change pos lfet
            firePoint.localPosition = new Vector3(-1, 0.2f, 1);
        }


    }

    public void OnMove(InputAction.CallbackContext context) //For movement of the player with wasd
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context) //For shooting on the current weapon (pistol or fire weapon) with space bar or left click
    {
        if (context.performed)
        {
            currentWeapon.Shoot();

            Debug.Log("Attack!"); 
      
        }

        if (context.canceled)
        {
            if (currentWeapon is FireWeapon fireWeapon)
            {
                fireWeapon.StopFire();
            }
        }
    }

    public void OnSwitch(InputAction.CallbackContext context) //for switching weapons when pressing Q
    {
        if (context.performed)
        {
            SwitchWeapon(); //to switch from pistol to fire weapon
        }
    }

    void SwitchWeapon()
    {
        if (currentWeapon is Pistol)
        {
            currentWeapon = GetComponent<FireWeapon>(); //when player has pistol and Q is pressed the change to fire weapon
            spriteRenderer.sprite = orangeSprite;
            Debug.Log("Switched to Fire Weapon");
        }
        else
        {
            currentWeapon = GetComponent<Pistol>(); //When player has fire weapon and Q is pressed then change to pistol
            spriteRenderer.sprite = blueSprite;
            Debug.Log("Switched to Pistol");
        }
    }


}
