using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Conversation : ScriptableObject
{
    [SerializeField, TextArea(2, 5)]
    private string content;
    public string Content { get { return content; } }

    [SerializeField]
    private Conversation nextConversation;
    public Conversation NextConversation { get { return nextConversation; } }
}
