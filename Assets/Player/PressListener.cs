using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PressListener : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public UnityEvent<Vector2> pressedDownScreen;
    public UnityEvent<Vector2> pressedDownWorld;

    public static bool IsPressDown()
    {
        var touchDown = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        var mouseDown = Input.GetMouseButtonDown(0);
       
        return touchDown || mouseDown;
    }

    public static bool IsPointerOverInteractableUI()
    {
        var fingerId = Input.touchCount > 0 ? Input.GetTouch(0).fingerId : -1;
        
        return EventSystem.current.IsPointerOverGameObject(fingerId)
               && EventSystem.current.currentSelectedGameObject != null;
    }

    public static Vector2 GetPressScreenPosition()
    {
        return Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;
    } 
    
    
    public void Update()
    {
        if (IsPressDown() && !IsPointerOverInteractableUI())
        {
            pressedDownScreen.Invoke(GetPressScreenPosition());
            pressedDownWorld.Invoke(mainCamera.ScreenToWorldPoint(GetPressScreenPosition()));
        }
    }
}