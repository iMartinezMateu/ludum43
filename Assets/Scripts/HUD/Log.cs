using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour {

    static Queue<string> queue = new Queue<string>();
    Text messageText;
    Animator animator;

    public static Log instance;

    private void Start()
    {
        if (!instance) instance = this;

        messageText = GetComponentInChildren<Text>();
        animator = GetComponent<Animator>();
    }

    public void ShowMessage(string message)
    {
        queue.Enqueue(message);
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).ToString());
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Log_anim"))
        {
            Next();
        }
        else
            Debug.Log("Playing");
    }

    public void Next()
    {
        if (queue.Count > 0)
        {
            animator.Play("Log_anim");
            messageText.text = queue.Dequeue();
        }
    }

    public void Test()
    {
        ShowMessage("Al abordaje");
    }
}
