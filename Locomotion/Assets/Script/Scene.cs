using System.Collections;

using UnityEngine;

public class Scene : MonoBehaviour
{
    public GameObject personal;
    GeneticAlgorithm GA = new GeneticAlgorithm();
    
    void Start()
    {
        GA.GeneratePopulation();
        GA.Stage = "generate";
    }

    void Update()
    {
        switch(GA.Stage)
        {
            case "selection":
                GA.SelectionPopulation();
                GA.Stage = "generate";
                break;
            case "generate":
                Evolution();
                GA.Stage = "waiting";
                break;
        }
    }

    public void WithdrawalEntity(Entity entity)
    {
        GA.Cash.Add(entity);
        CheckTestEvolution();
    }

    private void StartEvolution()
    {
        for (int i = 0; i < GA.Population.Count; i++)
        {
            GameObject obj = (GameObject)Instantiate(personal, 
                new Vector3(7 + i * 7, personal.transform.position.y, 10 + 10 * (i % 2)), Quaternion.identity);
            obj.GetComponent<Personal>().CreatPersonal(GA.Population[i]); 
        }
        GA.Population.Clear();
    }

    private void Evolution()
    {
        for (int i = 0; i < Parametrs.getInstance().countCross; i++)
        {
            GA.SelectionParent();
        }
        for (int i = 0; i < GA.Parent.Count; i++)
        {
            GA.Population.Add(GA.Parent[i]);
        }
        GA.Parent.Clear();
        GA.Mutation();
        GA.ConvertPopulation();
        StartEvolution();
        GameObject.FindGameObjectWithTag("GUI").GetComponent<GUIController>().
                UpdateEvolution();
    }

    private void CheckTestEvolution()
    {
        if (GameObject.FindGameObjectsWithTag("Personal").Length == 0)
        {
            GA.Stage = "selection";
            GA.CountEvolution++;
            GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition =
                new Vector3(0, 10, 30);
            GameObject.FindGameObjectWithTag("GUI").GetComponent<GUIController>().
                UpdateCountEvolution(GA.CountEvolution, GA.Cash);
        }
    }
}

