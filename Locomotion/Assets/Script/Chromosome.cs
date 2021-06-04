using System;

public class Chromosome
{
    public String Name { get; set; }
    public float Parameter { get; set; }
    public String Gen { get; set; }
    public float NormKoeff { get; set; }
    public float TopLimit { get; set; }
    public float BottomLimit { get; set; }


    public Chromosome(String Name, float Parameter, float NormKoeff, float BottomLimit, float TopLimit)
    {
        this.Name = Name;
        this.Parameter = Parameter;
        this.NormKoeff = NormKoeff;
        this.BottomLimit = BottomLimit;
        this.TopLimit = TopLimit;
    }

    private String BinStringFormat(String s)
    {
        String zero = "";
        for (int i = s.Length; i < Parametrs.getInstance().sizeGen; i++)
        {
            zero += "0";
        }
        return zero + s;
    }

    private Byte GreyToBin(Byte num)
    {
        Byte result = 0;
        while (num > 0)
        {
            result ^= num;
            num >>= 1;
        }
        return result;
    }

    public void ConvertParametrToGen()
    {
        int normal = Convert.ToInt32(Parameter * NormKoeff);
        Byte i = byte.Parse((normal).ToString());
        Gen = BinStringFormat(Convert.ToString(i ^ (i >> 1), 2));
    }

    public void ConvertGenToParametr()
    {
        String convertParameter = BinStringFormat(Convert.ToString(GreyToBin(Convert.ToByte(Gen, 2))));
        Parameter = CheckedParameterFork(Convert.ToInt32(convertParameter) / NormKoeff);
    }

    private float CheckedParameterFork(float value)
    {
        if (value < BottomLimit)
        {
            return BottomLimit;
        }
        else if (value > TopLimit) {
            return TopLimit;
        }
        else
        {
            return value;
        }
    }
}
