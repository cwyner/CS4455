using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBean : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(JumpRoutine());
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    IEnumerator JumpRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(waitTime);

            if (isGrounded)
            {
                Vector3 jumpForce = new Vector3(
                    Random.Range(-1f, 1f),
                    Random.Range(1f, 3f),
                    Random.Range(-1f, 1f)
                );

                Vector3 torque = new Vector3(
                    Random.Range(-10f, 10f),
                    Random.Range(-10f, 10f),
                    Random.Range(-10f, 10f)
                );

                rb.AddForce(jumpForce, ForceMode.Impulse);
                rb.AddTorque(torque, ForceMode.Impulse);
            }
        }
    }
}
