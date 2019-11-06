using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBehaviour : MonoBehaviour
{
    public Transform unactivePos;
    public Transform activePos;
    public Dialog currentDialog;
    public Text name;
    public Text mainText;
    public Image speakerImage;

    public bool isDone = false;

    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = unactivePos.transform.position;
        targetPos = unactivePos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
    }

    public void setActive(bool active)
    {
        if (active)
        {
            targetPos = activePos.position;
            isDone = false;
        }
        else
        {
            targetPos = unactivePos.position;
            isDone = true;
        }
    }

    public void setDialog(Dialog dialog)
    {
        Debug.Log("new!");
        dialog = dialog.getDialog();
        currentDialog = dialog;
        name.text = dialog.name; 
        speakerImage.sprite = dialog.speakerImage;
        nextSentence();
    }

    public void nextSentence()
    {
        if (currentDialog.sentences.Count == 0)
        {
            setActive(false);   
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(loadSentence(currentDialog.sentences.Dequeue()));
        }
    }

    IEnumerator loadSentence(string sentence)
    {
        mainText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            mainText.text += c;
            yield return null;
        }
    }
}

