using UnityEngine;

public class perlinTerrain : MonoBehaviour {
    
    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public int seed = 0;
    public float scale = 20;

    void Start() {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData) {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3 (width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights() {
        float[,] heights = new float[width, height];
        for (int x = 0; x<width; x++) {
            for (int y = 0; y<height; y++) {
                heights[x,y] = calculateHeight(x,y); //perlin noise shit
            }
        }
        return heights;
    }

    float calculateHeight(int x, int y) {
        float XCord = (float) x/width * scale;
        float yCord = (float) y/height * scale;
        if (seed == 0) {
            seed = (int) Random.Range(-Mathf.Pow(2, 8) + 1, Mathf.Pow(2, 8) - 1);
        }
        return Mathf.PerlinNoise(XCord + seed, yCord + seed);
    }

}
