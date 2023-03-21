using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePlatform : MonoBehaviour
{
    private Camera mainCamera;
    private float thePlat;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType <Camera>();
        thePlat = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosx = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0 , 0)).x;
        
        this.transform.position = new Vector3(mousePosx,thePlat,0);
    }
}
