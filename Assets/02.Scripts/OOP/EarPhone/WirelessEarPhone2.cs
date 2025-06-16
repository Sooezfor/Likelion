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
    //    string msg = isWirelessCharged ? "무선 충전" : "유선 충전";
    //    Debug.Log(msg);
    //}

    public virtual void NoiseCancelling()
    {
        isNoiseCancelling = !isNoiseCancelling;

        string msg = isNoiseCancelling ? "노이즈 캔슬링 on " : "노이즈 캔슬링 off";
        Debug.Log(msg);
    }
}
