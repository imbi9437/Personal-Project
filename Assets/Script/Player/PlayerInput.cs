using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerInput : MonoBehaviour
{
    private Player player;

    private float horizontal;
    public float Horizontal { get { return horizontal; } }
    private float vertical;
    public float Vertical { get { return vertical; } }
    private float mouseX;
    public float MouseX { get { return mouseX; } }
    private float mouseY;
    public float MouseY { get { return mouseY; } }
    private bool jump;
    public bool Jump { get { return jump; } }
    private bool run;
    public bool Run { get { return run; } }
    private bool interAction;
    public bool InterAction { get { return interAction; } }
    private bool mouseClick;
    public bool MouseClick { get { return mouseClick; } }
    private bool mousePush;
    public bool MousePush { get { return mousePush; } }

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        jump = Input.GetButtonDown("Jump");
        run = Input.GetButton("Run");
        interAction = Input.GetButtonDown("InterAction");
        mouseClick = Input.GetButtonDown("Fire1");
        mousePush = Input.GetButton("Fire1");
        NumPad();
    }
    private void NumPad()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.QuickSlotNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.QuickSlotNum = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.QuickSlotNum = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.QuickSlotNum = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player.QuickSlotNum = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            player.QuickSlotNum = 6;
        }
    }
}
