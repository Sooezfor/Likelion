using System.Xml.Serialization;
using UnityEngine;

namespace Cat
{ 
    public class SoundManager : MonoBehaviour
    {
        public AudioClip jumpClip;
        public AudioSource audioSource;
        public AudioClip playbgmCLip;
        public AudioClip introBgmClip;
        public AudioClip colliderClip;

       public void SetBGMSound(string bgmName) // 스크립트 상으로 오디오 인스펙터 조정 
       {
            if (bgmName == "Intro")
            {
                audioSource.clip = introBgmClip;
            }
            else if(bgmName == "Play")
            {
                  audioSource.clip = playbgmCLip;
            }

            audioSource.loop = true;
            audioSource.volume = 0.1f;

            audioSource.Play(); 
        }
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip); //점프클립 한번만 실행
        }
        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
        }

    }


}
