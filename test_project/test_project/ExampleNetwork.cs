using System;
using System.IO;
using System.Collections.Generic;

using org.neuroph.core;
using org.neuroph.core.learning;
using org.neuroph.util;
using org.neuroph.nnet;
using org.neuroph.nnet.learning;

namespace test_project
{
	public class ExampleNetwork
	{
		int inputSize = 8;
		int outputSize = 1;
		NeuralNetwork network;
		TrainingSet trainingSet;
		TrainingSet testingSet;
		int[] layers = { 8, 8, 1 };
		string results = "";
		string networkPath = "";
		string trainingPath = "";
		string testingPath = "";


		public ExampleNetwork(string networkPath, string trainingPath, string testingPath)
		{
			this.networkPath = networkPath;
			this.trainingPath = trainingPath;
			this.testingPath = testingPath;
		}

		public void LoadNetwork()
		{
			network = NeuralNetwork.load(networkPath);
		}
		public void TrainNetwork()
		{
			List<int> list = new List<int>();
			foreach (int layer in layers)
			{
				list.Add(layer);
			}
			network = new MultiLayerPerceptron(TransferFunctionType.SIGMOID, list.ToArray());
			trainingSet = new TrainingSet(inputSize, outputSize);
			trainingSet = TrainingSet.createFromFile(trainingPath, inputSize, outputSize, ",");
			BackPropagation learningRule = new BackPropagation();
			network.setLearningRule(learningRule);
			network.learn(trainingSet);
			network.save(networkPath);
		}
		public void TestNetwork()
		{
			double total = 0.0;
			List<int> list = new List<int>();
			List<String> outputLine = new List<String>();
			foreach (int layer in layers)
			{
				list.Add(layer);
			}
			testingSet = TrainingSet.createFromFile(trainingPath, inputSize, outputSize, ",");
			int count = testingSet.elements().size();
			double averageDeviance = 0;
			String resultString = "";
			try
			{
				for (int i = 0; i < testingSet.elements().size(); i++)
				{
					double expected;
					double calculated;
					network.setInput(testingSet.elementAt(i).getInput());
					network.calculate();
					calculated = network.getOutput()[0];
					expected = testingSet.elementAt(i).getIdealArray()[0];
					averageDeviance += Math.Abs(Math.Abs(calculated) - Math.Abs(expected));
					total += network.getOutput()[0];
					resultString = "";
					for (int cols = 0; cols < testingSet.elementAt(i).getInputArray().Length; cols++)
					{
						resultString += testingSet.elementAt(i).getInputArray()[cols] + ", ";
					}
					for (int t = 0; t < network.getOutput().Length; t++)
					{
						resultString += network.getOutput()[t] + ", ";
					}
					resultString = resultString.Substring(0, resultString.Length - 2);
					resultString += "";
				}
				results = GetResults(count, total, averageDeviance);
			}
			catch (IOException ex)
			{
				Console.Error.WriteLine(ex.StackTrace);
			}
		}

		public string GetResults(int count, double total, double averageDeviance)
		{
			return "Average: " + total / count + "\n" +
				"Average Deviance: " + averageDeviance / count;
		}

	}
}
