using UnityEngine;
using TMPro;


public class UImanager : MonoBehaviour
{
    private Rigidbody rb; 
    [SerializeField] private GameObject speedUIobject;
    private float speed;
    private TextMeshProUGUI speedText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedText = speedUIobject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        speed = Vector3.Magnitude(rb.linearVelocity);
        speedText.text = speed.ToString("F2");
    }
}
