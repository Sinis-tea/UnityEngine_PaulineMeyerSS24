using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHelper : MonoBehaviour
{
    public Transform teleportLocation;
    public Transform controller;
    public GameObject player;

    

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown (KeyCode.Q))
        {
            Teleport();
        }
      if (Input.GetKeyDown(KeyCode.R))
        {
            TeleportLocationToPlayer();
        }

      void Teleport()
        {
            if (teleportLocation != null)
            {
                player.SetActive(false);
                controller.transform.position = teleportLocation.transform.position;
                controller.transform.rotation = teleportLocation.transform.rotation;
                player.SetActive(true);
            }
            else
            {
                Debug.LogWarning("please assign teleport location");
            }
        }
        void TeleportLocationToPlayer()
        {
            if (player != null)
            {
                teleportLocation.position = controller.transform.position;
                teleportLocation.rotation = controller.transform.rotation;
 
            }
        }
    }
}
