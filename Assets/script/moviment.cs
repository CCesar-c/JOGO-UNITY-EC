using UnityEngine;

public class moviment : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public float sensi = 200;
    public float force = 1000;
    float rotationX = 0f;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensi * Time.deltaTime;

        // --- Rotación vertical (solo cámara)
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        cam.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // --- Rotación horizontal (solo jugador)
        transform.Rotate(Vector3.up * mouseX);

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
