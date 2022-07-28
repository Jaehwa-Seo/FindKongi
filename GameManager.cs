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
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-1/...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-1/�ȳ��ϼ���? <���� ü���>�� ���� �� ȯ���մϴ�.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-1/����� �̸��� �����ΰ���?");
    }
}