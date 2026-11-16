using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public CarController car;
    public Slider[] sliders;

    

   
    void Start()
    {
        sliders[0].value = car.restingHeight;
        sliders[1].value = car.maxAcceleration;
        sliders[2].value = car.TopSpeed;
        sliders[3].value = car.frontFrictionCoeff;
        sliders[4].value = car.rearFrictionCoeff;
    }
    public void CarHeight()
    {
        car.restingHeight = sliders[0].value;
    }
    public void Acceleration()
    {
        car.maxAcceleration = sliders[1].value;
    }
    public void TopSpeed()
    {
        car.TopSpeed = sliders[2].value;
    }
    public void FrontGrip()
    {
        car.frontFrictionCoeff = sliders[3].value;
    }
    public void RearGrip()
    {
        car.rearFrictionCoeff = sliders[4].value;
    }
}
