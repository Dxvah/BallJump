using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public float speed = 1f;
    public float sceneWidth;
    private Vector3 pressPoint;
    private Quaternion startRotation;
    private bool dragging = false;

    void Update() 
    {
        if (dragging) 
        {
            float currentDistanceBetweenMousePositions = (Input.mousePosition - pressPoint).x;
            transform.rotation *= Quaternion.Euler(0, currentDistanceBetweenMousePositions / sceneWidth * 360, 0);

        }
    }

    void OnMouseDown() 
    {
        dragging = true;
        pressPoint = Input.mousePosition;
        startRotation = transform.rotation;
    }

    void OnMouseUp() 
    {
        dragging = false;
    }
}









    

