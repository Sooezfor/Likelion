using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource bgmaudio;
    [SerializeField] AudioSource eventAudio; 

    [SerializeField] AudioClip[] clips;

    [SerializeField] Slider bgmVolume;
    [SerializeField] Slider eventVolume;

    [SerializeField] Toggle bgmMute;
    [SerializeField] Toggle eventMute;

    private void Awake() //�ʱ�ȭ �۾� 
    {
        bgmVolume.value = bgmaudio.volume; //���� ����� ������ �����̴�������
        eventVolume.value = eventAudio.volume;

        bgmMute.isOn = bgmaudio.mute;  //isOn�̳� value ��� �ν����� �ȿ� �ִ� �� ������ ��
        eventMute.isOn = eventAudio.mute;
    }

    private void Start()
    {
        BgmSoundPlay("peace bgm");
        bgmVolume.onValueChanged.AddListener(OnBgmVolumeChange);
        eventVolume.onValueChanged.AddListener(OnEventVolumeChange);

        bgmMute.onValueChanged.AddListener(OnBgmMute);
        eventMute.onValueChanged.AddListener(OnEventMute);
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

    void OnBgmVolumeChange(float volume)
    {
        bgmaudio.volume = volume;
    }
    void OnEventVolumeChange(float volume)
    {
        eventAudio.volume = volume;
    }

    void OnBgmMute(bool isMute) //�ΰ��ӿ��� ���� �� ���� �Ű������� ���ͼ� ���� �ٷ� �ٲ���.
    {
        bgmaudio.mute = isMute; 
    }

    void OnEventMute(bool isMute)
    {
        eventAudio.mute = isMute;
    }
}
