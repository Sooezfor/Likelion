using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource bgmaudio;
    [SerializeField] AudioSource eventAudio; 

    [SerializeField] AudioClip[] clips;

    private void Start()
    {
        BgmSoundPlay("peace bgm");
    }

    public void BgmSoundPlay(string clipname)
    {

        foreach (var clip in clips)
        {
            if (clip.name == clipname)
            {
                bgmaudio.clip = clip;
                bgmaudio.Play();

                return;
            }
        }
        Debug.Log($"{clipname}�� ã�� ���߽��ϴ�.");
    }

    public void EventSoundPlay(string clipname)
    {
         foreach (var clip in clips)
         {
             if (clip.name == clipname)
             {
                eventAudio.PlayOneShot(clip);//�����ϸ� ���� x 

                return;
             }
         }

        Debug.Log($"{clipname}�� ã�� ���߽��ϴ�.");
    }
}
