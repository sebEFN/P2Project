using UnityEngine;

public class test : MonoBehaviour
{
    public HandPreview handPreview;

    bool wasPinching = false;

    void Update()
    {
        var kp = handPreview.keypoints;

        bool isPinching = IsPinching(kp);

        if (isPinching && !wasPinching)
        {
            Debug.Log("Pinch detected!");
        }

        wasPinching = isPinching;
    }

    bool IsPinching(Keypoint[] kp)
    {
        if (kp == null || kp.Length < 9)
            return false;

        float distance = Vector3.Distance(kp[4].Position, kp[8].Position);

        return distance < 0.05f;
    }
}