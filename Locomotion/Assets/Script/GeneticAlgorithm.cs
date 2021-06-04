using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GeneticAlgorithm
{
    public string Stage { get; set; }
    public int CountEvolution { get; set; } = 1;

    public List<Entity> Population = new List<Entity>();
    public List<Entity> Cash = new List<Entity>();
    public List<Entity> Parent = new List<Entity>();

    public void GeneratePopulation()
    {
        for (int i = 0; i < Parametrs.getInstance().sizePopulation; i++)
        {
            Population.Add(new Entity());
            Population[i].ConvertEntityToGenotype();
        }
    }

    public void SelectionParent()
    {
        int index = Random.Range(0, Population.Count);
        Entity ParentOne = Population[index];
        Population.RemoveAt(index);
        Parent.Add(ParentOne);

        index = Random.Range(0, Population.Count);
        Entity ParentTwo = Population[index];
        Population.RemoveAt(index);
        Parent.Add(ParentTwo);

        Crossing(ParentOne, ParentTwo);
    }

    private void Crossing(Entity OneParent, Entity TwoParent)
    {
        Entity ChildOne = new Entity();
        Entity ChildTwo = new Entity();
        for (int i = 0; i < ChildOne.Genotype.Count; i++)
        {
            int PointDiffrent = Random.Range(1, Parametrs.getInstance().sizeGen - 1);
            string GenOne = OneParent.Genotype[i].Gen.Substring(0, PointDiffrent) +
            TwoParent.Genotype[i].Gen.Substring(PointDiffrent, Parametrs.getInstance().sizeGen - PointDiffrent);

            string GenTwo = TwoParent.Genotype[i].Gen.Substring(0, PointDiffrent) +
                OneParent.Genotype[i].Gen.Substring(PointDiffrent, Parametrs.getInstance().sizeGen - PointDiffrent);

            ChildOne.Genotype[i].Gen = GenOne;
            ChildTwo.Genotype[i].Gen = GenTwo;
        }
        Population.Add(ChildOne);
        Population.Add(ChildTwo);
    }

    public void Mutation()
    {
        for (int i = 0; i < Parametrs.getInstance().countMutationEntity; i++)
        {
            int indexEntity = Random.Range(0, Population.Count);
            for (int j = 0; j < Parametrs.getInstance().countMutationGen; j++)
            {
                int indexGen = Random.Range(0, Population[indexEntity].Genotype.Count);
                int placeMutation = Random.Range(Population[indexEntity].Genotype[indexGen].Gen.IndexOf("1"),
                    Population[indexEntity].Genotype[indexGen].Gen.Length);
                if (placeMutation == -1)
                {
                    placeMutation = 0;
                }
                string s = Population[indexEntity].Genotype[indexGen].Gen;
                char[] chars = s.ToCharArray();
                chars[placeMutation] = InverseAllel
                    (Population[indexEntity].Genotype[indexGen].Gen[placeMutation]);
                Population[indexEntity].Genotype[indexGen].Gen = new string(chars);
            }
        }

    }

    private char InverseAllel(char allel)
    {
        if (allel == '0')
        {
            return '1';
        }
        else
        {
            return '0';
        }
    }

    public void SelectionPopulation()
    {
        float koefTimeLife = 0.3f;
        float koefDistance = 0.7f;

        Cash.OrderBy(x => x.TimeLife);
        for (int i = 0; i < Cash.Count; i++)
        {
            Cash[i].Point += i * koefTimeLife;
        }

        Cash.OrderBy(x => x.Distance);
        for (int i = 0; i < Cash.Count; i++)
        {
            Cash[i].Point += i * koefDistance;
        }

        Cash.OrderByDescending(x => x.Point);
        for (int i = 0; i < Parametrs.getInstance().countElite; i++)
        {
            Population.Add(Cash[0]);
            Cash.RemoveAt(0);
        }
        Population[0].Save();
        while (Population.Count < Parametrs.getInstance().sizePopulation)
        {
            Entity OneEntity = Cash[Random.Range(0, Cash.Count)];
            Cash.Remove(OneEntity);
            Entity TwoEntity = Cash[Random.Range(0, Cash.Count)];
            Cash.Remove(TwoEntity);
            if (OneEntity.TimeLife >= TwoEntity.TimeLife)
            {
                OneEntity.Point += (OneEntity.TimeLife / TwoEntity.TimeLife) * koefTimeLife;
                TwoEntity.Point += 1 * koefTimeLife;
            }
            else
            {
                TwoEntity.Point += (TwoEntity.TimeLife / OneEntity.TimeLife) * koefTimeLife;
                OneEntity.Point += 1 * koefTimeLife;
            }
            if (OneEntity.Distance >= TwoEntity.Distance)
            {
                OneEntity.Point += (OneEntity.Distance / TwoEntity.Distance) * koefDistance;
                TwoEntity.Point += 1 * koefDistance;
            }
            else
            {
                TwoEntity.Point += (TwoEntity.Distance / OneEntity.Distance) * koefDistance;
                OneEntity.Point += 1 * koefDistance;
            }

            if (OneEntity.Point >= TwoEntity.Point)
            {
                Population.Add(OneEntity);
                Cash.Add(TwoEntity);
            }
            else
            {
                Population.Add(TwoEntity);
                Cash.Add(OneEntity);
            }
        }
        Cash.Clear();

        for (int i = 0; i < Population.Count; i++)
        {
            Population[i].Zeroing();
        }
    }

    

    public void ConvertPopulation()
    {
        for (int i = 0; i < Population.Count; i++)
        {
            Population[i].ConvertGenotypeToEntity();
        }
    }
}
