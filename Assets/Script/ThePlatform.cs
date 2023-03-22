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

    GameController gameController;

    public bool longerBoard;
    public GameObject longBoard;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType <Camera>();
        thePlatY = this.transform.position.y;

        gameObject.transform.position = new Vector3(-1.08f, -4, 0);


        longBoard.SetActive(false);
        longerBoard = false;
    }

    // Update is called once per frame
    void Update()
    {

            mousePosX = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)).x;
            PlatLimit();
            this.transform.position = new Vector3(mousePosX, thePlatY, 0);
        
        
    }
    void PlatLimit()
    {
        
        
            if (mousePosX > platMoveMax && longBoard == false)
            {
                mousePosX = platMoveMax;
            }

            if (mousePosX < platMoveMin && longBoard == false)
            {
                mousePosX = platMoveMin;
            }
        

      
        
            if (mousePosX > platMoveMax && longBoard == true)
            {
                mousePosX = 0.86f;
            }

            if (mousePosX < platMoveMin && longBoard == true)
            {
                mousePosX = -3.46f;
            }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlockRed"))
        {
            Destroy(collision.gameObject);
            //longer board

            longBoard.SetActive(true);
            Invoke("ShorterBoard", 60f);
        }

        if (collision.gameObject.CompareTag("BlockBlue"))
        {
            Destroy(collision.gameObject);
            //stay on board
        }

        if (collision.gameObject.CompareTag("BlockPink"))
        {
            Destroy(collision.gameObject);
            //exit
        }

        if (collision.gameObject.CompareTag("BlockGreen"))
        {
            Destroy(collision.gameObject);
            //longer board
        }
    }

    public void ShorterBoard()
    {
        longBoard.SetActive(false);
        longerBoard = false;
    }
}
