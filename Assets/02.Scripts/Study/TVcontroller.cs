using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TVcontroller : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI; // ��ư �迭. ����Ƽ���� 4�� �Ҵ�����.
    public bool isMute;
    public VideoClip[] clips; //���� ���� �迭

    public int nowClipIndex = 0; //���� ���� index 0�� ������ 0�� �ε���. 1�� ������ 1�� �ε��� ����..

    VideoPlayer videoPlayer; // ������ ���� awake ���� �Ҵ��ϰ� ����. 

    private void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0];
    }

    private void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        //�ε����� 0���� ��ư�� ��Ŭ��(��ư ���� ��)���ٰ� �½�ũ���Ŀ� �Լ� �߰�.
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }
    public void OnScreenPower()
    {
      videoScreen.SetActive(!videoScreen.activeSelf); 
        //������Ʈ�� Active On �� ��� true �̰� off �� ���� false. activeSelf �� ����Ȱ��ȭ ���¸� �Ǻ��ϴ� �Լ� 
    }
    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute); //������ �Ҹ� ���Ұ�
    }
    public void OnNextChannel() //������ ��ư. 0,1,2 ������ �����ϰ�
    {
        nowClipIndex++;
        if (nowClipIndex > 2)
            nowClipIndex = 0;

        videoPlayer.clip = clips[nowClipIndex];
        videoPlayer.Play();
    }
    public void OnPrevChannel() // ���ʹ�ư. 2,1,0 ������ ������. 
    {
        nowClipIndex--;
        if (nowClipIndex < 0)
            nowClipIndex = 2;

        videoPlayer.clip = clips[nowClipIndex];
        videoPlayer.Play();
    }
}
