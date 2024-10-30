using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFloor : MonoBehaviour
{
    public float jumpForce;

    private void OnCollisionEnter(Collision collision)
    {

        Rigidbody rigidbody = collision.collider.GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
