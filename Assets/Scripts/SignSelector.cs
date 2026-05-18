using UnityEngine;

public class SignSelector : MonoBehaviour
{
    public static SignSelector Instance;
    public Signs selectedSign;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void SelectSign(Signs sign)
    {
        selectedSign = sign;
        Debug.Log("Selected sign: " + sign.signName);
    }
}
