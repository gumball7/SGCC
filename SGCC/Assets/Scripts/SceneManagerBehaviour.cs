using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerBehaviour : MonoBehaviour
{
    public GameObject player;
    public SpriteAnimBehaviour key;
    public DialogBehaviour dialogManager;
    public Dialog[] dialogs;

    private int dialogState = 0;
    private int latest = -1;

    // Start is called before the first frame update
    void Start()
    {
        key.freq = 0;
        key.initScale = new Vector3(0, 0, 0);
        key.transform.localScale = new Vector3(0, 0, 0);
        player.GetComponent<PlayerBehaviour>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogState < dialogs.Length)
        {
            if (latest != dialogState)
            {
                dialogManager.setDialog(dialogs[dialogState].getDialog());
                dialogManager.setActive(true);
                latest = dialogState;
            }
            if (dialogManager.isDone)
            {
                dialogState++;
            }
        }
        if (dialogState == 2)
        {
            key.freq = 0.9;
            key.initScale = new Vector3(1, 1, 0);
            key.transform.localScale = new Vector3(1, 1, 0);
            player.GetComponent<PlayerBehaviour>().speed = 5;
        }
    }
}
