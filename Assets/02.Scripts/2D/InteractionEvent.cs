using System.Collections;
using System.Data;
using System.Reflection;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public SoundController soundCtrl;

    public enum InteractionType { Sign, Door, Npc }
    public InteractionType type;

    public GameObject popup;
    public GameObject map;
    public GameObject house;
    public fadePanel fade;//스크립트 접근

    public Vector3 indoorPos;
    public Vector3 outdoorPos;
    bool isOutside; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Interaction(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popup.SetActive(false);
        }
    }
    void Interaction(Transform player)
    {
        switch(type)
        {
            case InteractionType.Sign:
                popup.SetActive(true);
                break;
            case InteractionType.Door:
                StartCoroutine(DoorRoutine(player));
                break;

            case InteractionType.Npc:
                popup.SetActive(true);
                break;
        }
    }

    IEnumerator DoorRoutine(Transform player)
    {
        soundCtrl.EventSoundPlay("Door sound");

        yield return StartCoroutine(fade.FadeRoutine(3f, Color.black, true)); //yield return 을 스타트코루틴 앞에 넣으면 해당 코루틴이 끝날 때까지 기다림. 

        if(!isOutside) //isOutside 가 펄스라면 실행
        {
            player.transform.position = indoorPos; //인도어 포즈로 플레이어 위치 바꿔버림
            map.SetActive(false);
            house.SetActive(true);
            soundCtrl.BgmSoundPlay("soo peace bgm");

        }
        else //isOutside 가 트루라면
        {
            player.transform.position = outdoorPos; //아웃도어 포즈로 플레이어 위치 바꿔버림
            map.SetActive(true);
            house.SetActive(false);
            soundCtrl.BgmSoundPlay("peace bgm");
        }

        isOutside = !isOutside;
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(fade.FadeRoutine(3f, Color.black, false));

    }
}
