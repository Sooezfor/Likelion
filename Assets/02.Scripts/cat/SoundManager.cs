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
            //SetBGMSound(); //��ũ��Ʈ�� ����� �����ϴ� �Լ� ȣ�� 
        }

       public void SetBGMSound() // ��ũ��Ʈ ������ ����� �ν����� ���� 
       {
            //audioSource.clip = bgmCLip;
            //audioSource.playOnAwake = true;
            //audioSource.loop = true;
            //audioSource.volume = 0.1f;

            //audioSource.Play();//����
            //audioSource.Stop();//����
            //audioSource.Pause();//�Ͻ�����

        }
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip); //����Ŭ�� �ѹ��� ����
        }
    }


}
