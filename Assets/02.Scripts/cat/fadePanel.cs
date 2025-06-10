using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadePanel : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 3f;

    public void OnFade(float fadeTime, Color color)
    {
        StartCoroutine(FadeRoutine(fadeTime, color));
    }

    IEnumerator FadeRoutine(float fadeTime, Color color)
    {
        float timer = 0f;
        float percent = 0f;
   
        while(percent <1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
      
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,percent);
            yield return null; 
        }  
    }
}
