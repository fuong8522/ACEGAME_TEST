using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class touchJumping : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject playerGameobject;
    public DemoJumping player;
    public bool holder;

    private void Start()
    {
        playerGameobject = GameObject.Find("Player");
        player = playerGameobject.GetComponent<DemoJumping>();
        player.jumpCounter = player.jumpTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log("getkeydown");
        holder = true;

        if (player.OnGround())
        {
            playerGameobject.GetComponent<Rigidbody2D>().velocity = Vector2.up * player.jumpForce;
            player.isJumping = true;
            player.jumpCounter = player.jumpTime;
        }
    }


    private void Update()
    {
        if(holder && player.isJumping)
        {
                if (player.jumpCounter > 0)
                {
                playerGameobject.GetComponent<Rigidbody2D>().velocity = Vector2.up * player.jumpForce;
                    player.jumpCounter -= Time.deltaTime;
                player.isJumping = true;
                }
                else
                {
                    player.isJumping = false;
                }
            
        }
        
        if(holder)
        {
            Debug.Log("getkey");
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("getkeyup");
        holder = false;
        player.isJumping = false;
    }











}


