using UnityEngine;

public class moviment : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(force * transform.forward);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(force * Time.deltaTime * -transform.forward);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(force * Time.deltaTime * -transform.right);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(force * Time.deltaTime * transform.right);
        }
    }
}
