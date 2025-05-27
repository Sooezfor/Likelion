using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat;
    public string hexCode;

    void Start()
    {
        //this.GetComponent<Material>() = mat;// mateirla 을 바꾸는 방식 x 

        //this.GetComponent<MeshRenderer>().sharedMaterial = mat; //MeshRenderer에 접근해서 바꾸는 방식 

        //this.GetComponent<MeshRenderer>().material.color = Color.green;

        //this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;

        //this.GetComponent<MeshRenderer>().material.color = new Color(130f/255, 137f/255, 70f/255, 1);

        Material mat = this.GetComponent<MeshRenderer>().material;
        Color outPutColor;

        if(ColorUtility.TryParseHtmlString(hexCode, out outPutColor))
        {
            mat.color = outPutColor;
        }

    }

}
