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
        theta += Time.deltaTime * speed; //델타안하고 Time.Time 써도 돼 유니티가 시작한 순간부터 차오르는 시간임 

        //light.intensity = Mathf.Sin(theta) * power; //수학적으로 빛 세기에 접근 
        light.intensity = Mathf.PerlinNoise(theta, 0) * power; //유명한 노이즈 처리 방식 
    }
}
