﻿using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	[System.Serializable]
	public struct CharGameObjectMapping {
		public char character;
		public GameObject prefab;
	}

	public CharGameObjectMapping[] gameElements;

	private Dictionary<char,GameObject> prefabDict = new Dictionary<char,GameObject>();

	// Use this for initialization
	void Start () {
		foreach (CharGameObjectMapping mapping in gameElements) {
			prefabDict.Add(mapping.character, mapping.prefab);
		}
		GenerateLevel(1);
	}
	
	void GenerateLevel(int id) {
		

		TextAsset tempAsset = (TextAsset) Resources.Load("Levels/" + id, typeof(TextAsset));

		string levelText = tempAsset.text;

		string[] lines = levelText.Split(new char[]{'\n'});

		System.Array.Reverse(lines);

		float y = 0;
		foreach (string line in lines) {
			int x = 0;
			foreach (char c in line) {
				if(prefabDict.ContainsKey(c)) {
					GameObject prefab = prefabDict[c];
				

					GameObject newObject = (GameObject) GameObject.Instantiate(prefab, new Vector3(x, 0, y - 0.5f), new Quaternion());
					newObject.transform.parent = transform;
				}
				x += 5;
			}
			y += 20;
		}
	}
	
	public void JumpToLevel(int levelId) {
		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		
		GenerateLevel(levelId);
	}
	
}
