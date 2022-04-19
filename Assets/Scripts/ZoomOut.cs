using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomOut : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;


    Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        ZoomCameraOut();
    }

    void ZoomCameraOut()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("isZoomedOut", true);
        }

        Invoke(nameof(SetBoolFalse), 2);
        
    }

    void SetBoolFalse() 
    {
        animator.SetBool("isZoomedOut", false);
    }


}
