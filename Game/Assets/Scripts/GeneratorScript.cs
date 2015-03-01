using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratorScript : MonoBehaviour {

	public GameObject[] availableScenes;
	
	public List<GameObject> currentScenes;
	
	private float screenWidthInPoints;

	void AddScene(float farhtestSceneEndX) {
		//1
		int randomSceneIndex = Random.Range(0, availableScenes.Length);
		
		//2
		GameObject scene = (GameObject)Instantiate(availableScenes[randomSceneIndex]);
		
		//3
		float sceneWidth = scene.transform.FindChild("Floor").localScale.x;
		
		//4
		float sceneCenter = farhtestSceneEndX + sceneWidth * 0.5f;
		
		//5
		scene.transform.position = new Vector3(sceneCenter, 0, 0);
		
		//6
		currentScenes.Add(scene);         
	}

	void GenerateSceneIfRequired() {
		//1
		List<GameObject> scenesToRemove = new List<GameObject>();
		
		//2
		bool addScenes = true;        
		
		//3
		float playerX = transform.position.x;
		
		//4
		float removeSceneX = playerX - screenWidthInPoints;        
		
		//5
		float addSceneX = playerX + screenWidthInPoints;
		
		//6
		float farthestSceneEndX = 0;
		
		foreach(var scene in currentScenes)
		{
			//7
			float sceneWidth = scene.transform.FindChild("Floor").localScale.x;
			float sceneStartX = scene.transform.position.x - (sceneWidth * 0.5f);    
			float sceneEndX = sceneStartX + sceneWidth;                            
			
			//8
			if (sceneStartX > addSceneX)
				addScenes = false;
			
			//9
			if (sceneEndX < removeSceneX)
				scenesToRemove.Add(scene);
			
			//10
			farthestSceneEndX = Mathf.Max(farthestSceneEndX, sceneEndX);
		}
		
		//11
		foreach(var scene in scenesToRemove)
		{
			currentScenes.Remove(scene);
			Destroy(scene);            
		}
		
		//12
		if (addScenes)
			AddScene(farthestSceneEndX);
	}

	void FixedUpdate () {    
		GenerateSceneIfRequired();
	}
	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
