using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Hadoop.MapReduce

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var hadoop = Hadoop.Connect();
            var result = hadoop.MapReduceJob.ExecuteJob<SqrtJob>();
        }
    }
    public class SqrtMapper : MapperBase
    {
        public override void Map(string inputLine, MapperContext context)
        {
            int inputValue = int.Parse(inputLine);
            double sqrt = Math.Sqrt(inputValue);
            context.EmitKeyValue(inputValue.ToString(), sqrt.ToString());
        }
    }
    public class SqrtJob : HadoopJob<SqrtMapper>
    {
        public override HadoopJobConfiguration Configure(ExecutorContext context)
        {
            HadoopJobConfiguration config = new HadoopJobConfiguration();
            config.InputPath = "/Input/Sqrt";
            config.OutputFolder = "/Output/Sqrt";
            return config;
        }
    }
}
