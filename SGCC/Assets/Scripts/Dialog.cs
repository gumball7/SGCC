using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Queue<string> sentences = new Queue<string>();
    public string[] dialog;
    public string name;
    public Sprite speakerImage;

    private void Start()
    {
        sentences = new Queue<string>();
        foreach (string s in dialog)
        {
            sentences.Enqueue(s);
        }
    }

    public Dialog getDialog()
    {
        Dialog dialog = new Dialog();
        dialog.dialog = this.dialog;
        dialog.sentences = new Queue<string>();
        foreach (string s in dialog.dialog)
        {
            dialog.sentences.Enqueue(s);
        }
        dialog.name = this.name;
        dialog.speakerImage = this.speakerImage;
        return dialog;
    }

    public bool isDone()
    {
        return sentences.Count == 0;
    }
}
