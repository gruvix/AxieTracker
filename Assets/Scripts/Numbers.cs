using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Numbers : MonoBehaviour
{
    int contadorIz = 3;
    int contadorDe = 3;
    public TextMeshProUGUI iz, de;
    public TextMeshProUGUI exTextIzMain, exTextIzSecond, exTextDeMain, exTextDeSecond;
    public Button turnoIz;
    public Button turnoDe;
    int exDeMain = 0, exDeSecond = 0, exIzMain = 0, exIzSecond = 0;
    void Start()
    {
        iz.text = contadorIz.ToString();

        var colorsIz = turnoIz.colors;
        colorsIz.normalColor = Color.green;
        colorsIz.selectedColor = Color.green;
        turnoIz.colors = colorsIz;

        if (GameObject.Find("Contador De") != null)
        {
            de.text = contadorDe.ToString();

            var colorsDe = turnoDe.colors;
            colorsDe.normalColor = Color.green;
            colorsDe.selectedColor = Color.green;
            turnoDe.colors = colorsDe;
        }
    }

    public void ModificarIz(int cambio)
	{
        contadorIz = Mathf.Clamp(contadorIz + cambio, 0, 10);
        iz.text = contadorIz.ToString();
        ResetEnd(0);

        if (exIzSecond < -contadorIz)
		{
            exIzSecond++;
            exTextIzSecond.text = exIzSecond.ToString();
        }
	}

    public void ModificarDe(int cambio)
    {
        contadorDe = Mathf.Clamp(contadorDe + cambio, 0, 10);
        de.text = contadorDe.ToString();
        ResetEnd(1);

        if (exDeSecond < -contadorDe)
        {
            exDeSecond++;
            exTextDeSecond.text = exDeSecond.ToString();
        }
    }

    public void ExtraOneDe(int cambio)
    {
        if (exDeMain > 0 || cambio > 0)
        {
            exDeMain += cambio;
            exTextDeMain.text = exDeMain.ToString();
        }

        else if (!(cambio < 1 && (contadorDe + exDeSecond) <= 0))
        {
            exDeSecond += cambio;
            exTextDeSecond.text = exDeSecond.ToString();
        }

        ResetEnd(1);//Pone el turno en rojo
    }

    public void ExtraOneIz(int cambio)
    {
        if (exIzMain > 0 || cambio > 0) 
        {
            exIzMain += cambio;
            exTextIzMain.text = exIzMain.ToString();
        }

		else if (!(cambio < 1 && (contadorIz + exIzSecond) <= 0))
        {
            exIzSecond += cambio;
            exTextIzSecond.text = exIzSecond.ToString();
        }

        ResetEnd(0);//Pone el turno en rojo
    }

    public void Reset(int ID)
	{
		if(ID == 0)
        {
            EndTurn(0);
            contadorIz = 3;
            iz.text = contadorIz.ToString();
        }
		else
		{
            EndTurn(1);
            contadorDe = 3;
            de.text = contadorDe.ToString();
        }
	}

    public void EndTurn(int ID)
	{
        if (ID == 0)
        {
            contadorIz = Mathf.Clamp(contadorIz + 2 + exIzMain + exIzSecond, 0, 10);
            iz.text = contadorIz.ToString();

            exIzMain = 0;
            exIzSecond = 0;
            exTextIzSecond.text = exIzSecond.ToString();
            exTextIzMain.text = exIzMain.ToString();


            var colorsIz = turnoIz.colors;
            colorsIz.normalColor = Color.green;
            turnoIz.colors = colorsIz;

        }
        if (ID == 1)
        {
            contadorDe = Mathf.Clamp(contadorDe + 2 + exDeMain + exDeSecond, 0, 10);
            de.text = contadorDe.ToString();

            exDeMain = 0;
            exDeSecond = 0;
            exTextDeSecond.text = exDeSecond.ToString();
            exTextDeMain.text = exDeMain.ToString();

            var colorsDe = turnoDe.colors;
            colorsDe.normalColor = Color.green;
            turnoDe.colors = colorsDe;
        }
    }

    void ResetEnd(int ID)
	{
        if (ID == 0)
		{
            var colors = turnoIz.colors;
            colors.normalColor = Color.red;
            turnoIz.colors = colors;
        }
        if (ID == 1)
		{
            var colors = turnoDe.colors;
            colors.normalColor = Color.red;
            turnoDe.colors = colors;
        }
	}
    //Hecho por Drupus
    public void Quit()
	{
        Application.Quit();
	}
}
