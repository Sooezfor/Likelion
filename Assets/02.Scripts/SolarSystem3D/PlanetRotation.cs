using UnityEngine;

public class PlanetRotation : MonoBehaviour
{

    public Transform targetPlanet; 

    public float rotSpeed = 30f;//자전 속도 

    public float revolutionSpeed = 100f;//공전속도 

    public bool isRevolution = false; // 논리타입 => true /false

    void Update()
    {
        // 자전하는 회전하는 기능 
        this.transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

        if(isRevolution == true)
        {
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime); 
            //이 오브젝트는 무언가 주변을 돌거다( 어떤 대상, 회전축, 속도)  

        }

        



    }
}
