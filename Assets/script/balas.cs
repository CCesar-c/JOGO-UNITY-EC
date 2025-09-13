using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<moviment>() == null )return;
            collision.gameObject.GetComponent<moviment>().vida -= Game_manager.gm.dano;
            Destroy(this.gameObject);
        }else if (collision.gameObject.tag != "Player"){
            Destroy(this.gameObject);
        }
    }
}
