using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{

    private MeshRenderer renderer;
    public float offsetSpeed = 0.1f;

  
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        //����� offset�� 
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime;

        //SetTextureoffset = texture�� offset�� ����/�ٲٰڴ� ��� �Լ�, "_MainTex"�� BaseMap
        renderer.material.SetTextureOffset("_MainTex", renderer.material.mainTextureOffset + offset);

    }
}
