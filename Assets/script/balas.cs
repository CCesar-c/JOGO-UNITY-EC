using UnityEngine;


public class balas : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            moviment m = collision.gameObject.GetComponent<moviment>();
            if (m != null)
            {
                m.TakeDamage(Game_manager.gm.dano); // 🔥 aplicamos daño de forma segura
            }
        }

        // 🔥 Se destruye en el servidor → desaparece en todos los clientes
        Destroy(this.gameObject);
    }
}
