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
    private bool sound;
    private bool footStep = true;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        Move();
        MoveY();
    }

    private void Move()
    {
        moveX = InputManager.instance.Horizontal*curspeed;
        moveZ = InputManager.instance.Vertical*curspeed;
        Vector3 moveVec = new Vector3(moveX,0f,moveZ);

        player.Animator.SetFloat("HorizonSpeed",moveX);
        player.Animator.SetFloat("VerticalSpeed", moveZ);

        if (InputManager.instance.Run)
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
        if (moveVec.magnitude>0.3f && footStep&&player.PlayerGroundChecker.isGround)
        {
            StartCoroutine(FootSteps(0.25f/curspeed));
        }

        player.CharacterController.Move(moveVec*Time.deltaTime*player.Speed);
    }
    private void MoveY()
    {
        if(player.PlayerGroundChecker.isGround)
        {
            if(moveY<-2f)
            {
                StartCoroutine(SoundGenerate());
            }
            moveY = 0;
            if(InputManager.instance.Jump)
            {
                moveY = 6f;
                player.Animator.SetTrigger("Jump");
            }
        }
        else
        {
            moveY += Physics.gravity.y * Time.deltaTime;
        }
        player.CharacterController.Move(Vector3.up * moveY*Time.deltaTime);
    }
    IEnumerator SoundGenerate()
    {
        sound = false;
        player.PlayerSoundGenerator.SoundGen();
        yield return new WaitForSeconds(1f);
        sound = true;
    }
    IEnumerator FootSteps(float value)
    {
        footStep = false;
        //SoundManager.instance.Play(player.PlayerAudio[0]);
        player.AudioSource.clip = player.PlayerAudio[0];
        player.AudioSource.Play();
        yield return new WaitForSeconds(value);
        footStep = true;
    }
}
