using System.Xml.Serialization;
using UnityEngine;

namespace Cat
{ 
    public class SoundManager : MonoBehaviour
    {
        public AudioClip jumpClip;
        public AudioSource audioSource;
        public AudioClip bgmCLip;

        private void Start()
        {
            //SetBGMSound(); //스크립트로 오디오 설정하는 함수 호출 
        }

       public void SetBGMSound() // 스크립트 상으로 오디오 인스펙터 조정 
       {
            //audioSource.clip = bgmCLip;
            //audioSource.playOnAwake = true;
            //audioSource.loop = true;
            //audioSource.volume = 0.1f;

            //audioSource.Play();//시작
            //audioSource.Stop();//정지
            //audioSource.Pause();//일시정지

        }
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip); //점프클립 한번만 실행
        }
    }


}
