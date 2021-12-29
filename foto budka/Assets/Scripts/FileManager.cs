using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
	List<Mesh> meshes = new List<Mesh>();
	int meshListIndex = 0;
	public MeshFilter meshFilter;
   
   
    void Start()
    {
        //load mesh list
		foreach (Mesh mesh in Resources.LoadAll("Input",typeof(Mesh)))
		{
			meshes.Add(mesh);
		}
		//load first mesh
		refreshMesh();
    }

  
	
	public void SavePhoto()
	{
		if(!Directory.Exists(Application.dataPath + "/output"))
		{
			System.IO.Directory.CreateDirectory(Application.dataPath + "/output");
		}
		ScreenCapture.CaptureScreenshot(Application.dataPath + "/output/"+DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")+".png");
	}
	
	
	
	public void LoadNext()
	{
		if (meshListIndex == meshes.Count -1) //if on the last element of the list, wrap around to the beginning
		{
			meshListIndex = 0;
			refreshMesh();
		}
		else
		{
			meshListIndex++;
			refreshMesh();
		}
	}
	public void LoadPrevious()
	{
		if (meshListIndex == 0) //if on the first element of the list, wrap around to the end of the list
		{
			meshListIndex = meshes.Count -1;
			refreshMesh();
		}
		else
		{
			meshListIndex--;
			refreshMesh();
		}
	}
	
	private void refreshMesh()
	{
		meshFilter.mesh = meshes[meshListIndex];
		meshFilter.gameObject.GetComponent<MeshCollider>().sharedMesh =  null;
		meshFilter.gameObject.GetComponent<MeshCollider>().sharedMesh =  meshes[meshListIndex]; // note: Assets need to have "Read/Write Enabled" ticked in inspector menu for this to work
	}
}
