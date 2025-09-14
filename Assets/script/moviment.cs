using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
public class moviment : NetworkBehaviour
{
    [SyncVar] public float vida = 100f;

    public Rigidbody rb;
    public Transform cam;

    public float sensi = 200f;
    public float force = 1000f;

    private float rotationX = 0f;

    void Start()
    {
        if (!isLocalPlayer)
        {
            cam.gameObject.SetActive(false); // 🔥 Cada jugador ve solo su cámara
            return;
        }
    }
    public void TakeDamage(float amount)
    {
        if (!isServer) return; // 🔥 Solo el servidor cambia la vida
        vida -= amount;

        if (vida <= 0)
        {
            Debug.Log("Jugador murió");
            // Aquí podrías hacer respawn, deshabilitar movimiento, etc.
        }
    }
    void FixedUpdate()
    {
        if (!isLocalPlayer) return;

        // Actualizar UI (solo para el jugador local)
        if (Game_manager.gm != null)
            Game_manager.gm.vida_slider.value = vida;

        // --- Rotación cámara y jugador
        float mouseX = Input.GetAxis("Mouse X") * sensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensi * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        cam.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // --- Movimiento
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDir += transform.forward;
        if (Input.GetKey(KeyCode.S)) moveDir -= transform.forward;
        if (Input.GetKey(KeyCode.A)) moveDir -= transform.right;
        if (Input.GetKey(KeyCode.D)) moveDir += transform.right;

        // Enviar movimiento al servidor
        CmdMove(moveDir.normalized);
    }

    [Command]
    void CmdMove(Vector3 dir)
    {
        // Aplica la fuerza en el servidor
        rb.AddForce(dir * force * Time.fixedDeltaTime, ForceMode.Force);
    }
}
