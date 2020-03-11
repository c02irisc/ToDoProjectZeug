using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoProject;
using ToDoProject.Models;
using ToDoProject.ViewModels;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Absolute_Test()
        {
            Assert.IsTrue(true, "true should be true, always");
        }

        [TestMethod]
        public void RestApiViewModel_returns_pictureUrl()
        {
            RestApiViewModel test = new RestApiViewModel();
            Console.WriteLine(test.GeladenesBild);

            Assert.IsNotNull(test.GeladenesBild, "returns picture");
        }

        [TestMethod]
        public void ListenAnsichtViewModel_goes_through_list()
        {
            ListenAnsichtViewModel test = new ListenAnsichtViewModel();
            ToDoList list = new ToDoList();

            test.Aufgaben = new System.Collections.ObjectModel.ObservableCollection<Aufgabe>();

            Aufgabe testA = new Aufgabe()
            {
                AufgabeID = 1,
                Done = false
            };
            Aufgabe testB = new Aufgabe()
            {
                AufgabeID = 2,
                Done = true
            };
            Aufgabe testC = new Aufgabe()
            {
                AufgabeID = 2,
                Done = true
            };
            test.Aufgaben.Add(testA);
            test.Aufgaben.Add(testB);
            test.Aufgaben.Add(testC);


            test.FilterBy("Done");

            Assert.IsTrue(test.Aufgaben.Count == 3, "Liste wurde befüllt");
            Assert.IsTrue(test.ResponsiveAufgabenListe.Count == 2, "Liste enthält nur 1 Objekt");
        }
    }
}
