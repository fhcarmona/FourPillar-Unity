using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    enum ChooseCar { Bus, FamilyCar, Pickup, Van, Random };

    [SerializeField]
    private ChooseCar chooseCar;

    [SerializeField]
    private List<GameObject> spawnCarChoices;
    private GameObject spawnedCar;

    // ENCAPSULATION
    private Vector3 spawnPos { get; set; }

    private float spawnRange = 15;
    private float spawnHeight = 1;


    // Start is called before the first frame update
    void Awake()
    {
        // Generate a car object
        if(chooseCar.ToString() == "Random")
            spawnedCar = GenerateCar();
        else
            spawnedCar = GenerateCar((int) chooseCar);

        // Generate a random spawn position
        spawnPos = GenerateSpawnPos();

        // Spawn the vehicle
        Instantiate(spawnedCar, spawnPos, spawnedCar.transform.rotation);
    }

    Vector3 GenerateSpawnPos()
    {
        // Generate two random numbers
        float xRange = Random.Range(-spawnRange, spawnRange);
        float zRange = Random.Range(-spawnRange, spawnRange);

        // Return a vector with random values to x and z
        return new Vector3(xRange, spawnHeight, zRange);
    }

    // POLYMORPHISM
    GameObject GenerateCar()
    {
        int indexCar = Random.Range(0, spawnCarChoices.Count);

        Debug.Log($"Generate Random Car: {spawnCarChoices[indexCar].name}");

        return spawnCarChoices[indexCar];
    }

    GameObject GenerateCar(int indexCar)
    {
        Debug.Log($"Generate Car: {spawnCarChoices[indexCar].name}");

        return spawnCarChoices[indexCar];
    }
}
