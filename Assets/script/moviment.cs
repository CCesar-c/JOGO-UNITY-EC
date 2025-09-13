using UnityEngine;

public class moviment : MonoBehaviour
{
    public float vida;
    public Rigidbody rb;
    public Transform cam;

    public float sensi = 200f;
    public float force = 1000f;
    public float armaMoveSpeed; // Velocidad de transición del arma

    private float rotationX = 0f;

    // Posiciones y rotaciones objetivo del arma
    void FixedUpdate()
    {
        Game_manager.gm.vida_slider.value = vida;
        armaMoveSpeed = Game_manager.gm.delay * 5;
        // --- Rotación de cámara y jugador
        float mouseX = Input.GetAxis("Mouse X") * sensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensi * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        cam.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);


        // --- Movimiento del jugador con Rigidbody
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDir += transform.forward;
        if (Input.GetKey(KeyCode.S)) moveDir -= transform.forward;
        if (Input.GetKey(KeyCode.A)) moveDir -= transform.right;
        if (Input.GetKey(KeyCode.D)) moveDir += transform.right;

        rb.AddForce(moveDir.normalized * force * Time.deltaTime, ForceMode.Force);
    }
}
