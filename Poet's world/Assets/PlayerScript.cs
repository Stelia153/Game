using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite victor0;
    public Sprite victor1;
    public Sprite victor2;
    public Sprite victor3;
    public Camera mainCamera;
    private Vector3 mouse;
    private Vector3 player;
    private float directionX;
    private float directionY;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouse = Input.mousePosition;
            mouse = Camera.main.ScreenToWorldPoint(mouse);
            mouse.y += 5;
            mouse.z = 0;
            player = transform.position;
            directionX = mouse.x - player.x;
            directionY = mouse.y - player.y;
            if (directionY > 0)
            {
                if (directionX > 0)
                {
                    spriteRenderer.sprite = victor0;
                }
                else if (directionX < 0)
                {
                    spriteRenderer.sprite = victor1;
                }
            }
            else if (directionY < 0)
            {
                if (directionX > 0)
                {
                    spriteRenderer.sprite = victor2;
                }
                else if (directionX < 0)
                {
                    spriteRenderer.sprite = victor3;
                }
            }
            
        }
        if (Vector3.Distance(mouse, transform.position) > 1)
        {
            mouse.z = 0;
            transform.position = Vector3.Lerp(transform.position, mouse, Time.deltaTime);
            mouse.z = -10;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, mouse, Time.deltaTime);
        }



    }
}
