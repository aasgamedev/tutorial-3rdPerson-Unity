using UnityEngine;

public class VehicleTargetSpawner : MonoBehaviour
{

    public string[] spawnDirection;
    public GameObject targetPrefab;

    GameObject kananAtas;
    GameObject kiriBawah;
    GameObject kiriAtas;
    GameObject kananBawah;

    GameObject nextKananAtas;
    GameObject nextKiriBawah;
    GameObject nextKiriAtas;
    GameObject nextKananBawah;

    public GameObject redlightBlockPrefab;
    GameObject RLkananAtas;
    GameObject RLkiriBawah;
    GameObject RLkiriAtas;
    GameObject RLkananBawah;

    float timerRedLight = 0;
    float maxTimerRedLight = 10;
    int indexGreenLight = 0;

    GameObject[] redLightBlock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        


        for (int i = 0; i < spawnDirection.Length; i++)
        {
            if (spawnDirection[i] == "up")
            {
                kananAtas = Instantiate(targetPrefab, transform.position +new Vector3(4,0,4) , Quaternion.identity);
                nextKiriAtas = Instantiate(targetPrefab, transform.position + new Vector3(-4, 0, 12), Quaternion.identity);
            }
            if (spawnDirection[i] == "down")
            {
                kiriBawah = Instantiate(targetPrefab, transform.position +new Vector3(-4,0,-4) , Quaternion.identity);
                nextKananBawah = Instantiate(targetPrefab, transform.position + new Vector3(4, 0, -12), Quaternion.identity);
            }
            if (spawnDirection[i] == "left")
            {
                kiriAtas = Instantiate(targetPrefab, transform.position +new Vector3(-4,0,4) , Quaternion.identity);
                nextKiriBawah = Instantiate(targetPrefab, transform.position + new Vector3(-12, 0, -4), Quaternion.identity);
            }
            if (spawnDirection[i] == "right")
            {
                kananBawah = Instantiate(targetPrefab, transform.position +new Vector3(4,0,-4) , Quaternion.identity);
                nextKananAtas = Instantiate(targetPrefab, transform.position + new Vector3(12, 0, 4), Quaternion.identity);
            }
            
        }

        if (kananAtas != null)
        {
            kananAtas.GetComponent<VehicleTarget>().nextTarget = new VehicleTarget[spawnDirection.Length - 1];
            int index = 0;
            if(nextKananBawah != null)
            {
                kananAtas.GetComponent<VehicleTarget>().nextTarget[index] = nextKananBawah.GetComponent<VehicleTarget>();
                index++;
            }
            if (nextKiriBawah != null)
            {
                kananAtas.GetComponent<VehicleTarget>().nextTarget[index] = nextKiriBawah.GetComponent<VehicleTarget>();
                index++;
            }if (nextKananAtas != null)
            {
                kananAtas.GetComponent<VehicleTarget>().nextTarget[index] = nextKananAtas.GetComponent<VehicleTarget>();
                index++;
            }
        }
        if (kiriBawah != null)
        {
            kiriBawah.GetComponent<VehicleTarget>().nextTarget = new VehicleTarget[spawnDirection.Length - 1];
            int index = 0;
            if(nextKiriAtas!= null)
            {
                kiriBawah.GetComponent<VehicleTarget>().nextTarget[index] = nextKiriAtas.GetComponent<VehicleTarget>();
                index++;
            }
            if (nextKiriBawah != null)
            {
                kiriBawah.GetComponent<VehicleTarget>().nextTarget[index] = nextKiriBawah.GetComponent<VehicleTarget>();
                index++;
            }if (nextKananAtas != null)
            {
                kiriBawah.GetComponent<VehicleTarget>().nextTarget[index] = nextKananAtas.GetComponent<VehicleTarget>();
                index++;
            }
        }
        if (kiriAtas != null)
        {
            kiriAtas.GetComponent<VehicleTarget>().nextTarget = new VehicleTarget[spawnDirection.Length - 1];
            int index = 0;
            if(nextKiriAtas!= null)
            {
                kiriAtas.GetComponent<VehicleTarget>().nextTarget[index] = nextKiriAtas.GetComponent<VehicleTarget>();
                index++;
            }
            if (nextKananBawah != null)
            {
                kiriAtas.GetComponent<VehicleTarget>().nextTarget[index] = nextKananBawah.GetComponent<VehicleTarget>();
                index++;
            }if (nextKananAtas != null)
            {
                kiriAtas.GetComponent<VehicleTarget>().nextTarget[index] = nextKananAtas.GetComponent<VehicleTarget>();
                index++;
            }
        }
        if (kananBawah != null)
        {
            kananBawah.GetComponent<VehicleTarget>().nextTarget = new VehicleTarget[spawnDirection.Length - 1];
            int index = 0;
            if(nextKiriAtas!= null)
            {
                kananBawah.GetComponent<VehicleTarget>().nextTarget[index] = nextKiriAtas.GetComponent<VehicleTarget>();
                index++;
            }
            if (nextKananBawah != null)
            {
                kananBawah.GetComponent<VehicleTarget>().nextTarget[index] = nextKananBawah.GetComponent<VehicleTarget>();
                index++;
            }if (nextKiriBawah != null)
            {
                kananBawah.GetComponent<VehicleTarget>().nextTarget[index] = nextKiriBawah.GetComponent<VehicleTarget>();
                index++;
            }
        }

        redLightBlock = new GameObject[spawnDirection.Length];

        for (int i = 0; i < spawnDirection.Length; i++)
        {
            if (spawnDirection[i] == "up")
            {
                RLkananAtas = Instantiate(redlightBlockPrefab, transform.position + new Vector3(4, 0, 8), Quaternion.identity);
                redLightBlock[i] = RLkananAtas;
            }
            if (spawnDirection[i] == "down")
            {
                RLkiriBawah = Instantiate(redlightBlockPrefab, transform.position + new Vector3(-4, 0, -8), Quaternion.identity);
                redLightBlock[i] = RLkiriBawah;
            }
            if (spawnDirection[i] == "left")
            {
                RLkiriAtas = Instantiate(redlightBlockPrefab, transform.position + new Vector3(-8, 0, 4), Quaternion.identity);
                RLkiriAtas.transform.eulerAngles = new Vector3(0,90,0);
                redLightBlock[i] = RLkiriAtas;
            }
            if (spawnDirection[i] == "right")
            {
                RLkananBawah = Instantiate(redlightBlockPrefab, transform.position + new Vector3(8, 0, -4), Quaternion.identity);
                RLkananBawah.transform.eulerAngles = new Vector3(0, 90, 0);
                redLightBlock[i] = RLkananBawah;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        timerRedLight -= Time.deltaTime;
        if(timerRedLight < 0)
        {
            timerRedLight = maxTimerRedLight;
            indexGreenLight++;
            if (indexGreenLight >= spawnDirection.Length)
            {
                indexGreenLight = 0;
            }

            for (int i = 0; i < spawnDirection.Length; i++)
            {
                if (i == indexGreenLight)
                {
                    redLightBlock[i].active = false;
                }
                else
                {
                    redLightBlock[i].active = true;
                }
                
            }
        }
    }
}
