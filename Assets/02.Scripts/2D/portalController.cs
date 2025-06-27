using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portalController : MonoBehaviour
{
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
        set.SetActive(false); //���� ��ư ����
        yield return StartCoroutine(fade.FadeRoutine(3f, Color.blue, true));

        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.FadeRoutine(2f, Color.blue, false)); //���̵����
        set.SetActive(true);

        while (progressBar.fillAmount < 1f) //�ε�â 
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f;

            yield return null;
        }
        SceneManager.LoadScene(1); //�� �ε�
        //ȿ���� �ֱ� 
    }    

}
