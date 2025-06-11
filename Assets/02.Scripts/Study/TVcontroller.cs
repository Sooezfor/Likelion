using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TVcontroller : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI; // 버튼 배열. 유니티에서 4개 할당했음.
    public bool isMute;
    public VideoClip[] clips; //영상 파일 배열

    public int nowClipIndex = 0; //현재 영상 index 0번 영상은 0번 인덱스. 1번 영상은 1번 인덱스 일케..

    VideoPlayer videoPlayer; // 변수로 만들어서 awake 에서 할당하고 있음. 

    private void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0];
    }

    private void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        //인덱스상 0번인 버튼에 온클릭(버튼 누를 시)에다가 온스크린파워 함수 추가.
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }
    public void OnScreenPower()
    {
      videoScreen.SetActive(!videoScreen.activeSelf); 
        //오브젝트가 Active On 인 경우 true 이고 off 인 경우는 false. activeSelf 는 현재활성화 상태를 판별하는 함수 
    }
    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute); //영상의 소리 음소거
    }
    public void OnNextChannel() //오른쪽 버튼. 0,1,2 순서로 가야하고
    {
        nowClipIndex++;
        if (nowClipIndex > 2)
            nowClipIndex = 0;

        videoPlayer.clip = clips[nowClipIndex];
        videoPlayer.Play();
    }
    public void OnPrevChannel() // 왼쪽버튼. 2,1,0 순서로 가야함. 
    {
        nowClipIndex--;
        if (nowClipIndex < 0)
            nowClipIndex = 2;

        videoPlayer.clip = clips[nowClipIndex];
        videoPlayer.Play();
    }
}
