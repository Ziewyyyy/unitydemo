using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    Vector2 player_movement;

    private void Update()
    {
        player_movement.x = Input.GetAxisRaw("Horizontal");
        player_movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + player_movement * movespeed * Time.fixedDeltaTime);
    }

}
 