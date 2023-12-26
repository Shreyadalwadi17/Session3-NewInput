using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Newip newip;
    public Vector2 Move, Rotation, Joystick;
    float Speed = 5f;
    [SerializeField] Bullet bullet;


    private void Awake()
    {
        newip = new Newip();
    }

    private void OnEnable()
    {
        newip.Enable();
        newip.Player.Move.performed += OnMove;
        newip.Player.Move.canceled += OnMove;

        newip.Player.Rotation.performed += OnRotation;
        newip.Player.Rotation.canceled += OnRotation;

        newip.Player.Joystick.performed += OnJoyStick;
        newip.Player.Joystick.canceled += OnJoyStick;

    }

    private void OnDisable()
    {
        newip.Disable();

        newip.Player.Move.performed -= OnMove;
        newip.Player.Move.canceled -= OnMove;

        newip.Player.Rotation.performed -= OnRotation;
        newip.Player.Rotation.canceled -= OnRotation;

        newip.Player.Joystick.performed -= OnJoyStick;
        newip.Player.Joystick.canceled -= OnJoyStick;


    }

    private void OnMove(InputAction.CallbackContext value)
    {
        Move = value.ReadValue<Vector2>();
    }

    private void OnRotation(InputAction.CallbackContext value)
    {
        Vector2 Rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.up = Rotation;
    }
    public void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void Update()
    {
        transform.Translate(Move * Speed * Time.deltaTime);

    }
    private void OnJoyStick(InputAction.CallbackContext value)
    {
        Joystick = value.ReadValue<Vector2>();
    }



}
