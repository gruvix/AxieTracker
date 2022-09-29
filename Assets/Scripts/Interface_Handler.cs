using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface_Handler : MonoBehaviour
{
	public Camera mainCam;
	public Slider redSlider, greenSlider, blueSlider, alphaSlider;
	string red = "red", blue = "blue", green = "green", alpha = "alpha";
	public GameObject[] panels = new GameObject[] { };

	private void Start()
	{

		redSlider.value = PlayerPrefs.GetFloat(red, 0.2f);
		greenSlider.value = PlayerPrefs.GetFloat(green, 0.2f);
		blueSlider.value = PlayerPrefs.GetFloat(blue, 0.3f);
		alphaSlider.value = PlayerPrefs.GetFloat(alpha);

		CameraColor(red);
		CameraColor(green);
		CameraColor(blue);
		PanelsAlpha();

		panels[2].SetActive(true);
		gameObject.SetActive(false);
	}
	public void CameraColor(string color)
	{
		var bgc = mainCam.backgroundColor;

		if (color == "red")
		{
			bgc.r = redSlider.value;
			mainCam.backgroundColor = bgc;
			PlayerPrefs.SetFloat(red, bgc.r);
		}

		if (color == "green")
		{
			bgc.g = greenSlider.value;
			mainCam.backgroundColor = bgc;
			PlayerPrefs.SetFloat(green, bgc.g);
		}

		if (color == "blue")
		{
			bgc.b = blueSlider.value;
			mainCam.backgroundColor = bgc;
			PlayerPrefs.SetFloat(blue, bgc.b);
		}

	}

	public void PanelsAlpha()
	{
		foreach (GameObject item in panels)
		{
			var component = item.GetComponent<Image>().color;
			component.a = alphaSlider.value;
			item.GetComponent<Image>().color = component;
		}
		PlayerPrefs.SetFloat(alpha, alphaSlider.value);
	}
}
