using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    public Text characterName;
    public Text scriptText;

    public GameObject characterImage;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(ScriptStart());  
    }

    IEnumerator ScriptStart()
    {
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-1/...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-1/안녕하세요? <전생 체험관>에 오신 걸 환영합니다.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-1/당신의 이름은 무엇인가요?");
    }
}