using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public static ScriptManager instance;
    private IEnumerator chatCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public IEnumerator CheckScript(string script)
    {
        string[] split_script;

        split_script = script.Split('/');

        switch(split_script[0])
        {
            case "EventStart":
            case "EventEnd":
            case "BackgroundChange":
            case "Question":
            case "CharacterScript":
                chatCoroutine = ExcuteCharacterScript(split_script[1], split_script[2], float.Parse(split_script[3]), split_script[4]);
                yield return StartCoroutine(chatCoroutine);
                break;
            case "BGMOn":
            case "SFXOn":
            case null:
                break;
        }
    }

    IEnumerator ExcuteCharacterScript(string characterName, string imageName,float characterXPosition,string script)
    {
        GameManager.instance.characterName.text = characterName;
        GameManager.instance.characterImage.transform.position = new Vector3(characterXPosition,0,0);
        GameManager.instance.characterImage.transform.GetChild(0).GetComponent<Text>().text = imageName;// TODO:Delete

        yield return StartCoroutine(ChatManager.instance.NormalChat(script));
    }
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(chatCoroutine == null)
    //     {
    //         chatCoroutine = ChatManager.instance.NormalChat("test");
    //         StartCoroutine(chatCoroutine);
    //     } 
    // }
}
