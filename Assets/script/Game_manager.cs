using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game_manager : MonoBehaviour
{
    public Text text_balas;
    public Slider vida_slider;
    public static Game_manager gm;
    public GameObject[] armass;
     public bool Disparar = false;
    public float dano = 100;
     public int municiones = 5;
    public float delay = 2;
    public GameObject balas;
    public GameObject spaw_balls;

    private Vector3 armaPosAim = new Vector3(-0.02f, -1.29f, -0.12f);
    private Quaternion armaRotAim = Quaternion.Euler(0, 270f, -30f);
    private Vector3 armaScaleAim = new Vector3(1f, 5f, 10f);

    private Vector3 armaPosHip = new Vector3(0.5f, -0.5f, 1.1f);
    private Quaternion armaRotHip = Quaternion.Euler(0f, 270f, -10f);
    private Vector3 armaScaleHip = new Vector3(1f, 1f, 1f);

    void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        text_balas.text = "Balas: " + municiones;

        for (int i = 0; i < armass.Length; i++)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                armass[i].transform.localPosition = Vector3.Lerp(armass[i].transform.localPosition, armaPosAim, 5 * delay * Time.deltaTime);
                armass[i].transform.localRotation = Quaternion.Lerp(armass[i].transform.localRotation, armaRotAim, 5 * delay * Time.deltaTime);
                armass[i].transform.localScale = Vector3.Lerp(armass[i].transform.localScale, armaScaleAim, 5 * delay * Time.deltaTime);
            }
            else
            {
                armass[i].transform.localPosition = Vector3.Lerp(armass[i].transform.localPosition, armaPosHip, 5 * delay * Time.deltaTime);
                armass[i].transform.localRotation = Quaternion.Lerp(armass[i].transform.localRotation, armaRotHip, 5 * delay * Time.deltaTime);
                armass[i].transform.localScale = Vector3.Lerp(armass[i].transform.localScale, armaScaleHip, 5 * delay * Time.deltaTime);
            }

            switch (i)
            {
                case 0:

                    if (Input.GetKeyDown(KeyCode.Mouse0) && !Disparar && municiones > 0)
                    {
                        CmdShoot();
                    }

                    if (Input.GetKeyDown(KeyCode.R) && !Disparar)
                    {
                        CmdReload(5);
                    }
                    break;

                default:
                    print("ERROR");
                    break;
            }
        }


    }


    void CmdShoot()
    {
        if (municiones <= 0 || Disparar) return;

        Disparar = true;
        municiones--;

        GameObject g = Instantiate(balas, spaw_balls.transform.position, spaw_balls.transform.rotation);
        g.GetComponent<Rigidbody>().AddForce(g.transform.forward * 1000);

        StartCoroutine(ResetDisparo());
    }

    IEnumerator ResetDisparo()
    {
        yield return new WaitForSeconds(delay);
        Disparar = false;
    }

    // --- Recarga en el servidor
    void CmdReload(int balas)
    {
        StartCoroutine(ReloadCoroutine(balas));
    }

    IEnumerator ReloadCoroutine(int balas)
    {
        Disparar = true;
        yield return new WaitForSeconds(delay + 1);
        municiones = balas;
        Disparar = false;
    }

}