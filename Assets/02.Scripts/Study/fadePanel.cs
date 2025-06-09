using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadePanel : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 3f;
    bool isFadeIn = false;

    void Start()
    {
        StartCoroutine(FadeRoutineA(3, true));

    }
    IEnumerator FadeRoutineA(float fadeTime, bool isFadeIn)
    {
        float timer = 0f;
        float percent = 0f;
        float value = 0f; 
            

        while(percent <1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
            value = isFadeIn ? percent : 1 - percent;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,value);
            yield return null; 
        }  
    }
}
