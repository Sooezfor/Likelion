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
        Debug.Log($"{clipname}을 찾지 못했습니다.");
    }

    public void EventSoundPlay(string clipname)
    {
         foreach (var clip in clips)
         {
             if (clip.name == clipname)
             {
                eventAudio.PlayOneShot(clip);//실행하면 제어 x 

                return;
             }
         }

        Debug.Log($"{clipname}을 찾지 못했습니다.");
    }
}
