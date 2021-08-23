using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] float transitionDuration = 0.1f;
    [SerializeField] GameObject reticle = null; //crosshair when not scoped
    [SerializeField] GameObject scopeOverlay = null;
    [SerializeField] GameObject weaponCamera = null;
    [SerializeField] Camera mainCamera = null;
    [SerializeField] float scopedFOV = 40f;

    bool isScoped = false;
    float normalFOV;

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

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    void OnUnscoped()
    {
        reticle.SetActive(true);
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }
}
