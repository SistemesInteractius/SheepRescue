using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Variable Declarations
    public MeshRenderer model;  // Reference to the mesh renderer that needs its color changed
    public Color normalColor;   // Default color of the model
    public Color hoverColor;    // Color that should be applied on the model when the pointer is hovering over it

    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColor;
    }

    // Methods called when a pointer enters and exits the attached GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        model.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        model.material.color = normalColor;
    }

}
