using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string playerName;

    public Text characterName;
    public Text scriptText;

    public GameObject characterImage;
    public GameObject backgroundImage;

    public GameObject scriptWindow;
    public GameObject scriptPanel;
    public GameObject sceneChangeEffect;
    public GameObject nameInputWindow;
    public GameObject questionWindow;

    bool isNameInput;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(TestScript());   
    }

    IEnumerator TestScript()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(SceneManager.instance.SceneChangeEffectOpen());

        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/�ȳ��ϼ���? <���� ü���>�� ���� �� ȯ���մϴ�.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/����� �̸��� �����ΰ���?");

        yield return NameInputWindowOpen();

        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/"+playerName+"�� �ݰ�����. ����� � ����� ���� �湮�ϼ̳���?");

        yield return ScriptManager.instance.CheckScript("Question/������ ���� �����ϳ���?/1/�� �𸣰ھ��./-1/�ɽ��ؼ� �Դµ���./0");

        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/������ ������ �ʾƿ�. �װ� ����� � ����������.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/� ����� ����� ���簡 �̸��� �𸣴�");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/������� ź������ �� ������,");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/�ٸ� ����� �ѿ����� �ɸ� ���");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/�Ź� �� ������ �¾�� ���� �ִ�ϴ�.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/�׷��ٸ� ���� ������ ������ ���� ������ �����ϱ��?");

        yield return ScriptManager.instance.CheckScript("Question/�ʹ� ��Ƴ׿�./0/��¥ �𸣰ڴµ���./0");

        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/�⼳�� ������� �ҰԿ�. �̸� �������� ����.");

        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/õõ�� ���� ���ƺ�����.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/3...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/2...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/1...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/�ָ���/�ָ���/-5/� �����̵� ����� ���ϴ� ������ �ϼ���.");

        yield return ScriptManager.instance.CheckScript("CharacterScriptWithDissolve/�ָ���/�ָ���/-5/" + playerName + "��, ���� �ӿ��� �� ������.");

        yield return ScriptManager.instance.CheckScript("BackgroundChange/Black");

        yield return new WaitForSeconds(1f);

        yield return ScriptManager.instance.CheckScript("CharacterScript/me/me/0/( ���� ������ �Ƶ�������. )");
        yield return ScriptManager.instance.CheckScript("CharacterScript/me/me/0/( ������ ���� ���� � ����ϱ�? )");

        yield return StartCoroutine(SceneManager.instance.SceneChangeEffectClose());

    }

    IEnumerator NameInputWindowOpen()
    {
        nameInputWindow.SetActive(true);

        isNameInput = false;

        yield return new WaitUntil(() => isNameInput);

        playerName = nameInputWindow.transform.GetChild(1).GetChild(1).GetComponent<Text>().text;

        nameInputWindow.SetActive(false);
    }

    public void NameInputButtonClick()
    {
        isNameInput = true;
    }


}