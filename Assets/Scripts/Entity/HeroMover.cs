using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private readonly int _degreesRotation = 180;

    public void Run(Transform transform, int speed, string Horizontal)
    {
        if (Input.GetAxis(Horizontal) > 0)
        {
            Flip(0, transform);
        }

        if (Input.GetAxis(Horizontal) < 0)
        {
            Flip(_degreesRotation, transform);
        }

        Vector3 directionVector = Vector3.right * Input.GetAxisRaw(Horizontal);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + directionVector, speed * Time.deltaTime);
    }

    public void Jump(Rigidbody2D rigidbody2D, Transform transform, float jumpForce, bool isGrounded)
    {
        if (isGrounded)
        {
            rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Flip(int degreesRotation, Transform transform)
    {
        Quaternion _rotation = transform.rotation;

        _rotation.y = degreesRotation;
        transform.rotation = _rotation;
    }
}
