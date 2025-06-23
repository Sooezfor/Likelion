using Unity.VisualScripting;
using UnityEngine;

public class Mathlaw : MonoBehaviour
{
    //Sin 에 쓰인 애들 
    public float aAngle = 30f;
    public float bAngle = 90f;
    public float aaSide = 1f;

    //Cos 에 쓰인 애들
    public float cAngle = 60f;
    public float aSide = 1f;
    public float bSide = 1f;

    float theta;
    [SerializeField] float speed, radius; 


    private void Start()
    {
        //Cowlaw();
    }

    private void Update()
    {
        theta += Time.deltaTime * speed;
        Vector2 pos = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)* radius); //(x,y 자리에 각각 넣은 것) 
        transform.position = pos; 
    }

    private void Sin()
    {
        float aRad = aAngle * Mathf.Deg2Rad;
        float bRad = bAngle * Mathf.Deg2Rad;

        float bSide = (aaSide * Mathf.Sin(bRad))/ Mathf.Sin(aRad); //사인법칙

        Debug.Log(bSide);//숫자 2가 나와야함. 
    }

    void Cowlaw()
    {
        float cRad = cAngle * Mathf.Deg2Rad;
        float cSide = Mathf.Sqrt(Mathf.Pow(aSide, 2) + Mathf.Pow(bSide, 2) - 2 * aSide * bSide * Mathf.Cos(cRad));

        Debug.Log(cSide);
    }

}
