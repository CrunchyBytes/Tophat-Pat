using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    /* Type = Kinematic
     * => Not affected by Gravity or External Forces: only User inputs.
     */
    public Rigidbody2D rigidBody;

    private Vector2 moveVelocity;
    Touch touch;

    // Gather Input
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            /* touch.position gets the first touch's position, in pixels.
               However, Unity handles coordinates in units.
             * .ScreenToWorldPoint handles conversion from pixels to units.
             */
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        
            if (touchPosition.x <= -0.8f)
                moveVelocity = new Vector2(-1, 0) * speed;
            else if (touchPosition.x >= 1.3f)
                moveVelocity = new Vector2(1, 0) * speed;                                    
        }
        else
            moveVelocity = new Vector2(0, 0);

        /* Edit -> Project Settings... -> Input
         * Left arrow key: Horizontal Input <= -1
         * Right: <= 1
         * Up: Vertical Input <= 1
         * Down: <= -1
         */
        /* GetAxis in itself provides acceleration on top of speed (it speeds up from rest, it slows down to rest)
         * GetAxisRaw is snappy. Moves only when Input is placed. No acceleration.
         */
        /*Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveVelocity = moveInput.normalized * speed;
        */
    }

    // Actually move the character
    /* Called every Physics-step of the game
     * All code related to adjusting Physics should be placed here.
     */
    void FixedUpdate() 
    {        
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime);        
    }

    
}
