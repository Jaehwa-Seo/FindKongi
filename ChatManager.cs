using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
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
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        is_typing = false;

       
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
                GameManager.instance.scriptText.text = narration;
                break;
            }
            writerText += narration[a];
            GameManager.instance.scriptText.text = writerText;
            yield return new WaitForSeconds(0.07f);
        }

#if(UNITY_EDITOR)
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
#else
        yield return new WaitUntil(() => Input.touchCount > 0);
#endif
        GameManager.instance.scriptText.text = "";

        is_typing = false;
        yield return null;

    }

    public IEnumerator DissolveChat(string narration)
    {
        is_typing = true;
        int a = 0;
        writerText = "";

        state = State.Playing;

        for (a = 0; a < narration.Length; a++)
        {
            if (state == State.PlayingSkipping)
            {
                GameManager.instance.scriptText.text = narration;
                break;
            }
            writerText += narration[a];
            GameManager.instance.scriptText.text = writerText;
            yield return new WaitForSeconds(0.07f);
        }

        GameManager.instance.scriptText.text = "";

        is_typing = false;
        yield return null;

    }

    public void SkipChat()
    {
        state = State.PlayingSkipping;
    }

    public bool get_istyping() { return is_typing; }
}