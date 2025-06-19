using UnityEngine;

public class Mathlight : MonoBehaviour
{
    Light light;
    float theta;
    [SerializeField] float power;
    [SerializeField] float speed; 

    private void Start()
    {
        light = GetComponent<Light>();
    }
    private void Update()
    {
        theta += Time.deltaTime * speed; //��Ÿ���ϰ� Time.Time �ᵵ �� ����Ƽ�� ������ �������� �������� �ð��� 

        //light.intensity = Mathf.Sin(theta) * power; //���������� �� ���⿡ ���� 
        light.intensity = Mathf.PerlinNoise(theta, 0) * power; //������ ������ ó�� ��� 
    }
}
