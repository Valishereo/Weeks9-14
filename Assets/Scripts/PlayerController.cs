using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 directionalInput;

    public Weapon currentWeapon; //to identify what weapon the player is currently using

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)directionalInput * speed * Time.deltaTime; 
    }

    public void OnMove(InputAction.CallbackContext context) //For movement of the player with wasd
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context) //For shooting on the current weapon (pistol or fire weapon) with space bar or left click
    {
        if (context.performed)
        {
            Debug.Log("Attack!"); 

            if (currentWeapon != null)
            {
                currentWeapon.Shoot();
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
            Debug.Log("Switched to Fire Weapon");
        }
        else
        {
            currentWeapon = GetComponent<Pistol>(); //When player has fire weapon and Q is pressed then change to pistol
            Debug.Log("Switched to Pistol");
        }
    }


}
