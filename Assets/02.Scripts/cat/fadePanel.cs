using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadePanel : MonoBehaviour
{
    public Image fadeImage;

    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        StartCoroutine(FadeRoutine(fadeTime, color, isFadeStart));
    }

    public IEnumerator FadeRoutine(float fadeTime, Color color, bool isFadeStart)
    {

        float timer = 0f;
        float percent = 0f;
   
        while(percent < 1f)
        {
           float value = isFadeStart ? percent : 1 - percent;

            timer += Time.deltaTime;
            percent = timer / fadeTime;

            fadeImage.color = new Color(color.r, color.g, color.b,value);
            yield return null; 
        }  
    }
}
