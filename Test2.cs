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
    public class Test2 : TestBase
    {
        [Test]
        public void Test2CaseTest()
        {
            AccountData account = new AccountData("pavel_test", "test");
            Note note = new Note("NEW AWESOME TEST!!!", "Красный фон");
            Note subNote = new Note("AWESOME SUBTEST", "Зелёный фон");

            OpenURL(base.baseURL);

            LogIn(account.GetLogin(), account.GetPassword());

            AddNoteWithSettings(note.GetText(), note.GetSettings());
            
            AddSubNoteWithSettings(subNote.GetText(), subNote.GetSettings());

            subNote.SetSettings("Красный текст");
            EditSubNoteSettings(2, subNote.GetSettings());

            DeleteNote(4);

            LogOut();
        }
    }
}