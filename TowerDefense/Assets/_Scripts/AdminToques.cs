using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class AdminToques : MonoBehaviour
{
    public InputActionAsset inputs;
    private InputAction toque, posicionToque;
    private Camera mainCamera;

    //apuntador de funciones, almacena una lista de funciones que se tiene que ejecutar en cierto orden siempre y cuando cumplan con la forma e la funcion
    public delegate void MacetaTocada(GameObject plataforma);
    public event MacetaTocada enMacetaTocada;

    private void OnEnable()
    {
        TouchSimulation.Enable();
        inputs.Enable();
        toque = inputs.FindAction("Toque");
        posicionToque = inputs.FindAction("PosicionToque");
        toque.performed += Toque;
    }

    private void OnDisable()
    {
        inputs.Disable();
        TouchSimulation.Disable();
        toque.performed -= Toque;
    }

    public void Toque(InputAction.CallbackContext obj)
    {
        Vector2 posToque2D = posicionToque.ReadValue<Vector2>();
        Vector3 posToque3D = new Vector3(posToque2D.x, posToque2D.y, mainCamera.farClipPlane);
        //farClipPlane = hasta donde renderiza la camara
        Ray rayoPantalla = mainCamera.ScreenPointToRay(posToque3D);
        Debug.Log($"La pantalla fue tocada en la posicion {posToque2D}");
        RaycastHit hit;
        if (Physics.Raycast(rayoPantalla, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.CompareTag("Maceta"))
            {
                Debug.Log("Maceta toacad");
                if (enMacetaTocada != null) enMacetaTocada(hit.transform.gameObject);
            }
        }
        else Debug.Log("No hubo un hit del raycast");
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }
}
