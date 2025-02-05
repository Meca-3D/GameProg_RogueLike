using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] IA_PlayerMovement controls = null;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private InputAction movementAction = null;

    private void Awake()
    {
        controls = new IA_PlayerMovement();
    }

    private void OnEnable()
    {
        movementAction = controls.Movement.Move;
        movementAction.Enable();
    }

    void Move()
    {
        Vector2 dir = movementAction.ReadValue<Vector2>();
        transform.position += (transform.right * movementSpeed * Time.deltaTime * dir.x) + (transform.up * movementSpeed * Time.deltaTime * dir.y);
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }
}
