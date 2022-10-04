using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIChange : MonoBehaviour
{
    private GameObject curUi;

    [SerializeField]
    private GameObject uiOutside;
    public GameObject UiOutside { get { return uiOutside; } }
    [SerializeField]
    private GameObject[] ui;
    [SerializeField]
    private AudioClip[] UiSound;

    public GameObject interactionUi;

    [SerializeField, Header("UIscript")]
    public InventoryUI playerInventory;
    public InventoryUI quickSlot;
    public InventoryUI armorSlot;
    public InventoryUI interactionSlot;
    public MoveSlot usingSlot;

    [SerializeField]
    private TextMeshProUGUI ItemCheckEffect;

    [SerializeField,Header("HP")]
    private TextMeshProUGUI hpText;
    [SerializeField]
    private Slider hpSlider;

    private void Awake()
    {
        curUi = ui[0];
    }

    private void Start()
    {
        GameManager.instance.curSceneData.player.StatusUpdate += HpTextUPdate;
        GameManager.instance.curSceneData.player.StatusUpdate += HpSliderUpdate;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (InputManager.instance.IButton)
        {
            ChangeUI("Inventory");
        }
        if (InputManager.instance.QButton)
        {
            ChangeUI("Quest");
        }
        if (InputManager.instance.EscButton)
        {
            ChangeUI("Escape");
        }
    }
    private void ChangeUI(string name)
    {
        if (name == "Escape" && curUi.activeSelf)
        {
            ActiveUI(false);
        }
        else if (name == curUi.name)
        {
            ActiveUI(!curUi.activeSelf);
        }
        else if (name != curUi.name && !curUi.activeSelf)
        {
            ChangeCurUI(name);
            ActiveUI(true);
        }
        else if (name != curUi.name && curUi.activeSelf)
        {
            curUi.SetActive(false);
            ChangeUI(name);
            curUi.SetActive(true);
        }
        if (interactionUi.activeSelf)
        {
            interactionUi.SetActive(false);
        }
    }
    private void ChangeCurUI(string name)
    {
        for (int i = 0; i < ui.Length; i++)
        {
            if (ui[i].name == name)
            {
                curUi = ui[i];
                break;
            }
        }
    }
    private void ActiveUI(bool value)
    {
        curUi.SetActive(value);
        uiOutside.SetActive(value);
    }
    public void CheckOutInteraction(bool value)
    {
        if (value)
            ItemCheckEffect.text = "Press 'G'";
        else
            ItemCheckEffect.text = "";
    }


    private void HpTextUPdate(float value)
    {
        hpText.text = string.Format("{0:0}", value);
    }
    private void HpSliderUpdate(float value)
    {
        hpSlider.value = value / 500;
    }
}
