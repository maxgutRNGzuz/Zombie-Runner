using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] RigidbodyFirstPersonController fpsController = null;
    [SerializeField] float transitionDuration = 0.1f;
    [SerializeField] GameObject reticle = null; //crosshair when not scoped
    [SerializeField] GameObject scopeOverlay = null;
    [SerializeField] GameObject weaponCamera = null;
    [SerializeField] Camera mainCamera = null;
    [SerializeField] float normalFOV = 60f;
    [SerializeField] float scopedFOV = 40f;
    [SerializeField] float normalMouseSensitivity = 2f;
    [SerializeField] float scopedMouseSensitivity = 0.5f;

    bool isScoped = false;

    void OnDisable()
    {
        OnUnscoped();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("isScoped", isScoped);

            
            if (isScoped == true)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnscoped();
            }
        }
    }

    IEnumerator OnScoped()
    {
        reticle.SetActive(false);

        yield return new WaitForSeconds(transitionDuration);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        mainCamera.fieldOfView = scopedFOV;

        fpsController.mouseLook.XSensitivity = scopedMouseSensitivity;
        fpsController.mouseLook.YSensitivity = scopedMouseSensitivity;
    }

    public void OnUnscoped()
    {
        reticle.SetActive(true);
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;

        fpsController.mouseLook.XSensitivity = normalMouseSensitivity;
        fpsController.mouseLook.YSensitivity = normalMouseSensitivity;
    }
}
