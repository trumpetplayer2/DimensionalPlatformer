using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D Player;
    public Transform PlayerLocation;
    private float inX = 0f;
    public float maxFallSpeed = -3f;
    public float jumpPower = 1f;
    private bool canJump = false;
    private float lastY = 0f;
    // Update is called once per frame
    void Update()
    {
        inX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        float moveY = Player.velocity.y;

        if (Input.GetButtonDown("Jump") && Player.velocity.y == 0 && lastY == 0)
        {
            moveY = jumpPower * 7;
        }

        lastY = Player.velocity.y;

        Vector2 moveX = new Vector2(inX * movementSpeed, moveY);
        Player.velocity = moveX;
    }


}
