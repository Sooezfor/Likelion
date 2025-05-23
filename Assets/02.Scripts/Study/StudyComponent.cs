using UnityEngine;

public class StudyComponent : MonoBehaviour
{

    public GameObject obj;

    public Mesh msh;
    public Material mat; 

    void Start()
    {

        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

        CreateCube("Hello World"); //함수호출 
    }

    public void CreateCube(string name = "Cube") //Cube를 기본값으로
    {
        obj = new GameObject(name);

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = msh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;

        obj.AddComponent<BoxCollider>();

       

    }
}
