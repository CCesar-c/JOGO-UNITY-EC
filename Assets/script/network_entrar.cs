using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class network_entrar : MonoBehaviour
{
    public NetworkManager networkManager;

    public void StartHost()
    {
        networkManager.StartHost();
    }

    public void StartClient()
    {
        networkManager.StartClient();
    }
}
