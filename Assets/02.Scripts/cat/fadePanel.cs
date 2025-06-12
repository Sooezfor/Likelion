using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadePanel : MonoBehaviour
{
    public Image fadeImage;

    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        StartCoroutine(FadeRoutine(fadeTime, color, isFadeStart));
        Debug.Log("on fade 실행");
    }

    IEnumerator FadeRoutine(float fadeTime, Color color, bool isFadeStart)
    {
        Debug.Log("FadeRoutine 실행");

        float timer = 0f;
        float percent = 0f;
   
        while(percent < 1f)
        {
           float value = isFadeStart ? percent : 1 - percent;

            timer += Time.deltaTime;
            percent = timer / fadeTime;
      
            Debug.Log("value");

            fadeImage.color = new Color(color.r, color.g, color.b,value);
            yield return null; 
        }  
    }
}
