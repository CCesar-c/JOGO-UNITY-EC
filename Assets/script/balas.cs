using UnityEngine;
using Mirror;

public class balas : NetworkBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (!isServer) return; // 🔥 Solo el servidor gestiona daño y destrucción

        if (collision.gameObject.CompareTag("Player"))
        {
            moviment m = collision.gameObject.GetComponent<moviment>();
            if (m != null)
            {
                m.TakeDamage(Game_manager.gm.dano); // 🔥 aplicamos daño de forma segura
            }
        }

        // 🔥 Se destruye en el servidor → desaparece en todos los clientes
        NetworkServer.Destroy(this.gameObject);
    }
}
