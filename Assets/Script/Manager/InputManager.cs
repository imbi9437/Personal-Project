using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager : Singleton<InputManager>
{
    /*-----UI-----*/
    private bool iButton;
    public bool IButton { get { return iButton; } }
    private bool qButton;
    public bool QButton { get { return qButton; } }
    private bool escButton;
    public bool EscButton { get { return escButton; } }

    /*-----moveMent-----*/
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

    /*-----interaction-----*/
    private bool interAction;
    public bool InterAction { get { return interAction; } }
    private bool mouseLeftClick;
    public bool MouseLeftClick { get { return mouseLeftClick; } }
    private bool mouseRightClick;
    public bool MouseRightClick { get { return mouseRightClick; } }
    private bool mousePush;
    public bool MousePush { get { return mousePush; } }

    /*-----AlphaNum-----*/
    private bool alpha1;
    public bool Alpha1 { get { return alpha1; } }
    private bool alpha2;
    public bool Alpha2 { get { return alpha2; } }
    private bool alpha3;
    public bool Alpha3 { get { return alpha3; } }
    private bool alpha4;
    public bool Alpha4 { get { return alpha4; } }
    private bool alpha5;
    public bool Alpha5 { get { return alpha5; } }
    private bool alpha6;
    public bool Alpha6 { get { return alpha6; } }


    private void Update()
    {
        iButton = Input.GetButtonDown("Inventory");
        qButton = Input.GetButtonDown("Quest");
        escButton = Input.GetButtonDown("Cancel");

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        jump = Input.GetButtonDown("Jump");
        run = Input.GetButton("Run");

        interAction = Input.GetButtonDown("InterAction");
        mouseLeftClick = Input.GetButtonDown("Fire1");
        mouseRightClick = Input.GetButtonDown("Fire2");
        mousePush = Input.GetButton("Fire1");

        alpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        alpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        alpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        alpha4 = Input.GetKeyDown(KeyCode.Alpha4);
        alpha5 = Input.GetKeyDown(KeyCode.Alpha5);
        alpha6 = Input.GetKeyDown(KeyCode.Alpha6);
    }

}
