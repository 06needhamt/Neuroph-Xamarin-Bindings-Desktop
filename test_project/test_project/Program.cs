using System;

namespace test_project
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			ExampleNetwork network = new ExampleNetwork("ExampleNetwork.nnet", "train.csv", "test.csv");
			network.TrainNetwork();
			network.TestNetwork();
			Console.ReadKey();
		}
	}
}
