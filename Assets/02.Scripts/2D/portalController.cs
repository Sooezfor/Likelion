using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portalController : MonoBehaviour
{
    public enum SceneType {  TOWN, ADVENTURE }
    public SceneType sceneType = SceneType.TOWN;

    public fadePanel fade;
    public GameObject portalEffect;
    public GameObject loadingImage;

    public GameObject set;

    public Image progressBar;
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            StartCoroutine(PortalRoutine());
        }
    }

    IEnumerator PortalRoutine()
    {
        portalEffect.SetActive(true);
        set.SetActive(false); //세팅 버튼 끄기
        yield return StartCoroutine(fade.FadeRoutine(3f, Color.blue, true));

        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.FadeRoutine(2f, Color.blue, false)); //페이드오프
        set.SetActive(true);

        while (progressBar.fillAmount < 1f) //로딩창 
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f;

            yield return null;
        }
        if (sceneType == SceneType.TOWN)
            SceneManager.LoadScene(1); //씬 로드
        else
            SceneManager.LoadScene(0);
    }    

}
