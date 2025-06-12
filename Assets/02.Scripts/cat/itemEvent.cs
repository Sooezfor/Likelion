using UnityEngine;

public class itemEvent : MonoBehaviour
{
    public GameObject pipe;
    public GameObject melon;
    public GameObject particle;
    public float moveSpeed = 3;
    public float returnPosX = 15f;
    public float randomPosY;

    public enum ColliderType { Pipe, Melon, Both }
    public ColliderType colliderType;
    Vector3 initPos; //������ ��ġ ��� ����

    private void Awake()
    {
        initPos = transform.localPosition;
    }

    private void OnEnable()
    {
        SetRandomSetting(initPos.x);
    }
    void Update()
     {
          transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

          if (transform.position.x <= -returnPosX) //�̹����� x�� ���� -30�� �Ѵ� ���� ����
          {
            SetRandomSetting(returnPosX);       
          }
     }
     void SetRandomSetting(float posX) // ������,���,�� �� Type ���� + ��ġ ������ 
     {
        randomPosY = Random.Range(-9f, -5);
        transform.position = new Vector3(posX, randomPosY, 0);

        pipe.SetActive(false);
        melon.SetActive(false);
        particle.SetActive(false);

        colliderType = (ColliderType)Random.Range(0, 3); //0���� 3���� ����� 0,1,2�� ���´�. 

        switch (colliderType)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Melon:
                melon.SetActive(true);
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                melon.SetActive(true);
                break;
        }
     }
}
