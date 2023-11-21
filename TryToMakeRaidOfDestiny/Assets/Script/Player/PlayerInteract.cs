using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]float distance;
    [SerializeField] LayerMask layer;
    [SerializeField] Sprite originalCrossAir;
    [SerializeField] Sprite interactCrossAir;
    private PlayerUI playerUI;
    private InputManager inputManager;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        playerUI.UpdateCrossAir(originalCrossAir);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, layer)) 
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null) 
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promtMessage);
                playerUI.UpdateCrossAir(interactCrossAir);
                if (inputManager.onGround.Interact.triggered) 
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
