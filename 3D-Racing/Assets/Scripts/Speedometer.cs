using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    public CarController carController;
    public TextMeshProUGUI speedText;

    private void Update()
    {
        float speed = carController.CurrentSpeed;
        speedText.text = Mathf.RoundToInt(speed).ToString();
    }
}