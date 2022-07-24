using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    public Text ChatText; 

    public static ChatManager instance = null;

    enum State
    {
        Playing,
        PlayingSkipping,
    }

    private State state;

    private bool is_typing;

    public string writerText = "";

    void Update()
    {
    }

    private void Start()
    {
        is_typing = false;

        if(instance == null)
        {
            instance = this;
        }
    }


    public IEnumerator NormalChat(string narration)
    {
        is_typing = true;
        int a = 0;
        writerText = "";
        
        state = State.Playing;

        for (a = 0; a < narration.Length; a++)
        {
            if(state==State.PlayingSkipping)
            {
                ChatText.text = narration;
                break;
            }
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.07f);
        }

        yield return new WaitUntil(() => Input.touchCount > 0);

        ChatText.text = "";

        is_typing = false;
        yield return null;

    }

    public void SkipChat()
    {
        state = State.PlayingSkipping;
    }

    public bool get_istyping() { return is_typing; }
}