﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework.Internal;
using DotNet.Docker.scr;

namespace DotNet.Docker.test
{
	[TestFixture]
	public class StatisticsTests
	{


		[SetUp]
		public void SetUp()
		{
		}

		[Test]
		public void GetInts_TestOne()
		{
			String[] test = new string[] { "--mode", "--median", "--max", "--min", "5", "6", "4", "6"};
			List<int> actual_return = Statistics.GetInts(test);
			List<int> expected_return = new List<int>();
			expected_return.Add(5);
			expected_return.Add(6);
			expected_return.Add(4);
			expected_return.Add(6);
			Assert.That(actual_return.SequenceEqual(expected_return));
		}

		[Test]
		public void GetInts_TestTwo()
		{

			String[] test1 = new string[] { "--mode", "--median", "--max", "--min", "5", "6", "4", "6" };
			String[] test2 = new string[] { "--mode", "5", "--median", "6", "--max", "4", "6", "--min" };
			List<int> return1 = Statistics.GetInts(test1);
			List<int> return2 = Statistics.GetInts(test2);
			Assert.That(return1.SequenceEqual(return2));
		}

		[Test]
		public void GetOperations_Test() 
		{
			String[] test = new string[] { "--mode", "--median", "--max", "--min"};
			Dictionary<String, bool> operations = Statistics.GetOperations(test);
			Assert.That(operations["mode"]);
			Assert.That(operations["median"]);
			Assert.That(operations["max"]);
			Assert.That(operations["min"]);
		}

		[Test]
		public void GetMedian_Test() 
		{
			List<int> expected_return = new List<int>();
			expected_return.Add(8);
			expected_return.Add(6);
			expected_return.Add(5);
			expected_return.Add(4);
			expected_return.Add(6);

			double median = Statistics.GetMedian(expected_return);
			Assert.That(median == 6);
		}
	}
}