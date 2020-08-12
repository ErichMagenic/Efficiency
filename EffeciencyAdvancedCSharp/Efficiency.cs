using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EffeciencyAdvancedCSharp
{
    #region Class vs Struct Declarations
    struct SampleStructure
    {
        public string Name;
        public string Surname;
    }
    class SampleClass
    {
        public string Name;
        public string Surname;
    }

    #endregion Class vs Struct Declarations

    #region Stringbuilder vs String
    class Test
    {
        public static string Name { get; set; }
        public static string surname;
    }
    #endregion Stringbuilder vs String

    [TestClass]
    public class Efficiency
    {
        /// <summary>
        /// This Test Method is only used to warm up the compiler so that the other tests would not take too much time.
        /// </summary>
        [TestMethod]
        public void Effeciency_WarmUpTest()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void EfficiencyArrayVsList()
        {
            //Arange
            var sampleList = new List<int>();
            var stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                sampleList.Add(i);
            }

            stopwatch.Stop();

            Console.WriteLine("Arraylist (Object): " + stopwatch.ElapsedTicks);

            stopwatch.Reset();

            stopwatch.Start();

            Int32[] a = new Int32[10000];

            for (int i = 0; i < 10000; i++)
            {
                a[i] = i;
            }
            stopwatch.Stop();

            Console.WriteLine("Value (Integer Array): " + stopwatch.ElapsedTicks);

            //Assert
        }

        [TestMethod]
        public void EfficiencyStringConcatenateVsStringBuilder()
        {
            //Arrange
            var sampleString = "Sample String ";
            var sampleStringBuilder = new StringBuilder("Sample String ");
            var stopWatch = new Stopwatch();

            //Act
            stopWatch.Start();

            //String Concatenation
            for (int i = 0; i < 500; i++)
            {
                sampleString = sampleString + "A";
            }

            stopWatch.Stop();

            Console.WriteLine("String Concatenation :" + stopWatch.ElapsedTicks);

            stopWatch.Restart();

            //String Builder
            for (int i = 0; i < 500; i++)
            {
                sampleStringBuilder.Append("A");
            }

            stopWatch.Stop();

            Console.WriteLine("Stringbuilder :" + stopWatch.ElapsedTicks);

            //Assert
        }

        [TestMethod]
        public void EfficiencyPropertyVsDirectAssign()
        {
            //Arrange
            var stopWatch = new Stopwatch();

            //Act
            stopWatch.Start();

            //Property Assignment
            for (int i = 0; i < 100; i++)
            {
                Test.Name = "Value";
            }

            stopWatch.Stop();

            Console.WriteLine("Using Property: " + stopWatch.ElapsedTicks);

            stopWatch.Restart();

            //Direct Assignment
            for (int i = 0; i < 100; i++)
            {
                Test.surname = "Value";
            }

            stopWatch.Stop();

            Console.WriteLine("Direct Assign: " + stopWatch.ElapsedTicks);

            //Assert
        }

        [TestMethod]
        public void EfficiencyForLoopComparisonList()
        {
            //Arange
            var max = 10000;
            var countForLoopList = Enumerable.Range(0, max).ToList();
            var sampleForLoopList1 = new List<Int32>();
            var sampleForLoopList2 = new List<Int32>();
            var sampleForLoopList3 = new List<Int32>();
            var stopWatch = new Stopwatch();

            //Arrange
            stopWatch.Start();

            // For Loop Example
            for (int i = 0; i < countForLoopList.Count; i++)
            {
                sampleForLoopList1.Add(countForLoopList[i]);
            }

            stopWatch.Stop();

            Console.WriteLine("For Loop: " + stopWatch.ElapsedTicks);

            stopWatch.Restart();

            //For Each Loop Example
            foreach (int a in countForLoopList)
            {
                sampleForLoopList2.Add(a);
            }

            stopWatch.Stop();

            Console.WriteLine("Foreach Loop: " + stopWatch.ElapsedTicks);

            stopWatch.Restart();

            //For Each LINQ Example
            countForLoopList.ForEach(x => sampleForLoopList3.Add(x));

            stopWatch.Stop();

            Console.WriteLine("Foreach LINQ: " + stopWatch.ElapsedTicks);

            //Assert
        }

        [TestMethod]
        public void EfficiencyForLoopComparisonArray()
        {
            //Arange
            var max = 10000;
            var countArray = Enumerable.Range(0, max).ToArray();
            var sampleList1 = new List<Int32>();
            var sampleList2 = new List<Int32>();
            var sampleList3 = new List<Int32>();
            var stopWatch = new Stopwatch();

            //Act
            stopWatch.Start();

            // For Loop Example
            for (int i = 0; i < countArray.Length; i++)
            {
                sampleList1.Add(countArray[i]);
            }

            stopWatch.Stop();

            Console.WriteLine("For Loop: " + stopWatch.ElapsedTicks);

            stopWatch.Restart();

            //For Each Loop Example
            foreach (int a in countArray)
            {
                sampleList2.Add(a);
            }

            stopWatch.Stop();

            Console.WriteLine("Foreach Loop: " + stopWatch.ElapsedTicks);

            stopWatch.Restart();

            //For Each LINQ Example
            countArray.ToList().ForEach(x => sampleList3.Add(x));

            stopWatch.Stop();

            Console.WriteLine("Foreach LINQ: " + stopWatch.ElapsedTicks);

            //Assert
        }

        [TestMethod]
        public void EfficiencyClassVsStruct()
        {
            //Arrange
            var sampleStruct = new SampleStructure[1000];
            var sampleClass = new SampleClass[1000];
            var stopWatch = new Stopwatch();

            //Act
            stopWatch.Start();

            //Struct Example
            for (int i = 0; i < 1000; i++)
            {
                sampleStruct[i] = new SampleStructure();
                sampleStruct[i].Name = "Sourav";
                sampleStruct[i].Surname = "Kayal";
            }
            stopWatch.Stop();

            Console.WriteLine("Structure: " + stopWatch.ElapsedTicks);

            stopWatch.Restart();

            //Class Example
            for (int i = 0; i < 1000; i++)
            {
                sampleClass[i] = new SampleClass();
                sampleClass[i].Name = "Sourav";
                sampleClass[i].Surname = "Kayal";
            }

            stopWatch.Stop();

            Console.WriteLine("Class: " + stopWatch.ElapsedTicks);

            //Assert
        }


    }
}
