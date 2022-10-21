using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D Player;
    private float inX = 0f;
    // Update is called once per frame
    void Update()
    {
        inX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 moveX = new Vector2(inX*movementSpeed, Player.velocity.y);
        Player.velocity = moveX;
    }
}
