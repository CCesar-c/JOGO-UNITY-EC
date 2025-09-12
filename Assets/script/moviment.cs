using UnityEngine;

public class moviment : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public GameObject arma;

    public float sensi = 200f;
    public float force = 1000f;
    public float armaMoveSpeed = 5f; // Velocidad de transición del arma

    private float rotationX = 0f;

    // Posiciones y rotaciones objetivo del arma
    private Vector3 armaPosAim = new Vector3(-0.02f, -1.29f, -0.12f);
    private Quaternion armaRotAim = Quaternion.Euler(0, 270f, -30f);
    private Vector3 armaScaleAim = new Vector3(1f, 5f, 10f);

    private Vector3 armaPosHip = new Vector3(0.5f, -0.5f, 1.1f);
    private Quaternion armaRotHip = Quaternion.Euler(0f, 270f, -10f);
    private Vector3 armaScaleHip = new Vector3(1f, 1f, 1f);

    void FixedUpdate()
    {
        // --- Rotación de cámara y jugador
        float mouseX = Input.GetAxis("Mouse X") * sensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensi * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        cam.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // --- Movimiento del arma
        if (Input.GetKey(KeyCode.Mouse1))
        {
            arma.transform.localPosition = Vector3.Lerp(arma.transform.localPosition, armaPosAim, armaMoveSpeed * Time.deltaTime);
            arma.transform.localRotation = Quaternion.Lerp(arma.transform.localRotation, armaRotAim, armaMoveSpeed * Time.deltaTime);
            arma.transform.localScale = Vector3.Lerp(arma.transform.localScale, armaScaleAim, armaMoveSpeed * Time.deltaTime);
        }
        else
        {
            arma.transform.localPosition = Vector3.Lerp(arma.transform.localPosition, armaPosHip, armaMoveSpeed * Time.deltaTime);
            arma.transform.localRotation = Quaternion.Lerp(arma.transform.localRotation, armaRotHip, armaMoveSpeed * Time.deltaTime);
            arma.transform.localScale = Vector3.Lerp(arma.transform.localScale, armaScaleHip, armaMoveSpeed * Time.deltaTime);
        }

        // --- Movimiento del jugador con Rigidbody
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDir += transform.forward;
        if (Input.GetKey(KeyCode.S)) moveDir -= transform.forward;
        if (Input.GetKey(KeyCode.A)) moveDir -= transform.right;
        if (Input.GetKey(KeyCode.D)) moveDir += transform.right;

        rb.AddForce(moveDir.normalized * force * Time.deltaTime, ForceMode.Force);
    }
}
