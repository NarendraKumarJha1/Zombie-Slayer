using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] GameObject zoomCanva;
    [SerializeField] float zoomedIn = 20f;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] float zoomedInSensitivity = 2f;
    [SerializeField] float zoomedOutSensitivity = .5f;
    bool zoomedInToggle = false;
    private void OnDisable()
    {
        ZoomOut();
    }
    private void Start()
    {
        zoomCanva.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (zoomedInToggle == true)
            {
                ZoomOut();
            }
        }
    }
    void ZoomIn()
    {
        zoomedInToggle = true;
        zoomCanva.SetActive(true);
        fpsCamera.fieldOfView = zoomedIn;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
        if(GetComponentInChildren<SkinnedMeshRenderer>()!=null)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
        if (GetComponentInChildren<MeshRenderer>()!=null)
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        if (GetComponent<MeshRenderer>()!=null)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ZoomOut();
        }
    }
    void ZoomOut()
    {
        if(GetComponentInChildren<SkinnedMeshRenderer>())
        {
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        }
        if (GetComponentInChildren<MeshRenderer>())
        {
            GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        zoomedInToggle = false;
        zoomCanva.SetActive(false);
        fpsCamera.fieldOfView = zoomedOut;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }

}
