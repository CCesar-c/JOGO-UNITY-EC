using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public GameObject[] armass;
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
