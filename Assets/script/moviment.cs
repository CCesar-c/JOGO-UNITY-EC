using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class moviment : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public GameObject arma;
    public float sensi = 200;
    public float force = 1000;
    float rotationX = 0f;
    void Update()
    {
        Vector3 vara = new(0.5f, -0.5f, 1f);
        Vector3 varb = new(-0.04f, -1.27f, 0.09f);
        Quaternion q = new(0, 270, 30, 0);

        float mouseX = Input.GetAxis("Mouse X") * sensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensi * Time.deltaTime;

        // --- Rotación vertical (solo cámara)
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        cam.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // --- Rotación horizontal (solo jugador)
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            arma.transform.SetLocalPositionAndRotation(Vector3.Lerp(vara, varb, 1f * Time.deltaTime), Quaternion.Lerp(arma.transform.localRotation, q, 1f * Time.deltaTime));
            arma.transform.localScale = Vector3.Lerp(arma.transform.localScale, arma.transform.localScale = new Vector3(1, 5, 10), 1f * Time.deltaTime);
        }
        else
        {
            arma.transform.SetLocalPositionAndRotation(Vector3.Lerp(varb, vara, 1f * Time.deltaTime), Quaternion.Lerp(arma.transform.localRotation, new Quaternion(0,270,-10,0), 1f * Time.deltaTime));
            arma.transform.localScale = Vector3.Lerp(arma.transform.localScale, arma.transform.localScale = new Vector3(1, 1, 1), 1f * Time.deltaTime);
        }

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
