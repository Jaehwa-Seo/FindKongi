using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(this.GetComponent<ChatManager>().NormalChat("안ㅇ나애나애ㅏ내아내아ㅐㅏ앵나ㅐㅏㅐ"));
    } 
}