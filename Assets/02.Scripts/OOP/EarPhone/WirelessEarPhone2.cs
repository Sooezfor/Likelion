using UnityEngine;

public class WirelessEarPhone2 : WirelessEarPhone
{
    //public float batterySize;
    //public bool isWirelessCharged;
    public bool isNoiseCancelling;

    private void Start()
    {
        name = "AirpodPro";
        price = 200f;
        releaseYear = 2013;
        batterySize = 130f;
    }

    //public void Charged()
    //{
    //    string msg = isWirelessCharged ? "���� ����" : "���� ����";
    //    Debug.Log(msg);
    //}

    public virtual void NoiseCancelling()
    {
        isNoiseCancelling = !isNoiseCancelling;

        string msg = isNoiseCancelling ? "������ ĵ���� on " : "������ ĵ���� off";
        Debug.Log(msg);
    }
}
