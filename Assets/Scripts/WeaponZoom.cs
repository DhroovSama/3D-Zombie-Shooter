using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 
using UnityEngine.InputSystem;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;

    [SerializeField] float normalFOV = 60f;
    [SerializeField] float zoomedFOV = 30f;

    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    //FirstPersonController fpsController;

    void Start()
    {
        fpsCamera = GetComponent<CinemachineVirtualCamera>();
        //fpsController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomView();
        }
        else
        {
            fpsCamera.m_Lens.FieldOfView = normalFOV;
            //fpsCamera.m_Lens.FieldOfView = Mathf.Lerp(fpsCamera.m_Lens.FieldOfView, zoomedFOV, Time.deltaTime * zoomOutSensitivity);
            //fpsCamera.m_Lens.m_Sensitivity = zoomOutSensitivity;
        }
    }
 
    void ZoomView()
    {
        fpsCamera.m_Lens.FieldOfView = zoomedFOV;
        //fpsCamera.m_Lens.FieldOfView = Mathf.Lerp(fpsCamera.m_Lens.FieldOfView, zoomedFOV, Time.deltaTime * zoomInSensitivity);
        //fpsCamera.m_Lens.m_Sensitivity = zoomInSensitivity;
    }
}
