using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    private float moveHorizontal;
    private float moveVertical;
    
    private Rigidbody rigidBody;
    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        moveHorizontal = Input.GetAxis ("Horizontal");
        moveVertical = Input.GetAxis ("Vertical");

        Vector2 targetVelocity = new Vector2( moveHorizontal * playerSpeed, moveVertical * playerSpeed);

        rigidBody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidBody.velocity.y, targetVelocity.y);
    }
}
