using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonGenerator : MonoBehaviour {

	//This list contains every vertex of the mesh that we are going to render.
	public List<Vector3> newVertices = new List<Vector3>();

	// The triangles tell Unity how to build each section of the mesh joining the 
	// vertices.
	public List<int> newTriangles = new List<int> ();

	// The UV list is unimportant right now but it telss Unity how the texture is aligned
	// to each polygon.
	public List<Vector2> newUV = new List<Vector2> ();

	// A mesh is made up of the vertices, triangles and UVs we are going to define, 
	// after we make them up we'll save them as this mesh.
	private Mesh mesh;

	// Keeps track of which square will add.
	private int squareCount;

	private float tUnit = 0.25f;
	private Vector2 tDarkness = new Vector2(0, 0);

	// To store block's information.
	public byte[,] blocks;

	public List<Vector3> colVertices = new List<Vector3> ();
	public List<int> colTriangles = new List<int> ();
	private int colCount;

	private MeshCollider col;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter> ().mesh;
		col = GetComponent<MeshCollider> ();
		GenTerrain ();
		BuildMesh ();
		UpdateMesh ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// To generate every square we want.
	void GenSquare(int x, int y, Vector2 texture){
		float z = transform.position.z;

		newVertices.Add(new Vector3(x, y, z));
		newVertices.Add(new Vector3(x + 1, y, z));
		newVertices.Add(new Vector3(x + 1, y - 1, z));
		newVertices.Add(new Vector3(x, y - 1, z));

		newTriangles.Add (squareCount * 4);
		newTriangles.Add ((squareCount * 4) + 1);
		newTriangles.Add ((squareCount * 4) + 3);
		newTriangles.Add ((squareCount * 4) + 1);
		newTriangles.Add ((squareCount * 4) + 2);
		newTriangles.Add ((squareCount * 4) + 3);

		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));

		squareCount++;
	}

	// To generate the information for the blocks.
	void GenTerrain(){
		blocks = new byte[10, 10];

		for (int px = 0; px < blocks.GetLength (0); px++) {
			for (int py = 0; py < blocks.GetLength (1); py++) {
				if (py == 5)
					blocks [px, py] = 2;
				else if (py < 5)
					blocks [px, py] = 1;
			}
		}
	}

	byte Block (int x, int y){
		if (x == -1 || x == blocks.GetLength (0) || y == -1 || y == blocks.GetLength (1)) {
			return (byte) 1;
		}

		return blocks [x, y];
	}

	void ColliderTriangles(){
		colTriangles.Add (colCount * 4);
		colTriangles.Add ((colCount * 4) + 1);
		colTriangles.Add ((colCount * 4) + 3);
		colTriangles.Add ((colCount * 4) + 1);
		colTriangles.Add ((colCount * 4) + 2);
		colTriangles.Add ((colCount * 4) + 3);
	}

	void GenCollider(int x, int y){
		float z = transform.position.z;

		// Top face
		
		colVertices.Add (new Vector3 (x, y, z + 1));
		colVertices.Add (new Vector3 (x + 1, y, z + 1));
		colVertices.Add (new Vector3 (x + 1, y, z));
		colVertices.Add (new Vector3 (x, y, z));

		ColliderTriangles ();
		colCount++;
	
		// Bottom face
		colVertices.Add (new Vector3 (x, y - 1, z));
		colVertices.Add (new Vector3 (x + 1, y - 1, z));
		colVertices.Add (new Vector3 (x + 1, y - 1, z + 1));
		colVertices.Add (new Vector3 (x, y - 1, z + 1));

		ColliderTriangles ();
		colCount++;
	
		// Left face
		colVertices.Add (new Vector3 (x, y - 1, z + 1));
		colVertices.Add (new Vector3 (x, y, z + 1));
		colVertices.Add (new Vector3 (x, y, z));
		colVertices.Add (new Vector3 (x, y - 1, z));

		ColliderTriangles ();
		colCount++;

		// Right face

		colVertices.Add (new Vector3 (x + 1, y, z + 1));
		colVertices.Add (new Vector3 (x + 1, y - 1, z + 1));
		colVertices.Add (new Vector3 (x + 1, y - 1, z));
		colVertices.Add (new Vector3 (x + 1, y, z));

		ColliderTriangles ();
		colCount++;
	}

	// To 'show' the terrain.
	void BuildMesh(){
		for (int px = 0; px < blocks.GetLength (0); px++) {
			for (int py = 0; py < blocks.GetLength (1); py++) {

				// if the block is not air.
				if (blocks [px, py] != 0) {

					GenCollider (px, py);
				
					if (blocks [px, py] == 1)
						GenSquare (px, py, tDarkness);
					else if (blocks [px, py] == 2)
						GenSquare (px, py, tDarkness);

				}
			}
		}
	}

	// Update mesh component of the game object.
	void UpdateMesh(){

		Mesh newMesh = new Mesh ();

		newMesh.vertices = colVertices.ToArray ();
		newMesh.triangles = colTriangles.ToArray ();
		col.sharedMesh = newMesh;

		colVertices.Clear ();
		colTriangles.Clear ();
		colCount = 0;

		mesh.Clear ();
		mesh.vertices = newVertices.ToArray ();
		mesh.triangles = newTriangles.ToArray ();
		mesh.uv = newUV.ToArray ();
		mesh.RecalculateNormals ();

		squareCount = 0;
		newVertices.Clear ();
		newTriangles.Clear ();
		newUV.Clear ();
	}
}
