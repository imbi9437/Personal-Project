using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player = null;
    private float curspeed = 0.5f;
    private float moveX;
    private float moveY;
    private float moveZ;
    private float mouseX;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        Move();
        MoveY();
        Roration();
    }

    private void Move()
    {
        moveX = player.playerInput.Horizontal*curspeed;
        moveZ = player.playerInput.Vertical*curspeed;
        Vector3 moveVec = new Vector3(moveX,0f,moveZ);

        player.animator.SetFloat("HorizonSpeed",moveX);
        player.animator.SetFloat("VerticalSpeed", moveZ);

        if (player.playerInput.Run)
        {
            curspeed += Time.deltaTime;
            if (curspeed > 1f)
            {
                curspeed = 1f;
            }
        }
        else
        {
            curspeed-= Time.deltaTime;
            if (curspeed<0.5f)
            {
                curspeed = 0.5f;
            }
        }
        moveVec = transform.forward * moveZ + transform.right * moveX;

        player.characterController.Move(moveVec*Time.deltaTime*player.Speed);
    }
    private void MoveY()
    {
        if(player.playerGroundChecker.isGround)
        {
            moveY = 0;
            if(player.playerInput.Jump)
            {
                moveY = 4f;
                player.animator.SetTrigger("Jump");
            }
        }
        else
        {
            moveY += Physics.gravity.y * Time.deltaTime;
        }
        player.characterController.Move(Vector3.up * moveY*Time.deltaTime);
    }
    private void Roration()
    {
        mouseX = player.playerInput.MouseX * player.MouseSensitive * Time.deltaTime;
        player.gameObject.transform.Rotate(Vector3.up * mouseX);
    }

}
