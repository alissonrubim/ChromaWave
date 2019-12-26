using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Helpers
{
    public class AudioProcessingHelper
    {
        public static float CalculateSampleByAverageValue(float[] sample)
        {
            int calutationMesureRate = 1000;
            float masterSum = 0;
            for (var i = 0; i < sample.Length - calutationMesureRate; i += calutationMesureRate)
            {
                float sum = 0;
                for (int j = 0; j < calutationMesureRate; j++)
                    sum += Math.Abs(sample[i + j]);
                masterSum += sum / calutationMesureRate;
            }

            return masterSum / (Convert.ToInt32(sample.Length / calutationMesureRate) + 1);
        }

        public static float CalculateSampleByMaxValue(float[] sample)
        {
            float max = 0;
            for (var i = 0; i < sample.Length; i++)
            {
                float val = Math.Abs(sample[i]);
                if (val > max)
                    max = val;
            }

            return max;
        }
    }
}
