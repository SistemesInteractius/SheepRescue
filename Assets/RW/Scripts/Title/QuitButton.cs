using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour, IPointerClickHandler
{
    // OnPointerClick
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }

}
