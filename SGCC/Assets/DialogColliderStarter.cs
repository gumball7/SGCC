using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogColliderStarter : MonoBehaviour
{
    public Transform player;
    public DialogBehaviour dialogManager;
    public Dialog dialog;

    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return") && isActive)
        {
            dialogManager.setDialog(dialog.getDialog());
            dialogManager.setActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("dd");
        if (collision.transform != player) return;
        isActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ff");
        if (collision.transform != player) return;
        isActive = false;
    }
}
