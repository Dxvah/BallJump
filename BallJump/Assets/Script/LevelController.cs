using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    
    public GameObject level;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float rotX = Input.GetAxis("Mouse X") * 5f;
            level.transform.Rotate(Vector3.up, -rotX, Space.World);
        }
    }


}









    

