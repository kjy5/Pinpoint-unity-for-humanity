using UnityEngine;

public class DemoDriver : MonoBehaviour
{
    private bool _driving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _driving = !_driving;
        }

        if (_driving)
        {
            ProbeManager.Instances[0].ProbeController.SetProbePosition(
                ProbeManager.Instances[0].ProbeController.Insertion.APMLDV -
                new Vector3(0, 0, 1.5f * Time.deltaTime));
        }
    }
}