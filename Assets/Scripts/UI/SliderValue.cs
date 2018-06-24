using UnityEngine.UI;
using UnityEngine;

public class SliderValue : MonoBehaviour {

    public Text value;
    public string prefix;

    public void textUpdate(float _value)
    {
        value.text = prefix + ": " + _value;
    }
}