using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public IEnumerator SceneChangeEffectClose()
    {
        GameObject leftDoor, rightDoor;
        leftDoor = GameManager.instance.sceneChangeEffect.transform.GetChild(0).gameObject;
        rightDoor = GameManager.instance.sceneChangeEffect.transform.GetChild(1).gameObject;

        GameManager.instance.sceneChangeEffect.SetActive(true);

        leftDoor.GetComponent<Animator>().enabled = true;
        leftDoor.GetComponent<Animator>().Play("SceneEffectLeftDoorClose",-1,0);

        rightDoor.GetComponent<Animator>().enabled = true;
        rightDoor.GetComponent<Animator>().Play("SceneEffectRightDoorClose",-1,0);

        yield return new WaitForSeconds(1.51f);

        leftDoor.GetComponent<Animator>().enabled = false;
        rightDoor.GetComponent<Animator>().enabled = false;
    }

    public IEnumerator SceneChangeEffectOpen()
    {
        GameObject leftDoor, rightDoor;
        leftDoor = GameManager.instance.sceneChangeEffect.transform.GetChild(0).gameObject;
        rightDoor = GameManager.instance.sceneChangeEffect.transform.GetChild(1).gameObject;

        leftDoor.GetComponent<Animator>().enabled = true;
        leftDoor.GetComponent<Animator>().Play("SceneEffectLeftDoorOpen",-1,0);

        rightDoor.GetComponent<Animator>().enabled = true;
        rightDoor.GetComponent<Animator>().Play("SceneEffectRightDoorOpen",-1,0);

        yield return new WaitForSeconds(1.51f);

        GameManager.instance.sceneChangeEffect.SetActive(false);

        leftDoor.GetComponent<Animator>().enabled = false;
        rightDoor.GetComponent<Animator>().enabled = false;

        
    }
}
