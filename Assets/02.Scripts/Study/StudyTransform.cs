using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 70f; 

    // Update is called once per frame
    void Update()

    {
        //float angle = transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime; //이렇게 변수로 미리 선언하고 회전에다가 넣어도 됨.
        //float localX = transform.eulerAngles.x;
        //float localZ = transform.eulerAngles.z;


        // 월드 방향으로 이동 
        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        //월드 방향으로 이동 2번째 방법
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        // 로컬 방향으로 이동 
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //월드 방향으로 회전 
        //transform.rotation = Quaternion.Euler(localX,angle,localZ);

        //로컬 방향으로 회전
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);//Space.slef 생략된거임.

        //위 코드에서 월드 방향으로 회전하는 방법
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        //특정 위치의 주변을 회전 (여기서는 zero로 원점으로 설정) 
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);

        transform.LookAt(Vector3.zero); 
      
    }
}
