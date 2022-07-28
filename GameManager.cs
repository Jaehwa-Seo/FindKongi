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

        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/안녕하세요? <전생 체험관>에 오신 걸 환영합니다.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/당신의 이름은 무엇인가요?");

        yield return NameInputWindowOpen();

        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/"+playerName+"님 반가워요. 당신은 어떤 기억을 위해 방문하셨나요?");

        yield return ScriptManager.instance.CheckScript("Question/전생이 정말 존재하나요?/1/잘 모르겠어요./-1/심심해서 왔는데요./0");

        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/만물은 멈추지 않아요. 그건 당신의 삶도 마찬가지죠.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/어떤 삶에서는 나라는 존재가 이름도 모르는");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/들꽃으로 탄생했을 수 있지만,");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/다른 삶에서는 한여름에 맴맴 우는");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/매미 한 마리로 태어났을 수도 있답니다.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/그렇다면 과연 각각의 생에서 삶의 목적은 무엇일까요?");

        yield return ScriptManager.instance.CheckScript("Question/너무 어렵네요./0/진짜 모르겠는데요./0");

        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/잡설은 여기까지 할게요. 이만 전생으로 가죠.");

        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/천천히 눈을 감아보세요.");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/3...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/2...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/1...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/...");
        yield return ScriptManager.instance.CheckScript("CharacterScript/최면자/최면자/-5/어떤 순간이든 당신이 원하는 선택을 하세요.");

        yield return ScriptManager.instance.CheckScript("CharacterScriptWithDissolve/최면자/최면자/-5/" + playerName + "님, 전생 속에서 또 만나요.");

        yield return ScriptManager.instance.CheckScript("BackgroundChange/Black");

        yield return new WaitForSeconds(1f);

        yield return ScriptManager.instance.CheckScript("CharacterScript/me/me/0/( 점점 정신이 아득해진다. )");
        yield return ScriptManager.instance.CheckScript("CharacterScript/me/me/0/( 전생의 나… 과연 어떤 모습일까? )");

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