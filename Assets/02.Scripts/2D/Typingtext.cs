using System.Collections;
using TMPro;
using UnityEngine;

public class Typingtext : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textUI;
    string currText;
    [SerializeField] float typingSpeed = 0.1f;

    private void Awake()
    {
        currText = textUI.text; //유니티 상에 적힌 글씨 저장
    }

    private void OnEnable()
    {
        textUI.text = string.Empty;
        StartCoroutine(TypingRoutine());
    }
    IEnumerator TypingRoutine()
    {
        int textCount = currText.Length;
        for(int i = 0; i<textCount; i++)
        {
            textUI.text += currText[i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}
