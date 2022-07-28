using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    public static ScriptManager instance;
    private IEnumerator chatCoroutine;

    int[] selectResult = new int[3];

    bool isQuestionInput;

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
                //TODO Image Change
                yield return StartCoroutine(ExcuteBackgroundChange());
                break;
            case "Question":
                if(split_script.Length == 5)
                    yield return StartCoroutine(Excute2QuestionScript(split_script[1], int.Parse(split_script[2]), split_script[3], int.Parse(split_script[4])));
                else
                    yield return StartCoroutine(Excute3QuestionScript(split_script[1], int.Parse(split_script[2]), split_script[3], int.Parse(split_script[4]), split_script[5], int.Parse(split_script[6])));
                break;
            case "CharacterScript":
                chatCoroutine = ExcuteCharacterScript(split_script[1], split_script[2], float.Parse(split_script[3]), split_script[4]);
                yield return StartCoroutine(chatCoroutine);
                break;
            case "CharacterScriptWithDissolve":
                yield return StartCoroutine(ExcuteCharacterScriptWithDissolve(split_script[1], split_script[2], float.Parse(split_script[3]), split_script[4]));
                break;
            case "BGMOn":
            case "SFXOn":
            case null:
                break;
        }
    }

    IEnumerator ExcuteCharacterScript(string characterName, string imageName,float characterXPosition,string script)
    {
        

        if (characterName != "me")
        {
            GameManager.instance.characterImage.transform.position = new Vector3(characterXPosition, 0, 0);
            GameManager.instance.characterImage.transform.GetChild(0).GetComponent<Text>().text = imageName;// TODO:Delete

            if (!GameManager.instance.characterImage.active)
            {
                GameManager.instance.characterImage.SetActive(true);
                GameManager.instance.characterImage.GetComponent<Animator>().enabled = true;
                GameManager.instance.characterImage.GetComponent<Animator>().Play("CharacterShow");

                yield return new WaitForSeconds(1f);

                GameManager.instance.characterImage.GetComponent<Animator>().enabled = false;
            }   
        }
        else
            GameManager.instance.characterImage.SetActive(false);

        GameManager.instance.scriptWindow.SetActive(true);

        GameManager.instance.characterName.text = characterName;

        yield return StartCoroutine(ChatManager.instance.NormalChat(script));

        GameManager.instance.scriptWindow.SetActive(false);
    }

    IEnumerator ExcuteCharacterScriptWithDissolve(string characterName, string imageName, float characterXPosition, string script)
    {


        if (characterName != "me")
        {
            GameManager.instance.characterImage.transform.position = new Vector3(characterXPosition, 0, 0);
            GameManager.instance.characterImage.transform.GetChild(0).GetComponent<Text>().text = imageName;// TODO:Delete

            if (!GameManager.instance.characterImage.active)
            {
                GameManager.instance.characterImage.SetActive(true);
                GameManager.instance.characterImage.GetComponent<Animator>().enabled = true;
                GameManager.instance.characterImage.GetComponent<Animator>().Play("CharacterShow");

                yield return new WaitForSeconds(1f);

                GameManager.instance.characterImage.GetComponent<Animator>().enabled = false;
            }
        }
        else
            GameManager.instance.characterImage.SetActive(false);

        GameManager.instance.scriptPanel.SetActive(true);
        GameManager.instance.scriptPanel.GetComponent<Animator>().enabled = true;
        GameManager.instance.scriptPanel.GetComponent<Animator>().Play("ScriptDissolve");

        yield return new WaitForSeconds(2f);

        GameManager.instance.scriptWindow.SetActive(true);

        GameManager.instance.characterName.text = characterName;

        yield return StartCoroutine(ChatManager.instance.DissolveChat(script));

        GameManager.instance.scriptPanel.GetComponent<Animator>().enabled = false;

        GameManager.instance.scriptPanel.SetActive(false);

        GameManager.instance.scriptWindow.SetActive(false);

        GameManager.instance.characterImage.SetActive(false);
    }

    IEnumerator Excute2QuestionScript(string question1, int questionResult1, string question2, int questionResult2)
    {
        GameManager.instance.questionWindow.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = question1;
        
        GameManager.instance.questionWindow.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = question2;

        GameManager.instance.questionWindow.transform.GetChild(3).gameObject.SetActive(false);

        GameManager.instance.questionWindow.SetActive(true);

        isQuestionInput = false;

        yield return new WaitUntil(() => isQuestionInput);

        GameManager.instance.questionWindow.SetActive(false);
    }

    IEnumerator Excute3QuestionScript(string question1, int questionResult1, string question2, int questionResult2, string question3, int questionResult3)
    {
        GameManager.instance.questionWindow.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = question1;

        GameManager.instance.questionWindow.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = question2;

        GameManager.instance.questionWindow.transform.GetChild(3).gameObject.SetActive(true);

        GameManager.instance.questionWindow.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = question3;

        GameManager.instance.questionWindow.SetActive(true);

        isQuestionInput = false;

        yield return new WaitUntil(() => isQuestionInput);

        GameManager.instance.questionWindow.SetActive(false);
    }

    IEnumerator ExcuteBackgroundChange() // TODO CHANGE System
    {
        GameManager.instance.backgroundImage.GetComponent<Image>().color = new Color(0, 0, 0);
        yield return null;
    }

    public void QuestionButtonClick()
    {
        isQuestionInput = true;

        // TODO :: Calculate Love power
    }

}
