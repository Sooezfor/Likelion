using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadePanel : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 3f;


    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        Debug.Log("on fade 실행");
        StartCoroutine(FadeRoutine(fadeTime, color, isFadeStart));
    }

    IEnumerator FadeRoutine(float fadeTime, Color color, bool isFadeStart)
    {
        Debug.Log("FadeRoutine 실행");

        float timer = 0f;
        float percent = 0f;
   
        while(percent <1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
      
           float value = isFadeStart ? percent : 1 - percent;
            Debug.Log("value");

            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,value);
            yield return null; 
        }  
    }
}
