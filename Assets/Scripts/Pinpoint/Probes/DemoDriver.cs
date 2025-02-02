using System.Collections.Generic;
using UnityEngine;

namespace Pinpoint.Probes
{
    public class DemoDriver : MonoBehaviour
    {
        private bool _driving;
        private List<float> _progress;

        private const float RATE = 2f;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                _driving = !_driving;

                _progress.Clear();
                foreach (var probeManager in ProbeManager.Instances)
                {
                    _progress.Add(0);
                }
            }

            if (!_driving) return;

            var delta = RATE * Time.deltaTime;
            for (var i = 0; i < ProbeManager.Instances.Count; i++)
            {
                if (_progress[i] > 3.5f)
                {
                   continue; 
                }
                if (i > 0 && _progress[i - 1] < 1)
                {
                    continue;
                }

                var position = ProbeManager.Instances[i].ProbeController.Insertion.APMLDV;

                ProbeManager.Instances[i].ProbeController
                    .SetProbePosition(new Vector4(position.x, position.y, position.z, delta));
                _progress[i] += delta;
            }
        }
    }
}