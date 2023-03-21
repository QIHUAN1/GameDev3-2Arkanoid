using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePlatform : MonoBehaviour
{
    private Camera mainCamera;
    
    private float thePlatY;
    private float mousePosX;

    [SerializeField]
    private float platMoveMax;
    [SerializeField]
    private float platMoveMin;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType <Camera>();
        thePlatY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        mousePosX = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0 , 0)).x;
        PlatLimit();
        this.transform.position = new Vector3(mousePosX, thePlatY,0);
    }


    void PlatLimit()
    {
        if(mousePosX > platMoveMax)
        {
            mousePosX = platMoveMax;
        }

        if (mousePosX < platMoveMin)
        {
            mousePosX = platMoveMin;
        }

    }
}
