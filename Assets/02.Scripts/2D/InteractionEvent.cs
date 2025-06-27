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
    public fadePanel fade;//��ũ��Ʈ ����

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

        yield return StartCoroutine(fade.FadeRoutine(3f, Color.black, true)); //yield return �� ��ŸƮ�ڷ�ƾ �տ� ������ �ش� �ڷ�ƾ�� ���� ������ ��ٸ�. 

        if(!isOutside) //isOutside �� �޽���� ����
        {
            player.transform.position = indoorPos; //�ε��� ����� �÷��̾� ��ġ �ٲ����
            map.SetActive(false);
            house.SetActive(true);
            soundCtrl.BgmSoundPlay("soo peace bgm");

        }
        else //isOutside �� Ʈ����
        {
            player.transform.position = outdoorPos; //�ƿ����� ����� �÷��̾� ��ġ �ٲ����
            map.SetActive(true);
            house.SetActive(false);
            soundCtrl.BgmSoundPlay("peace bgm");
        }

        isOutside = !isOutside;
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(fade.FadeRoutine(3f, Color.black, false));

    }
}
