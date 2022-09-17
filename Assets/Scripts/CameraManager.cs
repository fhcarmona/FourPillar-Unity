using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private GameObject player;
    private Vector3 cameraOffset = new Vector3(0, 4, -8);
    private CinemachineVirtualCamera carCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Get the objects
        player = GameObject.FindGameObjectWithTag("Player");
        carCamera = GameObject.FindGameObjectWithTag("AuxCamera").GetComponent<CinemachineVirtualCamera>();

        // Set the camera to car
        carCamera.Follow = player.transform;
        carCamera.LookAt = player.transform;
    }
}
