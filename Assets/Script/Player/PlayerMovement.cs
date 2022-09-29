using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private float curspeed = 0.5f;
    private float moveX;
    private float moveY;
    private float moveZ;
    private float mouseX;
    private bool sound;

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
        moveX = player.PlayerInput.Horizontal*curspeed;
        moveZ = player.PlayerInput.Vertical*curspeed;
        Vector3 moveVec = new Vector3(moveX,0f,moveZ);

        player.Animator.SetFloat("HorizonSpeed",moveX);
        player.Animator.SetFloat("VerticalSpeed", moveZ);

        if (player.PlayerInput.Run)
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
        if (Vector3.Magnitude(moveVec) > 0.2f&&sound)
        {
            StartCoroutine(SoundGenerate());
        }
        moveVec = transform.forward * moveZ + transform.right * moveX;

        player.CharacterController.Move(moveVec*Time.deltaTime*player.Speed);
    }
    private void MoveY()
    {
        if(player.playerGroundChecker.isGround)
        {
            if(moveY<-2f)
            {
                StartCoroutine(SoundGenerate());
            }
            moveY = 0;
            if(player.PlayerInput.Jump)
            {
                moveY = 4f;
                player.Animator.SetTrigger("Jump");
            }
        }
        else
        {
            moveY += Physics.gravity.y * Time.deltaTime;
        }
        player.CharacterController.Move(Vector3.up * moveY*Time.deltaTime);
    }
    private void Roration()
    {
        mouseX = player.PlayerInput.MouseX * player.MouseSensitive * Time.deltaTime;
        player.gameObject.transform.Rotate(Vector3.up * mouseX);
    }
    IEnumerator SoundGenerate()
    {
        sound = false;
        player.PlayerSoundGenerator.SoundGen();
        yield return new WaitForSeconds(1f);
        sound = true;
    }
}
