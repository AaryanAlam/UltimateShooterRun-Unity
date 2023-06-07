using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float swipeThreshold = 50f;

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;


    private CharacterController characterController;
    public float moveSpeed = 10f;
    Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void LateUpdate()
    {
        characterController.Move(Vector3.forward * moveSpeed * Time.deltaTime);

        if (!characterController.isGrounded)
        {
            velocity.y -= 9.81f * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }

        characterController.Move(velocity * Time.deltaTime);
    }
    private void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                CheckSwipe();
            }
        }
    }


    private void CheckSwipe()
    {
        Vector3 trnsfrm = characterController.transform.position;
        float swipeDistance = Vector2.Distance(fingerDownPosition, fingerUpPosition);

        if (swipeDistance > swipeThreshold)
        {
            Vector2 swipeDirection = fingerUpPosition - fingerDownPosition;
            swipeDirection.Normalize();

            Vector3 moveVector = Vector3.zero;

            if (swipeDirection.x > 0) // Right swipe
            {
                moveVector += Vector3.right;
                if (trnsfrm.x == 6.25)
                {
                    trnsfrm.x = 6.25f;
                    return;
                }
            }
            else if (swipeDirection.x < 0) // Left swipe
            {
                moveVector += Vector3.left;
                if (trnsfrm.x == -6.25)
                {
                    trnsfrm.x = -6.25f;
                    return;
                }
            }

            // Apply movement to the character controller
            characterController.Move(moveVector * 6.25f + velocity * Time.deltaTime);
        }
    }

}




