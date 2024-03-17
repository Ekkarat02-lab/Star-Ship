using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
// Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0.0f);
        moveDirection *= speed;
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}