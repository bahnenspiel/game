using UnityEngine;
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

		TextAsset tempAsset = (TextAsset) Resources.Load("Levels/1", typeof(TextAsset));

		string levelText = tempAsset.text;

		string[] lines = levelText.Split(new char[]{'\n'});

		System.Array.Reverse(lines);

		int y = 0;
		foreach (string line in lines) {
			int x = 0;
			foreach (char c in line) {
				if(prefabDict.ContainsKey(c)) {
					GameObject prefab = prefabDict[c];
				
					GameObject.Instantiate(prefab, new Vector3(x, 0, y), new Quaternion());
				}
				x += 5;
			}
			y += 20;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
