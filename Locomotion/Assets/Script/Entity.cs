using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Entity
{
    public List<Chromosome> Genotype = new List<Chromosome>();
    public float TimeLife { get; set; } = 0;
    public float Distance { get; set; } = 0;
    public float Point { get; set; } = 0;

    public Entity()
    {
        Genotype.Add(new Chromosome("TimeHalfCycle", Random.Range(0.2f, 2), 100, 0.2f, 2));

        Genotype.Add(new Chromosome("MassHead", Random.Range(1, 50), 1, 1, 50));
        Genotype.Add(new Chromosome("MassTorso", Random.Range(1, 50), 1, 1, 50));
        Genotype.Add(new Chromosome("MassPelvis", Random.Range(1, 50), 1, 1, 50));
        Genotype.Add(new Chromosome("MassShoulder", Random.Range(1, 50), 1, 1, 50));
        Genotype.Add(new Chromosome("MassForearm", Random.Range(1, 50), 1, 1, 50));
        Genotype.Add(new Chromosome("MassWrist", Random.Range(1, 50), 1, 1, 50));
        Genotype.Add(new Chromosome("MassHip", Random.Range(1, 50), 1, 1, 50));
        Genotype.Add(new Chromosome("MassShin", Random.Range(1, 50), 1, 1, 50));
        Genotype.Add(new Chromosome("MassFoot", Random.Range(1, 50), 1, 1, 50));

        Genotype.Add(new Chromosome("Swing2LimitHead", Random.Range(3, 5), 1, 3, 5));
        Genotype.Add(new Chromosome("Swing1LimitHead", Random.Range(3, 5), 1, 3, 5));
        int lowTwistLimit = Random.Range(1, 4);
        Genotype.Add(new Chromosome("LowTwistLimitHead", lowTwistLimit, 1, 1, 4));
        Genotype.Add(new Chromosome("HighTwistLimitHead", Random.Range(lowTwistLimit, 5), 1, lowTwistLimit, 5));

        Genotype.Add(new Chromosome("Swing2LimitTorso", Random.Range(3, 5), 1, 3, 5));
        Genotype.Add(new Chromosome("Swing1LimitTorso", Random.Range(3, 5), 1, 3, 5));
        lowTwistLimit = Random.Range(1, 4);
        Genotype.Add(new Chromosome("LowTwistLimitTorso", lowTwistLimit, 1, 1, 4));
        Genotype.Add(new Chromosome("HighTwistLimitTorso", Random.Range(lowTwistLimit, 5), 1, lowTwistLimit, 5));

        Genotype.Add(new Chromosome("Swing2LimitHip", Random.Range(3, 60), 1, 3, 60));
        Genotype.Add(new Chromosome("Swing1LimitHip", Random.Range(3, 60), 1, 3, 60));
        lowTwistLimit = Random.Range(1, 59);
        Genotype.Add(new Chromosome("LowTwistLimitHip", lowTwistLimit, 1, 1, 59));
        Genotype.Add(new Chromosome("HighTwistLimitHip", Random.Range(lowTwistLimit, 60), 1, lowTwistLimit, 60));

        Genotype.Add(new Chromosome("Swing2LimitShin", Random.Range(3, 5), 1, 3, 5));
        Genotype.Add(new Chromosome("Swing1LimitShin", Random.Range(3, 5), 1, 3, 5));
        lowTwistLimit = Random.Range(1, 4);
        Genotype.Add(new Chromosome("LowTwistLimitShin", lowTwistLimit, 1, 1, 4));
        Genotype.Add(new Chromosome("HighTwistLimitShin", Random.Range(lowTwistLimit, 5), 1, lowTwistLimit, 5));

        Genotype.Add(new Chromosome("Swing2LimitFoot", Random.Range(3, 5), 1, 3, 5));
        Genotype.Add(new Chromosome("Swing1LimitFoot", Random.Range(3, 5), 1, 3, 5));
        lowTwistLimit = Random.Range(1, 4);
        Genotype.Add(new Chromosome("LowTwistLimitFoot", lowTwistLimit, 1, 1, 4));
        Genotype.Add(new Chromosome("HighTwistLimitFoot", Random.Range(lowTwistLimit, 5), 1, lowTwistLimit, 5));

        Genotype.Add(new Chromosome("WalkingRotationShoulderForwardX", Random.Range(1, 30), 1, 1, 30));
        float walkingRotationPelvisForwardX = Random.Range(1, 50);
        Genotype.Add(new Chromosome("WalkingRotationPelvisForwardX", walkingRotationPelvisForwardX , 1, 1, 50));
        Genotype.Add(new Chromosome("WalkingRotationPelvisBackX", 
            Random.Range(1, walkingRotationPelvisForwardX), 1, 1, walkingRotationPelvisForwardX));
        Genotype.Add(new Chromosome("WalkingTransformPelvisForwardZ", Random.Range(0.1f, 2), 100, 0.1f, 2));

        Genotype.Add(new Chromosome("WalkingRotationHipForwardX", Random.Range(1, 90), 1, 1, 90));
    }

    public void Save()
    {
        string json = "";
        for (int i = 0; i < Genotype.Count; i++)
        {
            json += Genotype[i].Name + " " + Genotype[i].Parameter + "\n"; 
        }
        File.WriteAllText(Application.dataPath + "/entity.json", json);
        Debug.Log(Application.dataPath);
    }

   public void ConvertEntityToGenotype()
    {
        for (int i = 0; i < Genotype.Count; i++)
        {
            Genotype[i].ConvertParametrToGen();
        }
    }

    public void ConvertGenotypeToEntity()
    {
        for (int i = 0; i < Genotype.Count; i++)
        {
            Genotype[i].ConvertGenToParametr();
        }
    }

    public Chromosome FindChromosome(string Name)
    {
        for (int i = 0; i < Genotype.Count; i++)
        {
            if (Genotype[i].Name == Name)
            {
                return Genotype[i];
            }
        }
        return new Chromosome("None", 0, 1, 1, 1);
    }

    public void Zeroing()
    {
        TimeLife = 0;
        Distance = 0;
        Point = 0;
    }
}
