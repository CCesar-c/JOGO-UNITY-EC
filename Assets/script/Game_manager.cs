using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public static Game_manager gm;
    public GameObject[] armass;
    public float dano;
    public int municiones;
    public GameObject balas;
    public GameObject spaw_balls;
    
    void start(){
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(this.gameObject);
        }
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            for (int i = 0; i < armass.Length; i++)
        {
            if (armass[i].activeInHierarchy == true)
            {
                print("arma encontrada!!");

                switch (i)
                {
                    case 0:
                        print("sniper activo");
                        dano = 100;
                        municiones = 5;
                        GameObject g = Instantiate(balas, spaw_balls.transform.position, spaw_balls.transform.rotation);
                        g.GetComponent<Rigidbody>().AddForce(g.transform.forward * 1000 * Time.deltaTime);
                        print("disparo");
                        break;

                    default:
                        print("ERROR");
                        break;
                }

            }
            else
            {
                print("Ai algun error");
            }
        }
        }
        
    }
}
