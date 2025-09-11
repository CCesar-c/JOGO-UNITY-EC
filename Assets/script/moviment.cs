using UnityEngine;

public class moviment : MonoBehaviour
{
    public Rigidbody rb;
    public float force  = 1000;
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(force * Time.deltaTime * transform.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(force * Time.deltaTime * -transform.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(force * Time.deltaTime * -transform.right);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(force * Time.deltaTime * transform.right);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
    }
}
