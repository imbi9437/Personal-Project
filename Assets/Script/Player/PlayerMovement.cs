using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : StateMachineBehaviour
{
    private Player player = null;
    private float curspeed = 1f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(player ==null)
        {
            player = animator.GetComponent<Player>();
        }
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Move();
        Jump();
        Interaction();
    }

    private void Move()
    {
        Vector3 moveInput = new Vector3(player.playerInput.Horizontal, 0f, player.playerInput.Vertical);

        if (player.playerInput.Kneel)
        {
            curspeed -= Time.deltaTime;
            if(curspeed<0.5f)
            {
                curspeed = 0.5f;
            }
        }
        else if (player.playerInput.Run)
        {
            curspeed += Time.deltaTime;
            if(curspeed>2f)
            {
                curspeed = 2f;
            }
        }
        else
        {
            if(curspeed<1f)
            {
                curspeed -= Time.deltaTime;
                if(curspeed<1f)
                {
                    curspeed = 1f;
                }
            }
            else
            {
                curspeed += Time.deltaTime;
                if(curspeed>1f)
                {
                    curspeed = 1f;
                }
            }
        }

        moveInput *= curspeed;

        Vector3 forwardVec = new Vector3(player.playerCam.transform.forward.x, 0f, player.playerCam.transform.forward.z).normalized;
        Vector3 rightVec = new Vector3(player.playerCam.transform.right.x, 0f, player.playerCam.transform.right.z).normalized;

        Vector3 moveVec = moveInput.z*forwardVec + moveInput.x*rightVec;

        player.animator.SetFloat("RightSpeed",rightVec.magnitude);
        player.animator.SetFloat("FowordSpeed", forwardVec.magnitude);
        player.animator.SetFloat("MoveSpeed", moveVec.magnitude);

        player.gameObject.transform.localRotation = Quaternion.LookRotation(moveVec);
        player.characterController.Move(moveVec * Time.deltaTime * player.Speed);
    }
    private void Jump()
    {

    }
    private void Interaction()
    {

    }

}
