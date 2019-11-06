using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerBehaviour : MonoBehaviour
{
    public GameObject player;
    public Transform key;
    public DialogBehaviour dialogManager;
    public Dialog[] dialogs;

    private int dialogState = 0;

    // Start is called before the first frame update
    void Start()
    {
        key.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogState < dialogs.Length)
        {
            dialogManager.setDialog(dialogs[dialogState].getDialog());
            dialogManager.setActive(true);
            if (dialogManager.isDone)
            {
                dialogState++;
            }
        }
        else { return; }
        Debug.Log(dialogState); 
        if (dialogState == 1)
        {
            key.localScale = new Vector3(1, 1, 0);
            key.GetComponent<SpriteAnimBehaviour>().freq = 1;
        }
    }
}
