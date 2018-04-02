using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Testing_2018
{
    [TestFixture]
    public class Test1 : TestBase
    {
        

        [Test]
        public void Test1CaseTest()
        {
            AccountData account = new AccountData("pavel_test", "test");
            Note note = new Note("TEST4");
            OpenURL(base.baseURL);
            LogIn(account.GetLogin(), account.GetPassword());
            AddNote(note.GetText());
            LogOut();
        }

        
    }
}


