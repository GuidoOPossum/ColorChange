using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShapesSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] shapePrefs;

    [SerializeField] private float range = 2.5f;
    private ColorPalette[] palette;

    private float minSpamTime = 0.5f;
    private float maxSpamTime = 1.5f;
    private float doubleSpawnChance = 0.0f;
    private float speedMultiplyer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        palette = ColorInfo.palette.Keys.ToArray();

        AdjustCameraSize();
        float randDelay = 1.0f;
        StartCoroutine(SpawnShape(randDelay));
        Difficulty difficulty = SettingsManager.instanse.difficulty;
        switch (difficulty)
        {
            case Difficulty.Easy:

                break;

            case Difficulty.Medium:
                speedMultiplyer = 1.5f;
                doubleSpawnChance = 0.2f;
                minSpamTime = 0.4f;
                maxSpamTime = 1.3f;
                break;

            case Difficulty.Hard:
                speedMultiplyer = 2.0f;
                doubleSpawnChance = 0.4f;
                minSpamTime = 0.4f;
                maxSpamTime = 1.1f;
                break;
            default:

                break;
        }

    }
    void AdjustCameraSize()
    {
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        if (aspectRatio > 1.0f)
        {
            return;
        }
        // трохи добавив щоб камера завжди була трошки більшою
        Camera.main.orthographicSize = (range + 0.5f) / aspectRatio;
    }

    IEnumerator SpawnShape(float delay)
    {
        yield return new WaitForSeconds(delay);
        int times = 1;
        float f = Random.Range(0.0f,1.0f);
        if (f < doubleSpawnChance)
        {
            times = 2;
        }
        for (int i = 0; i < times; i++)
        {
            float rangeX =  Random.Range(2 * range * i / times , 2 * range * (i + 1) / times);
            float randomX = transform.position.x - range + rangeX;
            //Random.Range(transform.position.x - range, transform.position.x + range);
            float fixedY = transform.position.y;

            Vector2 randomPosition = new Vector2(randomX, fixedY);
            int randShapeI = Random.Range(0, shapePrefs.Count());
            Transform newShape = Instantiate(shapePrefs[randShapeI], randomPosition, Quaternion.identity);
            FallingShapes fallingShape = newShape.GetComponent<FallingShapes>();
            int randomIndex = UnityEngine.Random.Range(0, palette.Length);
            ColorPalette colorP = palette[randomIndex]; ;
            fallingShape.SetColor(colorP);
            fallingShape.MultiplySpeed(speedMultiplyer);
        }
        float randDelay = Random.Range(minSpamTime, maxSpamTime);
        StartCoroutine(SpawnShape(randDelay));
    }
}
