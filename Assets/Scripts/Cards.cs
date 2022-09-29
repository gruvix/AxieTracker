using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cards : MonoBehaviour
{
	Color[] colors = new Color[] { Color.white, Color.HSVToRGB(0.24f, 0.67f, 0.99f), Color.HSVToRGB(0.54f, 0.67f, 0.99f), Color.HSVToRGB(0.99f, 0.67f, 0.99f), Color.HSVToRGB(0.13f, 0.67f, 0.99f), Color.HSVToRGB(0.74f, 0.67f, 0.99f) };
	int j = 1;
	public void color()
	{
		if (j == colors.Length)
		{
			j = 0;
		}
		foreach (Transform parte in transform)
		{
			parte.gameObject.GetComponent<Image>().color = colors[j];
			
		}
		j++;
	}

	public void shuffle()
	{
		for (int i = 1; i < 5; i++)
		{
			transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
		}
	}

    public void Parte(TextMeshProUGUI texto)
	{
        if (texto.text == "x")
		{
			texto.text = "xx";
		}

        else
		{
			if (texto.text == "xx")
			{
				texto.text = "";
			}

			else
			{
				texto.text = "x";
			}
		}
	}
}
