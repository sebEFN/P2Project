using UnityEngine;

public class test : MonoBehaviour
{
    public HandPreview handPreview;

    void Update()
    {
        var kp = handPreview.keypoints;

        if (IsPinching(kp))
        {
            Debug.Log("Pinch detected!");
            // do something (grab object, click, etc.)
        }
    }
    bool IsPinching(Keypoint[] kp)
    {
        if (kp == null || kp.Length < 9)
            return false;

        float distance = Vector3.Distance(kp[4].Position, kp[8].Position); // thumb tip ↔ index tip

        return distance < 0.05f;
    
    }
}
