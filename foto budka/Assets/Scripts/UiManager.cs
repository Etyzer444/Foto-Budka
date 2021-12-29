using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public FileManager fileManager;
	public Canvas canvas;


	public void NextButton()
	{
		fileManager.LoadNext();
	}
	
	public void PreviousButton()
	{
		fileManager.LoadPrevious();
	}
	
	public void TakePhoto()
	{
		StartCoroutine(TakePhotoCoroutine());
	}
	
	public IEnumerator TakePhotoCoroutine() //we don't want the UI on our screenshot
	{
		canvas.gameObject.SetActive(false);
		fileManager.SavePhoto();
		yield return new WaitForEndOfFrame();
		canvas.gameObject.SetActive(true);
	}
	
	
}